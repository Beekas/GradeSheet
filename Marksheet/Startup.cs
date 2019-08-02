using Marksheet.DAL;
using Microsoft.Owin;
using Marksheet.Models;
using Owin;
using System.Web.Helpers;
using System;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(Marksheet.Startup))]
namespace Marksheet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          //  ConfigureAuth(app);
            createUsers();
        }

        private void createUsers()
        {
            MarkSheetEntities context = new MarkSheetEntities();

            //  var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            // var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating  a default Admin User 

            var user = new Account();

            user.UserName = "school";
            user.FullName = "School";
            user.Email = "hsakib2051@gmail.com";
            user.Category = "SuperAdmin";
            user.Phone = "01-4220638";
            user.Password = Crypto.Hash("school");
            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            user.PPSizePhoto = "~/staticimg/school.jpg";
            user.Status = true;

            if (context.Accounts.ToList().Count == 0)
            {
                context.Accounts.Add(user);
                context.SaveChanges();
            }

            //string userPWD = "admin123";


            //var chkUser = UserManager.Create(user, userPWD);


        }
    }
}
