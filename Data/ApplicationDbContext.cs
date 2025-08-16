using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EduFitMart.Models;
using EduFitMart.Models.School;
using EduFitMart.Models.Fitness;
using EduFitMart.Models.ECommerce;
using EduFitMart.Models.Integration;

namespace EduFitMart.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // School Management Entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        // Fitness Tracker Entities
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<ExerciseEquipment> ExerciseEquipments { get; set; }
        public DbSet<StudentWorkout> StudentWorkouts { get; set; }

        // E-Commerce Entities
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // School Management Relationships
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            // Fitness Tracker Relationships
            modelBuilder.Entity<ExerciseEquipment>()
                .HasKey(ee => new { ee.ExerciseId, ee.EquipmentId });

            modelBuilder.Entity<ExerciseEquipment>()
                .HasOne(ee => ee.Exercise)
                .WithMany(e => e.ExerciseEquipments)
                .HasForeignKey(ee => ee.ExerciseId);

            modelBuilder.Entity<ExerciseEquipment>()
                .HasOne(ee => ee.Equipment)
                .WithMany(e => e.ExerciseEquipments)
                .HasForeignKey(ee => ee.EquipmentId);

            modelBuilder.Entity<WorkoutExercise>()
                .HasKey(we => new { we.WorkoutId, we.ExerciseId });

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Workout)
                .WithMany(w => w.WorkoutExercises)
                .HasForeignKey(we => we.WorkoutId);

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Exercise)
                .WithMany(e => e.WorkoutExercises)
                .HasForeignKey(we => we.ExerciseId);

            // E-Commerce Relationships
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Vendor)
                .WithMany(v => v.Products)
                .HasForeignKey(p => p.VendorId);

            // Student-Workout Relationship (M:M)
            modelBuilder.Entity<StudentWorkout>()
                .HasKey(sw => new { sw.StudentId, sw.WorkoutId });

            modelBuilder.Entity<StudentWorkout>()
                .HasOne(sw => sw.Student)
                .WithMany(s => s.StudentWorkouts)
                .HasForeignKey(sw => sw.StudentId);

            modelBuilder.Entity<StudentWorkout>()
                .HasOne(sw => sw.Workout)
                .WithMany(w => w.StudentWorkouts)
                .HasForeignKey(sw => sw.WorkoutId);

            // Student-Order Relationship (1:M)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Student)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StudentId);
        }
        public DbSet<EduFitMart.Models.School.Course> Course { get; set; } = default!;
    }
}