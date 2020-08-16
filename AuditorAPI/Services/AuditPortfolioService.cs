using AuditorAPI.Domain;
using AuditorAPI.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditorAPI.Services
{
    public class AuditPortfolioService : IAuditPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AuditPortfolio> _portfoliorepository;
        public AuditPortfolioService(IRepository<AuditPortfolio> auditPortfolioRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _portfoliorepository = auditPortfolioRepository;
        }

        public void Create(AuditPortfolio portfolio)
        {
            _portfoliorepository.Create(portfolio);
            _unitOfWork.Save();
        }
    }
}
