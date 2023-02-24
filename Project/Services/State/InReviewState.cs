using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;

namespace Project.Services.State
{
    class InReviewState : IPropositionState
    {
        IPropositionService _propositionService;
        IService<Approval, long> _approvalService;

        public InReviewState()
        {
        }

        public InReviewState(
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
            CurrentProposition.Approval.Add(proposition.Approval.Last());

            if (CurrentProposition.Approval.Count() >= 2)
            {
                CurrentProposition.State = "Approved";
                _propositionService.Update(CurrentProposition);
            }

            _approvalService.Save(proposition.Approval.Last());

            return CurrentProposition;
        }

        public Proposition Reject(Proposition proposition)
        {
            Proposition CurrentProposition = _propositionService.GetById(proposition.Id);

            CurrentProposition.Approval.Add(proposition.Approval.Last());
            CurrentProposition.State = "Rejected";
            _propositionService.Update(CurrentProposition);

            _approvalService.Save(proposition.Approval.Last());

            return CurrentProposition;
        }
    }
}
