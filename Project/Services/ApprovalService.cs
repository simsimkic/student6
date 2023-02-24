using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Repositories;
using Project.Repositories.Abstract;

namespace Project.Services
{

    public class ApprovalService : IService<Approval, long>
    {
        private readonly IApprovalRepository _approvalRepositoryy;

        public ApprovalService(IApprovalRepository approvalRepository)
        {
            _approvalRepositoryy = approvalRepository;
        }

        public IEnumerable<Approval> GetAll() 
            => _approvalRepositoryy.GetAll();

        public Approval GetById(long id) 
            => _approvalRepositoryy.GetById(id);

        public Approval Save(Approval approval) 
            => _approvalRepositoryy.Save(approval); 

        public Approval Update(Approval approval) 
            => _approvalRepositoryy.Update(approval);

        public Approval Remove(Approval approval) 
            => _approvalRepositoryy.Remove(approval);

    }
}