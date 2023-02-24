using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Services.State
{
    class RejectedState : IPropositionState
    {
        IPropositionService _propositionService;
        IService<Approval, long> _approvalService;

        public RejectedState()
        {
        }

        public RejectedState(
            IPropositionService propositionService,
            IService<Approval, long> approvalService
            )
        {
            _approvalService = approvalService;
            _propositionService = propositionService;
        }

        public Proposition Approve(Proposition proposition)
        {
            Proposition CurrentProposition = _propositionService.GetById(proposition.Id);
            return CurrentProposition;
        }

        public Proposition Reject(Proposition proposition)
        {
            Proposition CurrentProposition = _propositionService.GetById(proposition.Id);
            return CurrentProposition;
        }
    }
}
