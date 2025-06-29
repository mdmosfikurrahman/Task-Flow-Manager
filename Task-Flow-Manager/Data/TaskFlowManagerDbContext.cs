using Microsoft.EntityFrameworkCore;
using Task_Flow_Manager.Models;
using Task = Task_Flow_Manager.Models.Task;

namespace Task_Flow_Manager.Data;

public partial class TaskFlowManagerDbContext : DbContext
{
    public TaskFlowManagerDbContext()
    {
    }

    public TaskFlowManagerDbContext(DbContextOptions<TaskFlowManagerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> department { get; set; }

    public virtual DbSet<Project> project { get; set; }

    public virtual DbSet<Task> task { get; set; }

    public virtual DbSet<User> user { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=TaskFlowManager",
            ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ManagerId, "fk_project_manager");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Manager).WithMany(p => p.project)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("fk_project_manager");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.AssignedToId, "fk_task_assigned_user");

            entity.HasIndex(e => e.ProjectId, "fk_task_project");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.AssignedTo).WithMany(p => p.task)
                .HasForeignKey(d => d.AssignedToId)
                .HasConstraintName("fk_task_assigned_user");

            entity.HasOne(d => d.Project).WithMany(p => p.task)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("fk_task_project");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.DepartmentId, "fk_user_department");

            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(100);

            entity.HasOne(d => d.Department).WithMany(p => p.user)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("fk_user_department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}