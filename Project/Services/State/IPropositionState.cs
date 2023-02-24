using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Services.State
{
    public interface IPropositionState
    {
        Proposition Approve(Proposition proposition);
        Proposition Reject(Proposition proposition);
    }
}
