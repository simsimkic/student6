using Project.Repositories.Abstract;
using Project.Repositories.ManyToMany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.ManyToMany.Repositories.Abstract
{
    public interface IInventoryManagementToEquipmentRepository : IRepository<InventoryManagementToEquipment, long>
    {
    }
}
