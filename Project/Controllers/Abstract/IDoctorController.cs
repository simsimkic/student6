using Project.Model;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers.Abstract
{
    public interface IDoctorController : IController<DoctorDTO,long>
    {
        DoctorDTO GetByEmail(string email);
    }
}
