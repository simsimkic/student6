using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Abstract
{
    public interface IPatientService : IService<Patient, long>
    {

        Patient GetByEmail(string email);
        Patient ClaimGuestAccount(Guest guest, string email, string password);
    }
}
