using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practice_App.Startup))]
namespace Practice_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        / In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers()   
        {   
            ApplicationDbContext context = new ApplicationDbContext();   
   
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));   
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));   
   
   
            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))   
            {   
   
                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();   
                role.Name = "Admin";   
                roleManager.Create(role);   
   
                //Here we create a Admin super user who will maintain the website                  
   
                var user = new ApplicationUser();   
                user.UserName = "Moldav";   
                user.Email = "dionisbolun@gmai.com";   
   
                string userPWD = "3532876pa";   
   
                var chkUser = UserManager.Create(user, userPWD);   
   
                //Add default User to Role Admin   
                if (chkUser.Succeeded)   
                {   
                    var result1 = UserManager.AddToRole(user.Id, "Admin");   
   
                }   
            }   
   
            // creating Creating Conducator role    
            if (!roleManager.RoleExists("Conducator"))   
            {   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();   
                role.Name = "Conducator";   
                roleManager.Create(role);   
   
            }   
   
            // creating Creating Student role    
            if (!roleManager.RoleExists("Student"))   
            {   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();   
                role.Name = "Student";   
                roleManager.Create(role);   
   
            }   
        } 
    }
}
