using JobSearchAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace JobSearchAPI.Data
{
    public class DataBaseContext:DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<JobDetailsDto> JobDetails { get; set; }
        public DbSet<JobSearchDto> JobSearches { get; set; }
        public DbSet<UserDetailsDto> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<UserDetailsDto>()
                .HasMany(x => x.JobDetails)
                .WithOne(x => x.UserDetails)
                .HasForeignKey(x => x.UserId);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(
        //    //    connectionString: ""
        //    //);
        //}
    }
}



//{
//    modelBuilder.Entity<UserDetailsDto>()
//        .HasMany(x => x.JobDetails)
//        .WithOne(x => x.UserDetails)
//        .HasForeignKey(x => x.UserId);
//}
