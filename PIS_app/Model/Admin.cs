using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using static PIS_app.App;

namespace PIS_app.Model
{
    public class Admin
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public async Task<bool> AddAdminis(string fname, string lname, string mail, string pword)
        {
            try
            {
                var evaluateEmail = (await patient.Child("Admin")
                    .OnceAsync<Admin>())
                    .FirstOrDefault(a => a.Object.Email == mail);

                if (evaluateEmail == null)
                {
                    var admins = new Admin()
                    {
                        FirstName = fname,
                        LastName = lname,
                        Email = mail,
                        Password = pword
                    };
                    await patient
                        .Child("Admin")
                        .PostAsync(admins);
                    patient.Dispose();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AdminisLogin(string email, string pass)
        {
            try
            {
                var evaluateEmail = (await patient.Child("Admin")
                                  .OnceAsync<Admin>())
                                  .FirstOrDefault
                                  (a => a.Object.Email == email &&
                                   a.Object.Password == pass);
                return evaluateEmail != null;
            }
            catch
            {
                return false;
            }

        }
    }
}
