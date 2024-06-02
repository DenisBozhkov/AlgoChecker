using Business.Entity;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class AlgoCheckerContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<CheckAttributeEntity> CheckAttributest;
        public DbSet<SolutionTestEntity> SolutionTests;
        public DbSet<TaskEntity> Tasks;
        public DbSet<UserEntity> Users;
        public DbSet<TemplateAttributeEntity> TemplateAttributes;
        public DbSet<TestCaseEntity> TestCases;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasMany<SolutionTestEntity>()
                .WithOne(solutionTest => solutionTest.User);
            modelBuilder.Entity<TaskEntity>()
                .HasMany<TestCaseEntity>()
                .WithOne(testCase => testCase.Task);
            modelBuilder.Entity<TaskEntity>()
                .HasMany<SolutionTestEntity>()
                .WithOne(solutionTest => solutionTest.Task);
            modelBuilder.Entity<TaskEntity>()
                .HasMany(task => task.Input)
                .WithOne(attribute => attribute.InputTask);
            modelBuilder.Entity<TaskEntity>()
                .HasMany(task => task.Output)
                .WithOne(attribute => attribute.OutputTask);
            modelBuilder.Entity<TestCaseEntity>()
                .HasMany(task => task.InputAttributes)
                .WithOne(attribute => attribute.InputTestCase);
            modelBuilder.Entity<TestCaseEntity>()
                .HasMany(task => task.OutputAttributes)
                .WithOne(attribute => attribute.OutputTestCase);
        }
    }
}
