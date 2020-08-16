using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditorAPI.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AuditDbContext auditDbContext;

        public UnitOfWork(AuditDbContext dbContext)
        {
            auditDbContext = dbContext;
        }

        public void Save()
        {
            auditDbContext.SaveChanges();
        }
    }


}
