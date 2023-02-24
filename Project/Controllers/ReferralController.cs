using Project.Model;
using Project.Services;
using Project.Services.Factory;
using Project.Views.Converters;
using Project.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class ReferralController : IController<Referral, long>
    {
        private IReferralFactory _factory;
        private IConverter<Referral, ReferralDTO> _referralConverter;

        public ReferralController(
            IReferralFactory factory,
            IConverter<Referral, ReferralDTO> referralConverter
            )
        {
            _factory = factory;
            _referralConverter = referralConverter;
        }
        public IEnumerable<Referral> GetAll()
        {
            throw new NotImplementedException();
        }

        public Referral GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Referral Remove(Referral entity)
        {
            throw new NotImplementedException();
        }

        public Referral Save(Referral entity)
        {
            throw new NotImplementedException();
        }

        public Referral Update(Referral entity)
        {
            throw new NotImplementedException();
        }
    }
}
