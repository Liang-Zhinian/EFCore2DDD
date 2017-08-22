﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data {
  public class SamuraiContext : DbContext {

    public SamuraiContext (DbContextOptions<SamuraiContext> options) : base (options) { }
    public SamuraiContext () { }
    public DbSet<Samurai> Samurais { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
     // optionsBuilder.UseSqlite ("Filename=DP0917Samurai.db");
      optionsBuilder.UseInMemoryDatabase("onedb");
      base.OnConfiguring (optionsBuilder);
    }
    protected override void OnModelCreating (ModelBuilder modelBuilder) {

      //Note that we need to configure the model
      //to know about private entrance 
      //before running the code that depends on GetEntityTypes

      modelBuilder.Entity<Samurai> ()
        .HasOne (typeof (Entrance), "Entrance")
        .WithOne ().HasForeignKey(typeof (Entrance), "SamuraiFk");

      foreach (var entityType in modelBuilder.Model.GetEntityTypes ()) {
        //LastModified is a shadow property, not props in the classes
        modelBuilder.Entity (entityType.Name).Property<DateTime> ("LastModified");
        //IsDirty is for local tracking, not persisted in the database
        modelBuilder.Entity (entityType.Name).Ignore ("IsDirty");
      }
      //NOTE: owned entity needs to go after the GetEntityTypes or it will be seen as an entity
      modelBuilder.Entity<Samurai> ().OwnsOne (typeof (PersonFullName), "SecretIdentity");

    }

    public override int SaveChanges () {
      foreach (var entry in ChangeTracker.Entries ()
        .Where (e => e.State == EntityState.Added ||
          e.State == EntityState.Modified)) {
        //ignore owned entities (todo: is there a generic way?)
        if (!(entry.Entity is PersonFullName))
          entry.Property ("LastModified").CurrentValue = DateTime.Now;
      }
      return base.SaveChanges ();
    }
  }
}