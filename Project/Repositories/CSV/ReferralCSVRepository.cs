using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repositories.Abstract;
using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Project.Repositories.CSV
{
    public class ReferralCSVRepository<E, O, ID>
        where E : IIdentifiable<ID>
        where O : IIdentifiable<ID>
        where ID : IComparable
    {
        private const string NOT_FOUND_ERROR = "{0} with {1}:{2} can not be found!";

        protected string _entityName = "Referral";
        protected ICSVStream<E> _stream;
        protected ICSVStream<Model.Referral> _admitionReferralStream;
        protected ICSVStream<Model.Referral> _operationReferralStream;
        protected ICSVStream<Model.Referral> _examReferralStream;

        protected LongSequencer _sequencer;

        public ReferralCSVRepository(
            ICSVStream<E> stream,
            ICSVStream<Model.Referral> admitionReferralStream,
            ICSVStream<Model.Referral> operationReferralStream,
            ICSVStream<Model.Referral> examReferralStream,
            LongSequencer sequencer
            )
        {
            _stream = stream;
            _admitionReferralStream = admitionReferralStream;
            _operationReferralStream = operationReferralStream;
            _examReferralStream = examReferralStream;
            _sequencer = sequencer;
            InitializeId();
        }
        public IEnumerable<E> GetAll() => _stream.ReadAll();
        protected void InitializeId()
        {
            var admitionReferrals = _admitionReferralStream.ReadAll();
            var operationReferrals = _operationReferralStream.ReadAll();
            var secretaries = _examReferralStream.ReadAll();

            List<long> ids = (List<long>) admitionReferrals.Select(item => (item as Model.Referral).Id).ToList();
            ids.AddRange(operationReferrals.Select(item => (item as Model.Referral).Id).ToList());
            ids.AddRange(secretaries.Select(item => (item as Model.Referral).Id).ToList());

            _sequencer.Initialize(ids.Max());

        }

        public E Save(E entity)
        {
            InitializeId();
            entity.SetId((ID)Convert.ChangeType(_sequencer.GenerateId(), typeof(ID)));
            _stream.AppendToFile(entity);
            return entity;
        }

        public IEnumerable<E> Find(Func<E, bool> predicate)
            => _stream
            .ReadAll()
            .Where(predicate);


        public E GetById(long id)
        {
            try
            {
                return _stream
                    .ReadAll()
                    .SingleOrDefault(entity => entity.GetId().CompareTo(id) == 0);
            }
            catch (ArgumentException)
            {
                throw new Exception(string.Format(NOT_FOUND_ERROR, _entityName, "id", id));
            }
        }

        public E Remove(E entity)
        {
            var entities = _stream.ReadAll().ToList();
            var entityToRemove = entities.SingleOrDefault(ent => ent.GetId().CompareTo(entity.GetId()) == 0);
            if (entityToRemove != null)
            {
                entities.Remove(entityToRemove);
                _stream.SaveAll(entities);
                return entityToRemove;
            }
            else
            {
                ThrowEntityNotFoundException("id", entity.GetId());
            }
            return default;
        }

        private void ThrowEntityNotFoundException(string key, object value)
          => throw new Exception(string.Format(NOT_FOUND_ERROR, _entityName, key, value));

        public E Update(E entity)
        {
            try
            {
                var entities = _stream.ReadAll().ToList();
                entities[entities.FindIndex(ent => ent.GetId().CompareTo(entity.GetId()) == 0)] = entity;
                _stream.SaveAll(entities);
                return entity;
            }
            catch (ArgumentException)
            {
                ThrowEntityNotFoundException("id", entity.GetId());
                return default;
            }
        }
    }
}
