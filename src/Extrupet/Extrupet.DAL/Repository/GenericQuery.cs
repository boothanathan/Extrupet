using Extrupet.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Extrupet.DAL.Repository
{
    public class GenericQuery<T> where T : class
    {
        private readonly ExtrupetEntities _dbContext;
        public GenericQuery(ExtrupetEntities db)
        {
            _dbContext = db;
        }

        public virtual T Add(T newItem)
        {
            var v = _dbContext.Set<T>().Add(newItem);
            _dbContext.SaveChanges();
            return v;
        }

        public class ChildrenUpdate<TChild>
        {
            public List<int> IdsFromDatabase { get; set; }
            public List<int> currentIds { get; set; }
            public ICollection<TChild> childEntitiesInMainEntity { get; set; }
            public string childPrimaryKeyPropertyName { get; set; }
        }
        private T _updateParent(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            //Ensure only modified fields are updated.
            _dbContext.Set<T>().Attach(entity);//added
            var dbEntityEntry = _dbContext.Entry(entity);

            if (updatedProperties.Any())
            {
                //update explicitly mentioned properties
                foreach (var property in updatedProperties)
                {
                    dbEntityEntry.Property(property).IsModified = true;
                }

            }
            else
            {
                //no items mentioned, so find out the updated entries
                //foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                //{
                //    var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
                //    var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
                //    if (original != null && !original.Equals(current))
                //        dbEntityEntry.Property(property).IsModified = true;
                //}

                var updatedProps = dbEntityEntry.CurrentValues.PropertyNames.Where(p => dbEntityEntry.Property(p).IsModified);
                foreach (var property in updatedProps)
                {
                    dbEntityEntry.Property(property).IsModified = true;
                }
            }


            return entity;
        }
        public virtual T Update(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            var e = _updateParent(entity, updatedProperties);
            _dbContext.SaveChanges();
            return e;
        }

       

        public virtual T UpdateParentOnly(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            return _updateParent(entity, updatedProperties);
        }
        public virtual ICollection<TChild> UpdateChild<TChild>(ChildrenUpdate<TChild> child) where TChild : class
        {
            List<int> deletedIds = child.IdsFromDatabase
                            .Except(child.currentIds).ToList();

            //foreach (var deletedId in deletedIds)
            //{
            //    _dbContext.Entry(_getInstance<TChild>(deletedId)).State = EntityState.Deleted;
            //}

            foreach (var detail in child.childEntitiesInMainEntity)
            {
                if ((int)detail.GetType().GetProperty(child.childPrimaryKeyPropertyName).GetValue(detail) == 0)//add to database//
                {
                    _dbContext.Entry(detail).State = EntityState.Added;
                }
                else//update to database//
                {
                    // _dbContext.Set<TChild>().Attach(detail);
                    _dbContext.Entry(detail).State = EntityState.Modified;
                }
            }

            return child.childEntitiesInMainEntity;
        }
        private object _getInstance<TGet>(Guid primarykeyValue)
        {
            if (typeof(TGet) == typeof(UserMaster))
                return new UserMaster { UserId = primarykeyValue };
            //else if (typeof(TGet) == typeof(LocationSecurity))
            //    return new LocationSecurity { SecurityId = primarykeyValue };
            //else if (typeof(TGet) == typeof(LocationDate))
            //    return new LocationDate { Location_Date_Id = primarykeyValue };
            //else if (typeof(TGet) == typeof(Location_rel_StorageType))
            //    return new Location_rel_StorageType { RelationId = primarykeyValue };
            else
                return null;
        }

        //public virtual Utility.SystemMessage Delete(T entity/*, Expression<Func<T, bool>> predicate*/)
        //{
        //    try
        //    {
        //        _dbContext.Entry(entity).State = EntityState.Deleted;
        //        _dbContext.SaveChanges();
        //        return Utility.SystemMessage.Successful;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("delete statement affected an unexpected number of rows (0)"))
        //            return Utility.SystemMessage.NotFound;
        //        else
        //            return Utility.SystemMessage.Unable_To_Delete_Due_To_RelatedData;
        //    }
        //}
        public virtual IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate)
        {
            _dbContext.Configuration.ProxyCreationEnabled = false;

            if (predicate != null)
                return _dbContext.Set<T>().Where(predicate).AsNoTracking();
            else
                return _dbContext.Set<T>().AsNoTracking();
        }

        public virtual IQueryable<TGet> GetFilteredData<TGet>(List<IFilter<TGet>> Filters, IQueryable<TGet> query) where TGet : class
        {
            foreach (var c in Filters)
            {
                query = c.GetFilteredList(query);
            }
            return query;
        }

        public virtual T Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);//added
            var dbEntityEntry = _dbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }
    }

    public interface IFilter<TGet> where TGet : class
    {
        IQueryable<TGet> GetFilteredList(IQueryable<TGet> query);
    }
}
