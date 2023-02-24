using Project.Repositories.Abstract;
using Project.Repositories.CSV.Stream;
using Project.Repositories.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Repositories.CSV
{
    public class CSVRepository<E, ID> : IRepository<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        private const string NOT_FOUND_ERROR = "{0} with {1}:{2} can not be found!";

        protected string _entityName;
        protected ICSVStream<E> _stream;
        protected ISequencer<ID> _sequencer;

        public CSVRepository(string entityName, ICSVStream<E> stream, ISequencer<ID> sequencer)
        {
            _entityName = entityName;
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public E Save(E entity)
        {
            entity.SetId(_sequencer.GenerateId());
            _stream.AppendToFile(entity);
            return entity;
        }


        public IEnumerable<E> Find(Func<E, bool> predicate)
            => _stream
            .ReadAll()
            .Where(predicate);


        public E GetById(ID id)
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

        public IEnumerable<E> GetAll() => _stream.ReadAll();

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

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

        private ID GetMaxId(IEnumerable<E> entities)
           => entities.Count() == 0 ? default : entities.Max(entity => entity.GetId());

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
