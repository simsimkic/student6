using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Services
{
    public interface IMedicineService : IService<Medicine, long>
    {
        Medicine GetByName(string name);
        Medicine RegisternMedicine(string name, string type, string administration, string purpose, string description);
    }
}
