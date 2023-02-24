using System.Collections.Generic;
using Project.Model;

namespace Project.Services
{
    public interface IPropositionService : IService<Proposition,long>
    {
        Proposition Approve(Proposition proposition);
        Proposition Reject(Proposition proposition);
    }
}
