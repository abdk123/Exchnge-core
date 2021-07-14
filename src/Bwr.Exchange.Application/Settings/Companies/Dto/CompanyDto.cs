using Abp.Application.Services.Dto;
using Bwr.Exchange.Settings.Companies.Dto.CompanyBalances;
using System.Collections.Generic;

namespace Bwr.Exchange.Settings.Companies.Dto
{
    public class CompanyDto : EntityDto
    {
        public CompanyDto()
        {
            CompanyBalances = new List<CompanyBalanceDto>();
        }
        public string Name { get; set; }

        public IList<CompanyBalanceDto> CompanyBalances { get; set; }
    }
}
