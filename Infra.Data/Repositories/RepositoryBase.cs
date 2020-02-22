using Domain.Helpers;
using Domain.Interfaces.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly HospContext Db;

        public RepositoryBase(HospContext _context)
        {
            Db = _context;
        }

        public TEntity Add(TEntity obj)
        {
            try
            {
                Db.Set<TEntity>().Add(obj);
                Db.SaveChanges();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, null);
            }
        }


        public async Task<TEntity> AddAsync(TEntity obj)
        {
            try
            {
                await Db.Set<TEntity>().AddAsync(obj);
                Db.SaveChanges();
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, null);
            }
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> objs)
        {
            try
            {
                Db.Set<TEntity>().AddRange(objs);
                Db.SaveChanges();
                return objs;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, null);
            }
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> objs)
        {
            try
            {
                await Db.Set<TEntity>().AddRangeAsync(objs);
                Db.SaveChanges();
                return objs;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, null);
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                return Db.Set<TEntity>().Find(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, null);
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                return await Db.Set<TEntity>().FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, null);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return Db.Set<TEntity>().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, null);
            }
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await Db.Set<TEntity>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, null);
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return Db.Set<TEntity>().Where(predicate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, null);
            }
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await Db.Set<TEntity>().Where(predicate).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, null);
            }
        }

        public TEntity Update(TEntity obj)
        {
            try
            {
                Db.Entry(obj).State = EntityState.Modified;
                Db.SaveChanges();
                return obj;
            }
            catch (ValidationException vex)
            {
#if DEBUG
                List<string> Erros = new List<string>();
                string erro = string.Format("Entidade do tipo \"{0}\" com state \"{1}\" com o(s) seguinte(s) erro(s) de validação:",
                    vex.GetType().Name, vex.ValidationResult.ErrorMessage);
#endif
                throw new AppException(vex.Message);
            }
            catch (DbUpdateException ue)
            {
#if DEBUG

                List<string> Erros = new List<string>();
                foreach (var eve in ue.Entries)
                {
                    string erro = string.Format("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entity.GetType().Name, eve.State);
                    Debug.WriteLine(erro);
                    Erros.Add(erro);
                }
#endif
                throw new AppException(ue.Message);
            }
            catch (Exception e)
            {
#if DEBUG
                List<string> Erros = new List<string>();
                string erro = string.Format("- Menssagem: \"{0}\", Data: \"{1}\"",
                            e.Message, e.Data);
                Erros.Add(erro);
                Debug.WriteLine(erro);
#endif
                throw new AppException(e.Message);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            try
            {
                Db.Entry(obj).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return obj;
            }
            catch (ValidationException vex)
            {
#if DEBUG
                List<string> Erros = new List<string>();
                string erro = string.Format("Entidade do tipo \"{0}\" com state \"{1}\" com o(s) seguinte(s) erro(s) de validação:",
                    vex.GetType().Name, vex.ValidationResult.ErrorMessage);
#endif
                throw new AppException(vex.Message);
            }
            catch (DbUpdateException ue)
            {
#if DEBUG

                List<string> Erros = new List<string>();
                foreach (var eve in ue.Entries)
                {
                    string erro = string.Format("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entity.GetType().Name, eve.State);
                    Debug.WriteLine(erro);
                    Erros.Add(erro);
                }
#endif
                throw new AppException(ue.Message);
            }
            catch (Exception e)
            {
#if DEBUG
                List<string> Erros = new List<string>();
                string erro = string.Format("- Menssagem: \"{0}\", Data: \"{1}\"",
                            e.Message, e.Data);
                Erros.Add(erro);
                Debug.WriteLine(erro);
#endif
                throw new AppException(e.Message);
            }
        }

        public async Task<int> RemoveAsync(int id)
        {
            try
            {
                var a = GetById(id);
                if (a != null)
                {
                    Db.Set<TEntity>().Remove(a);
                    return await Db.SaveChangesAsync();
                }
                else
                {
                    return -1001;
                }
            }
            catch (ValidationException ex)
            {
#if DEBUG
                List<string> Erros = new List<string>();
                string erro = string.Format("Entidade do tipo \"{0}\" com state \"{1}\" com o(s) seguinte(s) erro(s) de validação:",
                    ex.GetType().Name, ex.ValidationResult.ErrorMessage);
#endif
                return -1002;
            }
            catch (DbUpdateException ex)
            {
#if DEBUG
                List<string> Erros = new List<string>();
                string erro = string.Format("Entidade do tipo \"{0}\" com state \"{1}\" com o(s) seguinte(s) erro(s) de validação:",
                    ex.GetType().Name, ex.Message);
#endif
                return -1002;

            }
            catch (Exception)
            {
                return -1003;
            }

        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}