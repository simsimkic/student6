using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.Abstract
{
    public interface ISecretaryRepository: IRepository<Secretary,long>
    {
        Secretary GetByEmail(string email);
    }
}
