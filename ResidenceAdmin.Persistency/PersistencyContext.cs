using Microsoft.AspNet.Identity.EntityFramework;
using ResidenceAdmin.DomainModel;
using System;
using System.Data.Entity;
using System.Linq;

namespace ResidenceAdmin.Persistency
{
    public class PersistencyContext : IdentityDbContext<User>, IPersistencyContext
    {
        public DbContext db;
        public override IDbSet<User> Users { get; set; }
        public override IDbSet<IdentityRole> Roles { get; set; }
        public IDbSet<UserRole> UserRoles { get; set; }
        public IDbSet<UserClaim> UserClaims { get; set; }
        public IDbSet<UserLogin> UserLogins { get; set; }

        public IDbSet<Employee> Empoyees { get; set; }
        public IDbSet<Document> Documents { get; set; }
        public IDbSet<AccountingInfo> AccountingInfo { get; set; }
        public IDbSet<EmployeeAddress> Addresses { get; set; }
        public IDbSet<EmployeeIdentity> Identities { get; set; }
        public IDbSet<EmployeeWorkInfo> WorkInfo { get; set; }
        public IDbSet<Seniority> EmpoyeeSeniority { get; set; }

        public PersistencyContext()
        {
            db = new IdentityDbContext("Context");
        }

        TEntity IPersistencyContext.Get<TEntity>(int id)
        {
            var dbEntity = db.Set<TEntity>();
            return dbEntity.Where(e => e.Id == id).FirstOrDefault();
        }

         IQueryable<TEntity> IPersistencyContext.GetAll<TEntity>()
        {

            return db.Set<TEntity>().AsQueryable();
        }

        void IPersistencyContext.InsertRange<TEntity>(IQueryable<TEntity> entities)
        {
            var dbEntity = db.Set<TEntity>();
            dbEntity.AddRange(entities);
        }

        void IPersistencyContext.Remove<TEntity>(int id)
        {
            var dbEntity = db.Set<TEntity>();
            dbEntity.Remove(dbEntity.Where(e => e.Id == id).FirstOrDefault());
        }

        void IPersistencyContext.RemoveRange<TEntity>()
        {
            var dbEntity = db.Set<TEntity>();
            dbEntity.RemoveRange(dbEntity.ToList());
        }

     
        void IPersistencyContext.Insert<TEntity>(TEntity entity)
        {
            var dbEntity = db.Set<TEntity>();
            dbEntity.Add(entity);
        }

        void IPersistencyContext.SaveChanges()
        {
            db.SaveChanges();
        }

    }
}
