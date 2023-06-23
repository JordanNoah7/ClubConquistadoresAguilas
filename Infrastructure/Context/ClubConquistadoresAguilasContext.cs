using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure.Context;

public partial class ClubConquistadoresAguilasContext : DbContext
{
    public ClubConquistadoresAguilasContext()
    {
    }

    public ClubConquistadoresAguilasContext(DbContextOptions<ClubConquistadoresAguilasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PositionPersonActivity> PositionPersonActivities { get; set; }

    public virtual DbSet<PositionPersonUnit> PositionPersonUnits { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClubId).HasColumnName("ClubID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("endDate");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Requirements)
                .HasMaxLength(250)
                .HasColumnName("requirements");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("startDate");

            entity.HasOne(d => d.Club).WithMany(p => p.Activities)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Club_Activities");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .HasColumnName("country");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.District)
                .HasMaxLength(20)
                .HasColumnName("district");
            entity.Property(e => e.FoundationDate)
                .HasColumnType("date")
                .HasColumnName("foundationDate");
            entity.Property(e => e.MeetingDay)
                .HasMaxLength(10)
                .HasColumnName("meetingDay");
            entity.Property(e => e.MeetingHour)
                .HasPrecision(0)
                .HasColumnName("meetingHour");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.Region)
                .HasMaxLength(20)
                .HasColumnName("region");
            entity.Property(e => e.Stars).HasColumnName("stars");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.CreationDate)
                .HasColumnType("date")
                .HasColumnName("creationDate");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .HasColumnName("address");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birthDate");
            entity.Property(e => e.ClubId).HasColumnName("ClubID");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.FathersSurname)
                .HasMaxLength(15)
                .HasColumnName("fathersSurname");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.MothersSurname)
                .HasMaxLength(15)
                .HasColumnName("mothersSurname");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");

            entity.HasOne(d => d.Club).WithMany(p => p.People)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Club_People");

            entity.HasOne(d => d.PersonNavigation).WithMany(p => p.InversePersonNavigation)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_Parent_Child");

            entity.HasMany(d => d.Classes).WithMany(p => p.People)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassPerson",
                    r => r.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ClassPerson_Class"),
                    l => l.HasOne<Person>().WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ClassPerson_Person"),
                    j =>
                    {
                        j.HasKey("PersonId", "ClassId");
                        j.ToTable("ClassPerson");
                        j.IndexerProperty<int>("PersonId").HasColumnName("PersonID");
                        j.IndexerProperty<byte>("ClassId").HasColumnName("ClassID");
                    });

            entity.HasMany(d => d.Specialties).WithMany(p => p.People)
                .UsingEntity<Dictionary<string, object>>(
                    "SpecialtyPerson",
                    r => r.HasOne<Specialty>().WithMany()
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_SpecialtyPerson_Specialty"),
                    l => l.HasOne<Person>().WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_SpecialtyPerson_Person"),
                    j =>
                    {
                        j.HasKey("PersonId", "SpecialtyId");
                        j.ToTable("SpecialtyPerson");
                        j.IndexerProperty<int>("PersonId").HasColumnName("PersonID");
                        j.IndexerProperty<short>("SpecialtyId").HasColumnName("SpecialtyID");
                    });
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PositionPersonActivity>(entity =>
        {
            entity.HasKey(e => new { e.ActivityId, e.PersonId });

            entity.ToTable("PositionPersonActivity");

            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.PositionId).HasColumnName("PositionID");

            entity.HasOne(d => d.Activity).WithMany(p => p.PositionPersonActivities)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionPersonActivity_Activity");

            entity.HasOne(d => d.Person).WithMany(p => p.PositionPersonActivities)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionPersonActivity_Person");

            entity.HasOne(d => d.Position).WithMany(p => p.PositionPersonActivities)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionPersonActivity_Position");
        });

        modelBuilder.Entity<PositionPersonUnit>(entity =>
        {
            entity.HasKey(e => new { e.UnitId, e.PersonId });

            entity.ToTable("PositionPersonUnit");

            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.PositionId).HasColumnName("PositionID");

            entity.HasOne(d => d.Person).WithMany(p => p.PositionPersonUnits)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionPersonUnit_Person");

            entity.HasOne(d => d.Position).WithMany(p => p.PositionPersonUnits)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionPersonUnit_Position");

            entity.HasOne(d => d.Unit).WithMany(p => p.PositionPersonUnits)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionPersonUnit_Unit");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.CreationDate)
                .HasColumnType("date")
                .HasColumnName("creationDate");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");

            entity.HasMany(d => d.Permissions).WithMany(p => p.Rols)
                .UsingEntity<Dictionary<string, object>>(
                    "RolPermission",
                    r => r.HasOne<Permission>().WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RolPermission_Permission"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RolPermission_Rol"),
                    j =>
                    {
                        j.HasKey("RolId", "PermissionId");
                        j.ToTable("RolPermission");
                        j.IndexerProperty<byte>("RolId").HasColumnName("RolID");
                        j.IndexerProperty<byte>("PermissionId").HasColumnName("PermissionID");
                    });
        });

        modelBuilder.Entity<Specialty>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.Requirements)
                .HasMaxLength(1000)
                .HasColumnName("requirements");

            entity.HasOne(d => d.Category).WithMany(p => p.Specialties)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category_Specialties");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.BattleCry)
                .HasMaxLength(250)
                .HasColumnName("battleCry");
            entity.Property(e => e.ClubId).HasColumnName("ClubID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Motto)
                .HasMaxLength(100)
                .HasColumnName("motto");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");

            entity.HasOne(d => d.Club).WithMany(p => p.Units)
                .HasForeignKey(d => d.ClubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Club_Units");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreationDate)
                .HasColumnType("date")
                .HasColumnName("creationDate");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(15)
                .HasColumnName("userName");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_User");

            entity.HasMany(d => d.Permissions).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserPermission",
                    r => r.HasOne<Permission>().WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserPermission_Permission"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserPermission_User"),
                    j =>
                    {
                        j.HasKey("UserId", "PermissionId");
                        j.ToTable("UserPermission");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<byte>("PermissionId").HasColumnName("PermissionID");
                    });

            entity.HasMany(d => d.Rols).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRol",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRol_Rol"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRol_User"),
                    j =>
                    {
                        j.HasKey("UserId", "RolId");
                        j.ToTable("UserRol");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<byte>("RolId").HasColumnName("RolID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public IEnumerable<User> GetUsersByCriteria(string criteria)
    {
        return Set<User>().FromSqlRaw("EXEC YourStoredProcedure @criteria", parameters:new SqlParameter("@criteria", criteria));
    }
}