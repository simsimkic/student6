using Project.Model;
using Project.Repositories.Abstract;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories.CSV
{
    public class UserCSVRepository<E, O, ID>
        where E : IIdentifiable<ID>
        where O : IIdentifiable<ID>
        where ID : IComparable
    {
        private const string NOT_FOUND_ERROR = "{0} with {1}:{2} can not be found!";

        protected string _entityName = "User";
        protected ICSVStream<E> _stream;
        protected ICSVStream<Patient> _patientStream;
        protected ICSVStream<Doctor> _doctorStream;
        protected ICSVStream<Secretary> _secretaryStream;

        protected LongSequencer _sequencer;

        public UserCSVRepository(
            ICSVStream<E> stream,
            ICSVStream<Patient> patientStream,
            ICSVStream<Doctor> doctorStream,
            ICSVStream<Secretary> secretaryStream,
            LongSequencer sequencer
            )
        {
            _stream = stream;
            _patientStream = patientStream;
            _doctorStream = doctorStream;
            _secretaryStream = secretaryStream;
            _sequencer = sequencer;
            InitializeId();
        }
        public IEnumerable<E> GetAll() => _stream.ReadAll();
        protected void InitializeId()
        {
            var patients = _patientStream.ReadAll();
            var doctors = _doctorStream.ReadAll();
            var secretaries = _secretaryStream.ReadAll();

            List<long> ids = (List<long>) patients.Select(item => (item as Patient).Id).ToList();
            ids.AddRange(doctors.Select(item => (item as Doctor).Id).ToList());
            ids.AddRange(secretaries.Select(item => (item as Secretary).Id).ToList());

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
