using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CH.Smart.Dal2.UserModel
{
    //上下文表示与数据库的会话，并允许查询和保存实体类的实例
    public partial class SmartPower2_Dev3_UserContext : DbContext
    {
        public SmartPower2_Dev3_UserContext()
        {
        }

        public SmartPower2_Dev3_UserContext(DbContextOptions<SmartPower2_Dev3_UserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<BaseAccount> BaseAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning        To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=123.56.160.179,2478;initial catalog=SmartPower2_Dev3_User;user id=smartpowerdev5;password=smartpowerdev5179;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-preview3-35497");

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RefCount).HasColumnName("Ref_Count");

                entity.Property(e => e.UploadTime)
                    .HasColumnName("Upload_Time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<BaseAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("Base_Account");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.AccountEmail)
                    .HasColumnName("Account_Email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountIcon)
                    .HasColumnName("Account_Icon")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AccountName)
                    .HasColumnName("Account_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.AccountPasswd)
                    .IsRequired()
                    .HasColumnName("Account_Passwd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountPhone)
                    .HasColumnName("Account_Phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType).HasColumnName("Account_Type");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Update).HasColumnType("datetime");

                entity.Property(e => e.Upload).HasColumnType("datetime");
            });
        }
    }
}
