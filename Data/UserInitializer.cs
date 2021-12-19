using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data
{
    public class UserInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UserCvContext>
    {
        protected override void Seed(UserCvContext ctx)
        {
            var users = new List<User>
            {
                new User
                {
                    UserName = "albin", Password = "1234", ImagePath = "hfuefe", Address = "hejsanvägen",
                    PrivateUser = false, PhoneNumber = "12345", Email = "albin.preis"
                },
                new User
                {
                    UserName = "amanda", Password = "1234", ImagePath = "hfuefe", Address = "hejsanvägen2",
                    PrivateUser = false, PhoneNumber = "123456", Email = "amanda"
                },
                new User
                {
                    UserName = "vilma", Password = "1234", ImagePath = "hfuefe", Address = "hejsanvägen3",
                    PrivateUser = false, PhoneNumber = "12345", Email = "vilma"
                }
            };
            users.ForEach(u => ctx.Users.Add(u));
            ctx.SaveChanges();

            var cvs = new List<CV>
            {
                new CV {UserId = 1, Competence = "bra"},
                new CV {UserId = 2, Competence = "duktig"},
                new CV {UserId = 3, Competence = "dålig"},
            };
            cvs.ForEach(c => ctx.Cvs.Add(c));
            ctx.SaveChanges();

        }
    }
}
