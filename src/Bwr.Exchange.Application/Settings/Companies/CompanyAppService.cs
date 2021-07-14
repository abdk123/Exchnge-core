﻿using Abp.UI;
using Bwr.Exchange.Settings.Companies.Dto;
using Bwr.Exchange.Settings.Companies.Services;
using Bwr.Exchange.Shared.Dto;
using Bwr.Exchange.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.Settings.Companies
{
    public class CompanyAppService : ExchangeAppServiceBase, ICompanyAppService
    {
        private readonly CompanyManager _companyManager;
        public CompanyAppService(CompanyManager companyManager)
        {
            _companyManager = companyManager;
        }

        public async Task<IList<CompanyDto>> GetAllAsync()
        {
            var companies = await _companyManager.GetAllAsync();

            return ObjectMapper.Map<List<CompanyDto>>(companies);
        }
        [HttpPost]
        public async Task<ReadGrudDto> GetForGrid([FromBody] DataManagerRequest dm)
        {
            var data = await _companyManager.GetAllAsync();
            IEnumerable<ReadCompanyDto> companies = ObjectMapper.Map<List<ReadCompanyDto>>(data);

            var operations = new DataOperations();
            if (dm.Where != null && dm.Where.Count > 0)
            {
                companies = operations.PerformFiltering(companies, dm.Where, "and");
            }

            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                companies = operations.PerformSorting(companies, dm.Sorted);
            }

            IEnumerable groupDs = new List<ReadCompanyDto>();
            if (dm.Group != null)
            {
                groupDs = operations.PerformSelect(companies, dm.Group);
            }

            var count = companies.Count();

            if (dm.Skip != 0)
            {
                companies = operations.PerformSkip(companies, dm.Skip);
            }

            if (dm.Take != 0)
            {
                companies = operations.PerformTake(companies, dm.Take);
            }

            return new ReadGrudDto() { result = companies, count = count, groupDs = groupDs };
        }
        public UpdateCompanyDto GetForEdit(int id)
        {
            var company =  _companyManager.GetByIdWithDetail(id);
            return ObjectMapper.Map<UpdateCompanyDto>(company);
        }
        public async Task<CompanyDto> CreateAsync(CreateCompanyDto input)
        {
            CheckBeforeCreate(input);

            var company = ObjectMapper.Map<Company>(input);

            var createdCompany = await _companyManager.InsertAndGetAsync(company);

            return ObjectMapper.Map<CompanyDto>(createdCompany);
        }
        public async Task<CompanyDto> UpdateAsync(UpdateCompanyDto input)
        {
            CheckBeforeUpdate(input);

            var company = await _companyManager.GetByIdAsync(input.Id);

            ObjectMapper.Map<UpdateCompanyDto, Company>(input, company);

            var updatedCompany = await _companyManager.UpdateAndGetAsync(company);

            return ObjectMapper.Map<CompanyDto>(updatedCompany);
        }
        public async Task DeleteAsync(int id)
        {
            await _companyManager.DeleteAsync(id);
        }

        #region Helper methods
        private void CheckBeforeCreate(CreateCompanyDto input)
        {
            var validationResultMessage = string.Empty;

            if (_companyManager.CheckIfNameAlreadyExist(input.Name))
            {
                validationResultMessage = L(ValidationResultMessage.NameAleadyExist);
            }

            if (!string.IsNullOrEmpty(validationResultMessage))
                throw new UserFriendlyException(validationResultMessage);
        }
        private void CheckBeforeUpdate(UpdateCompanyDto input)
        {
            var validationResultMessage = string.Empty;

            if (_companyManager.CheckIfNameAlreadyExist(input.Id, input.Name))
            {
                validationResultMessage = L(ValidationResultMessage.NameAleadyExist);
            }

            if (!string.IsNullOrEmpty(validationResultMessage))
                throw new UserFriendlyException(validationResultMessage);
        }

        

        #endregion
    }
}
