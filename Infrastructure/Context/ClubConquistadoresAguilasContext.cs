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

    public virtual DbSet<ClassPerson> ClassPeople { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PositionPersonActivity> PositionPersonActivities { get; set; }

    public virtual DbSet<PositionPersonUnit> PositionPersonUnits { get; set; }

    public virtual DbSet<RolPermission> RolPermissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<SpecialtyPerson> SpecialtyPeople { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPermission> UserPermissions { get; set; }

    public virtual DbSet<UserRol> UserRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClubId).HasColumnName("ClubID");
            entity.Property(e => e.ConcurrencyActivity)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyActivity");
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
            entity.Property(e => e.ConcurrencyCategory)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyCategory");
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
            entity.Property(e => e.ConcurrencyClass)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyClass");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ClassPerson>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, e.ClassId });

            entity.ToTable("ClassPerson");

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.ConcurrencyCp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyCP");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassPeople)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClassPerson_Class");

            entity.HasOne(d => d.Person).WithMany(p => p.ClassPeople)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClassPerson_Person");
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
            entity.Property(e => e.ConcurrencyClub)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyClub");
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
            entity.Property(e => e.ConcurrencyPermission)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyPermission");
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
            entity.Property(e => e.ConcurrencyPerson)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyPerson");
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
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.ConcurrencyPosition)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyPosition");
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
            entity.Property(e => e.ConcurrencyPpa)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyPPA");
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
            entity.Property(e => e.ConcurrencyPpu)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyPPU");
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

        modelBuilder.Entity<RolPermission>(entity =>
        {
            entity.HasKey(e => new { e.RolId, e.PermissionId });

            entity.ToTable("RolPermission");

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.ConcurrencyRp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyRP");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolPermission_Permission");

            entity.HasOne(d => d.Rol).WithMany(p => p.RolPermissions)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolPermission_Rol");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.ConcurrencyRole)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyRole");
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

        modelBuilder.Entity<Specialty>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ConcurrencySpecialty)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencySpecialty");
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

        modelBuilder.Entity<SpecialtyPerson>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, e.SpecialtyId });

            entity.ToTable("SpecialtyPerson");

            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");
            entity.Property(e => e.ConcurrencySp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencySP");

            entity.HasOne(d => d.Person).WithMany(p => p.SpecialtyPeople)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpecialtyPerson_Person");

            entity.HasOne(d => d.Specialty).WithMany(p => p.SpecialtyPeople)
                .HasForeignKey(d => d.SpecialtyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpecialtyPerson_Specialty");
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
            entity.Property(e => e.ConcurrencyUnit)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyUnit");
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
            entity.Property(e => e.ConcurrencyUser)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyUser");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
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
        });

        modelBuilder.Entity<UserPermission>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.PermissionId });

            entity.ToTable("UserPermission");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.PermissionId).HasColumnName("PermissionID");
            entity.Property(e => e.ConcurrencyUp)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyUP");

            entity.HasOne(d => d.Permission).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPermission_Permission");

            entity.HasOne(d => d.User).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPermission_User");
        });

        modelBuilder.Entity<UserRol>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RolId });

            entity.ToTable("UserRol");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.ConcurrencyUr)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("concurrencyUR");

            entity.HasOne(d => d.Rol).WithMany(p => p.UserRols)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRol_Rol");

            entity.HasOne(d => d.User).WithMany(p => p.UserRols)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRol_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
