using AuditorAPI.Domain;

namespace AuditorAPI.Services
{
    public interface IAuditPortfolioService
    {
        void Create(AuditPortfolio portfolio);
    }
}