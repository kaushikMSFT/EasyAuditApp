using System;
using System.Data;

namespace AuditorAPI.Contracts
{
    public class AuditPortfolioCreationRequest
    {
        public int ClientId { get; set; }
        public int AuditorId { get; set; }
        public DateTime ReportReleaseDate { get; set; }
    }
}