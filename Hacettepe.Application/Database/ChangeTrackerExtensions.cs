using Hacettepe.Application.Authentication.Infrastructure;
using Hacettepe.Application.Common;
using Hacettepe.Domain;
using Hacettepe.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hacettepe.Application.Database;

public static class ChangeTrackerExtensions
{
    public static void SetAuditProperties(this ChangeTracker changeTracker, ICurrentUserService currentUserService)
    {
        changeTracker.DetectChanges();
        var entities =
            changeTracker
                .Entries()
                .Where(t => t is { Entity: IEntityBase, State: EntityState.Deleted or EntityState.Added or EntityState.Modified });

        var auditEntries = new List<AuditEntry>();
        var entityEntries = entities as EntityEntry[] ?? entities.ToArray();
        
        if (!entityEntries.Any()) return;
        
        var timestamp = DateTime.UtcNow;

        var user = currentUserService.GetCurrentUser().LoginName;
        
        foreach (var entry in entityEntries)
        {
            var entity = (IEntityBase)entry.Entity;
            var auditEntry = GetAuditEntry(entry, user);
            auditEntries.Add(auditEntry);
            
            switch (entry.State)
            {
                case EntityState.Added:
                    entity.CreatedDate = timestamp;
                    entity.CreatedBy = user;
                    entity.UpdatedDate = timestamp;
                    entity.UpdatedBy = user;
                    break;
                case EntityState.Modified:
                    entity.UpdatedDate = timestamp;
                    entity.UpdatedBy = user;
                    break;
                case EntityState.Deleted:
                    entity.UpdatedDate = timestamp;
                    entity.UpdatedBy = user;
                    entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                    break;
            }
        }

        var context = (HacettepeDbContext)changeTracker.Context;
        foreach (var auditEntry in auditEntries)
        {
            context.Audits.Add(auditEntry.ToAudit());
        }
    }

    private static AuditEntry GetAuditEntry(EntityEntry entry, string user)
    {
        var auditEntry = new AuditEntry(entry)
        {
            TableName = entry.Entity.GetType().Name,
            User = user
        };

        foreach (var property in entry.Properties)
        {
            var propertyName = property.Metadata.Name;
            if (property.Metadata.IsPrimaryKey())
            {
                auditEntry.KeyValues[propertyName] = property.CurrentValue;
                continue;
            }
            
            switch (entry.State)
            {
                case EntityState.Added:
                    auditEntry.AuditType = AuditType.Create;
                    auditEntry.NewValues[propertyName] = property.CurrentValue;
                    break;
                case EntityState.Deleted:
                    auditEntry.AuditType = AuditType.Delete;
                    auditEntry.OldValues[propertyName] = property.OriginalValue;
                    break;
                case EntityState.Modified:
                    if (property.IsModified)
                    {
                        auditEntry.ChangedColumns.Add(propertyName);
                        auditEntry.AuditType = AuditType.Update;
                        auditEntry.OldValues[propertyName] = property.OriginalValue;
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                    }
                    break;
            }
        }

        return auditEntry;
    }
}