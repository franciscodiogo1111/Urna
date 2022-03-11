﻿using System;
using Urna.Entity.Context;
using System.Collections.Generic;
using System.Text;
using Urna.Entity.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Urna.Entity.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly UrnaContext _context;
        protected readonly DbSet<TEntity> _entities;
        public Repository(UrnaContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }
        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }
        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity);
        }
        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
        }
        public virtual void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }
        public virtual int Count()
        {
            return _entities.Count();
        }
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }
        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }
        public virtual TEntity Get(Guid id)
        {
            return _entities.Find(id);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }
        public virtual int Save()
        {
            try
            {
                return _appContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return -1;
            }
        }
        private UrnaContext _appContext => (UrnaContext)_context;

    }
}
