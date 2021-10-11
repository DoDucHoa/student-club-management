using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FClub.Data.Database
{
    public partial class ClubManagementDBContext : DbContext
    {
        public ClubManagementDBContext()
        {
        }

        public ClubManagementDBContext(DbContextOptions<ClubManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<EventInfo> EventInfos { get; set; }
        public virtual DbSet<EventTicket> EventTickets { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MemberTask> MemberTasks { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskType> TaskTypes { get; set; }
        public virtual DbSet<TicketType> TicketTypes { get; set; }
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=club-management.database.windows.net,1433;Database=ClubManagementDB;User Id=admin123;Password=Sa123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");

                entity.HasIndex(e => e.Id, "i");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.About)
                    .HasMaxLength(3000)
                    .HasColumnName("about");

                entity.Property(e => e.Balance)
                    .HasColumnType("numeric(19, 5)")
                    .HasColumnName("balance");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("logo");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.UniversityId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("university_id");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClubUniversity");
            });

            modelBuilder.Entity<EventInfo>(entity =>
            {
                entity.ToTable("EventInfo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BeginDate)
                    .HasColumnType("date")
                    .HasColumnName("begin_date");

                entity.Property(e => e.BonusPoint)
                    .HasColumnType("numeric(19, 5)")
                    .HasColumnName("bonus_point");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(3000)
                    .HasColumnName("content");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("due_date");

                entity.Property(e => e.EndRegisDate)
                    .HasColumnType("date")
                    .HasColumnName("end_regis_date");

                entity.Property(e => e.Image)
                    .HasMaxLength(256)
                    .HasColumnName("image");

                entity.Property(e => e.LimitJoin).HasColumnName("limit_join");

                entity.Property(e => e.Location)
                    .HasMaxLength(256)
                    .HasColumnName("location");

                entity.Property(e => e.RegisDate)
                    .HasColumnType("date")
                    .HasColumnName("regis_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("title");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.EventInfos)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventUser");
            });

            modelBuilder.Entity<EventTicket>(entity =>
            {
                entity.ToTable("EventTicket");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ParticipantId).HasColumnName("participant_id");

                entity.Property(e => e.TicketTypeId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ticket_type_id");

                entity.HasOne(d => d.Participant)
                    .WithMany(p => p.EventTickets)
                    .HasForeignKey(d => d.ParticipantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventTicketEvent");

                entity.HasOne(d => d.TicketType)
                    .WithMany(p => p.EventTickets)
                    .HasForeignKey(d => d.TicketTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventTicketTicketType");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClubId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("club_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberClub");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberUserInfo");
            });

            modelBuilder.Entity<MemberTask>(entity =>
            {
                entity.ToTable("MemberTask");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AwardPoint)
                    .HasColumnType("numeric(19, 5)")
                    .HasColumnName("award_point");

                entity.Property(e => e.CompleteDate)
                    .HasColumnType("date")
                    .HasColumnName("complete_date");

                entity.Property(e => e.Evidence)
                    .HasMaxLength(256)
                    .HasColumnName("evidence");

                entity.Property(e => e.IsFinish).HasColumnName("isFinish");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.TaskId).HasColumnName("task_id");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberTasks)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberTaskUserInfo");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.MemberTasks)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberTaskIdInfo");
            });

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.ToTable("Participant");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attendance).HasColumnName("attendance");

                entity.Property(e => e.BonusPoint)
                    .HasColumnType("numeric(19, 5)")
                    .HasColumnName("bonus_point");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.RegisDate)
                    .HasColumnType("date")
                    .HasColumnName("regis_date");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParticipantEvent");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParticipantUser");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.HasIndex(e => e.Id, "i");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AwardPoint)
                    .HasColumnType("numeric(19, 5)")
                    .HasColumnName("award_point");

                entity.Property(e => e.BeginDate)
                    .HasColumnType("date")
                    .HasColumnName("begin_date");

                entity.Property(e => e.Content)
                    .HasMaxLength(3000)
                    .HasColumnName("content");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnName("due_date");

                entity.Property(e => e.LimitJoin).HasColumnName("limit_join");

                entity.Property(e => e.PennaltyPoint)
                    .HasColumnType("numeric(19, 5)")
                    .HasColumnName("pennalty_point");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("title");

                entity.Property(e => e.TypeId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("type_id");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskUser");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskTaskType");
            });

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.ToTable("TaskType");

                entity.HasIndex(e => e.Id, "i");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TicketType>(entity =>
            {
                entity.ToTable("TicketType");

                entity.HasIndex(e => e.Id, "i");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.BonusPoint)
                    .HasColumnType("numeric(19, 5)")
                    .HasColumnName("bonus_point")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(19, 5)")
                    .HasColumnName("price")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.ToTable("TransactionDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasMaxLength(256)
                    .HasColumnName("content")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransPoint)
                    .HasColumnType("numeric(19, 5)")
                    .HasColumnName("trans_point")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WalletId).HasColumnName("wallet_id");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionDetailUserInfo");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.ToTable("University");

                entity.HasIndex(e => e.Id, "i");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(256)
                    .HasColumnName("address");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("logo");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.ToTable("UserInfo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bio)
                    .HasMaxLength(3000)
                    .HasColumnName("bio");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasColumnName("birthday");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("email");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Photo)
                    .HasMaxLength(256)
                    .HasColumnName("photo");

                entity.Property(e => e.UniversityId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("university_id");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInfoUniversity");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("Wallet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MemberId).HasColumnName("member_id");

                entity.Property(e => e.Point)
                    .HasColumnType("numeric(19, 5)")
                    .HasColumnName("point")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Wallets)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WalletUserInfo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
