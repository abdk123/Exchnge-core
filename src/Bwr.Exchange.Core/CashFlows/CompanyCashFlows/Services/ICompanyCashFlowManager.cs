using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows.Services
{
    public interface ICompanyCashFlowManager : IDomainService
    {
        Task Create(CompanyCashFlow input);
        Task<CompanyCashFlow> GetLastAsync(int companyId, int currencyId);
        IList<CompanyCashFlow> Get(int company);
        IList<CompanyCashFlow> Get(int companyId, int currencyId, DateTime fromDate, DateTime toDate);
        double GetPreviousBalance(int companyId, int currencyId, DateTime date);
    }
}
