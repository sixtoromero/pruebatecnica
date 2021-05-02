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
        public DbSet<Correspondence> Correspondences { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Insertando los roles por defecto            
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {      
                    Id = 1,
                    RolName = "Administrador"
                },
                new Rol
                {
                    Id = 2,
                    RolName = "Gestor"
                },
                new Rol
                {
                    Id = 3,
                    RolName = "Destinatario"
                }
            );

            //Insertando Usuario por defecto
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Names = "Sixto José",
                    Surnames = "Romero Martínez",
                    Username = "sixto.romero",
                    Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                    Email = "sixto.jose@gmail.com",
                    Status = "A",
                    RolId = 1,
                    Date = new DateTime()
                },
                new User
                {
                    Id = 2,
                    Names = "Manuel Antonio",
                    Surnames = "Mejía Gutierrez",
                    Username = "manuel.mejia",
                    Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                    Email = "manuel.mejia@gmail.com",
                    Status = "A",
                    RolId = 2,
                    Date = new DateTime()
                }
            );

            //Creando indices en las tablas principales.
            modelBuilder.Entity<User>()
                .HasIndex(user => new { user.Username });

            modelBuilder.Entity<Correspondence>()
                .HasIndex(message => new { message.Subject });

            //Especificando una llave primaria compuesta
            modelBuilder.Entity<Correspondence>().HasKey(x => new { x.Id, x.Consecutive });

        }

    }
}
