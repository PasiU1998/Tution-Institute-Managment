using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProjectITP.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole,
        CustomUserClaim>
    {
        [Required]
        public string Name { get; set; }


        public int TelephoneNumber { get; set; }


        public string Address { get; set; }



        public bool IsStudent { get; set; }

        public bool  IsTeacher { get; set; }



        public int UserId { get; set; }

        public UserTypes UserTypes { get; set; }

        /*  [Required]
           public byte UserTypesId { get; set; } */


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
   
            UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }
    }




    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }



    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }



    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole,
     int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {


        public ApplicationDbContext()
    : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();

           

        }

       // public DbSet<Exam> Exam { get; set; }

        //public DbSet<ExamType> ExamType { get; set; }
                                          
        // public System.Data.Entity.DbSet<ProjectITP.Models.UserTypes> UserTypes { get; set; }

        // public System.Data.Entity.DbSet<ProjectITP.Models.Student> Student { get; set; }

        public System.Data.Entity.DbSet<ProjectITP.Models.Subject> Subject { get; set; }

    

        public System.Data.Entity.DbSet<ProjectITP.Models.ExamType> ExamType { get; set; }


        public System.Data.Entity.DbSet<ProjectITP.Models.SubjectFee> SubjectFee { get; set; }



        public System.Data.Entity.DbSet<ProjectITP.Models.MaterialTypes> MaterialTypes { get; set; }


        public System.Data.Entity.DbSet<ProjectITP.Models.NonAcadamicEmployee> NonAcadamicEmployees { get; set; }

        public System.Data.Entity.DbSet<ProjectITP.Models.TimeTable> TimeTables { get; set; }


        public System.Data.Entity.DbSet<ProjectITP.Models.Classroom> Classrooms { get; set; }


        public System.Data.Entity.DbSet<ProjectITP.Models.UtilityBills> UtilityBills { get; set; }


        public System.Data.Entity.DbSet<ProjectITP.Models.SubjectCategory> SubjectCategories { get; set; }

        public System.Data.Entity.DbSet<ProjectITP.Models.Exam> Exams { get; set; }


          public System.Data.Entity.DbSet<ProjectITP.Models.Material> Materials { get; set; }


        public System.Data.Entity.DbSet<ProjectITP.Models.AcadamicUserPayment> acadamicUserPayments { get; set; }



        public System.Data.Entity.DbSet<ProjectITP.Models.NonAcadamicPayment> nonAcadamicPayments { get; set; }



        public System.Data.Entity.DbSet<ProjectITP.Models.Profit> profits { get; set; }


        public System.Data.Entity.DbSet<ProjectITP.Models.ExamResult> ExamResult { get; set; }


        public System.Data.Entity.DbSet<ProjectITP.Models.Notification> notifications { get; set; }






        // public System.Data.Entity.DbSet<ProjectITP.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}