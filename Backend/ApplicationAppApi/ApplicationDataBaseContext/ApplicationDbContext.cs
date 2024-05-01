using ApplicationAppApi.Models.Applicant;
using ApplicationAppApi.Models.Application;
using ApplicationAppApi.Models.Supervisor;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplicationAppApi.ApplicationDataBaseContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        
        public DbSet<ApplicantModel> Applicants { get; set; }
        public DbSet<ApplicationModel> Applications { get; set; }
        public DbSet<SupervisorModel> SupervisorsOrder { get; set; }
                
        
    } 
}
