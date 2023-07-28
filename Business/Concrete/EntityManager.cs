


                            //maybe later

//using Business.Abstract;
//using Core.Entities;
//using DataAccess.Abstract;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Business.Concrete
//{
//    public class EntityManager<T> : IEntityService<T> where T : class, IEntity, new()
//    {

//        IEntityRepository<T> _repository;

//        public EntityManager(IEntityRepository<T> repository)
//        {
//            this._repository = repository;
//        }
//        public void Delete(T entity)
//        {
//            _repository.Delete(entity); 
//        }

//        public List<T> GetAll()
//        {
//            return _repository.GetAll();
//        }

//        public T GetById(int id)
//        {
//            return _repository.Get(t=>t.)
//        }

//        public void Insert(T entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(T entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
