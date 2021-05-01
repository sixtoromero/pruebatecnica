using ALPHA.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ALPHA.InfraStructure.DAL
{
    public class ALPHADataContext : DbContext
    {        
        public ALPHADataContext([NotNullAttribute] DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolPermission> RolPermissions { get; set; }
        public DbSet<Correspondence> Correspondences { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }      

    }
}
