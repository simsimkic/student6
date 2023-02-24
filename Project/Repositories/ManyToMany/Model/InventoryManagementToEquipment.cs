using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repositories.Abstract;

namespace Project.Repositories.ManyToMany.Model
{
    public class InventoryManagementToEquipment : IIdentifiable<long>
    {

        public long Id;
        public long InventoryManagementId { get; set; }
        public long EquipmentId { get; set; }
        public InventoryManagementToEquipment(long id, long inventoryManagementId, long equipmentId)
        { 
            Id = id;
            InventoryManagementId = inventoryManagementId;
            EquipmentId = equipmentId;
        }
        public InventoryManagementToEquipment(long inventoryManagmentId, long equipmentId)
        { 
            InventoryManagementId = inventoryManagmentId;
            EquipmentId = equipmentId;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

    }
}
