using Project.Repositories.Abstract;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.Referral
{
    public interface IReferralRepository : IRepository<Project.Model.Referral, long>
    {
    }
}
