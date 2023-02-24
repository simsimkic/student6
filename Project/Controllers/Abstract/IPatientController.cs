using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers.Abstract
{
    public interface IPatientController : IController<PatientDTO, long>
    {
        PatientDTO GetByEmail(string email);
        PatientDTO ClaimGuestAccount(GuestDTO guest, string email, string password);
    }
}
