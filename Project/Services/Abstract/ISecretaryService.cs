using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Abstract
{
    public interface ISecretaryService : IService<Secretary, long>
    {
        Secretary GetByEmail(string email);
    }
}
