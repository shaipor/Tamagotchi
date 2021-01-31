using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TamaguchiBL.Models
{
    public partial class TamagotchiContext : DbContext
    {
        public TamagotchiContext()
        {
        }

        public TamagotchiContext(DbContextOptions<TamagotchiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionTypes> ActionTypes { get; set; }
        public virtual DbSet<Actions> Actions { get; set; }
        public virtual DbSet<ActionsHistory> ActionsHistory { get; set; }
        public virtual DbSet<LifeCycles> LifeCycles { get; set; }
        public virtual DbSet<PetStatus> PetStatus { get; set; }
        public virtual DbSet<Pets> Pets { get; set; }
        public virtual DbSet<Players> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionTypes>(entity =>
            {
                entity.HasKey(e => e.ActionTypeId)
                    .HasName("PK__ActionTy__62FE4C64F610729C");

                entity.Property(e => e.ActionTypeId).ValueGeneratedNever();

                entity.Property(e => e.ActionTypeName).IsUnicode(false);
            });

            modelBuilder.Entity<Actions>(entity =>
            {
                entity.HasKey(e => e.ActionId)
                    .HasName("PK__Actions__FFE3F4D9A0D0E777");

                entity.Property(e => e.ActionId).ValueGeneratedNever();

                entity.Property(e => e.ActionName).IsUnicode(false);

                entity.HasOne(d => d.ActionType)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.ActionTypeId)
                    .HasConstraintName("FK_Actions_ActionTypes");
            });

            modelBuilder.Entity<ActionsHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId)
                    .HasName("PK__ActionsH__4D7B4ABDD84686D2");

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ActionsHistory)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionsHistory_Actions");

                entity.HasOne(d => d.LifeCycle)
                    .WithMany(p => p.ActionsHistory)
                    .HasForeignKey(d => d.LifeCycleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionsHistory_LifeCycles");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.ActionsHistory)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionsHistory_Pets");
            });

            modelBuilder.Entity<LifeCycles>(entity =>
            {
                entity.HasKey(e => e.LifeCycleId)
                    .HasName("PK__LifeCycl__F6EC48D64C5B1768");

                entity.Property(e => e.LifeCycleId).ValueGeneratedNever();

                entity.Property(e => e.CycleName).IsUnicode(false);
            });

            modelBuilder.Entity<PetStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__AnimalSt__C8EE20639BB7D8A8");

                entity.Property(e => e.StatusId).ValueGeneratedNever();

                entity.Property(e => e.StatusName).IsUnicode(false);
            });

            modelBuilder.Entity<Pets>(entity =>
            {
                entity.HasKey(e => e.PetId)
                    .HasName("PK__Pets__48E5386244510831");

                entity.Property(e => e.PetName).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pets_PetStatus");

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pets_Players");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__Players__C9F2845744B26AE4");

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Mail).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
