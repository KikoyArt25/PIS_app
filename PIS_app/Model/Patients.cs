using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PIS_app.App;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;


namespace PIS_app.Model
{
    public class Patients
    {
        public string fullname { get; set; }
        public string sex { get; set; }
        public string age { get; set; }
        public string birthday { get; set; }
        public string address { get; set; }
        public string contactnumber { get; set; }
        public string conditionSta { get; set; }
        public string room { get; set; }


        public async Task<bool> AddPatient(string fname, string Psex , string Age,
            string Birthday, string Address, string contnum, string condition, string pRoom)
        {
            try
            {
                var evaluateEmail = (await patient.Child("Patients")
                    .OnceAsync<Patients>())
                    .FirstOrDefault(a => a.Object.fullname == fname);

                if (evaluateEmail == null)
                {
                    var patients = new Patients()
                    {
                        fullname = fname,
                        sex = Psex, 
                        age=Age,
                        birthday=Birthday,
                        address=Address,
                        contactnumber=contnum,
                        conditionSta=condition,
                        room=pRoom

                    };
                    await patient
                        .Child("Patients")
                        .PostAsync(patients);
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
        public async Task<bool> EditPatientData(string pAge,string Addresss, string contactnumbers, string ConditionStats, string wardroom)
        {
            try
            {
                var employeeAddress = (await patient
                    .Child("Patients")
                    .OnceAsync<Patients>())
                    .FirstOrDefault
                    (a => a.Object.fullname == name);
                if (employeeAddress != null)
                {
                    Patients Inpatient = new Patients
                    {
                        fullname = name,
                        birthday = birth,
                        address = Addresss,
                        contactnumber = contactnumbers,
                        room = wardroom,
                        sex = sexs,
                        conditionSta = ConditionStats,
                        age = pAge
                    };
                    await patient.Child("Patients").Child(key).PatchAsync(Inpatient);
                    patient.Dispose();
                }
                patient.Dispose();
                return false;
            }
            catch (Exception ex)
            {
                patient.Dispose();
                return false;
            }
        }

        public async Task<string> DeletePatientdata()
        {
            try
            {
                await patient
                    .Child($"Patients/{key}")
                    .DeleteAsync();
                return "removed";
            }
            catch (Exception ex)
            {
                return " error";
            }
        }


        public async Task<string> GetUserKey(string names)
        {
            try
            {
                var getuserkey = (await patient.Child("Patients").OnceAsync<Patients>()).
                    FirstOrDefault(a => a.Object.fullname == names);
                if (getuserkey == null) return null;
               
                sexs = getuserkey.Object.sex;
                ages = getuserkey.Object.age;
                birth = getuserkey.Object.birthday;
                addres = getuserkey.Object.address;
                contactNumb = getuserkey.Object.contactnumber;
                constatus = getuserkey.Object.conditionSta;
                rOom = getuserkey.Object.room;


                return getuserkey?.Key;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public ObservableCollection<Patients> GetPatientsList()
        {
            var Patientslist = patient
                 .Child("Patients")
                .AsObservable<Patients>()
                .AsObservableCollection();
            return Patientslist;

        }

    }
}
