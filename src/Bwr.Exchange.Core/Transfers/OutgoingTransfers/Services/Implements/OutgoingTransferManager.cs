using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Bwr.Exchange.Transfers.OutgoingTransfers.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.Transfers.OutgoingTransfers.Services
{
    public class OutgoingTransferManager : IOutgoingTransferManager
    {
        private readonly IRepository<OutgoingTransfer> _outgoingTransferRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IOutgoingTransferFactory _outgoingTransferFactory;
        public IEventBus EventBus { get; set; }

        public OutgoingTransferManager(
            IRepository<OutgoingTransfer> outgoingTransferRepository,
            IUnitOfWorkManager unitOfWorkManager,
            IOutgoingTransferFactory outgoingTransferFactory
            )
        {
            _outgoingTransferRepository = outgoingTransferRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _outgoingTransferFactory = outgoingTransferFactory;
            EventBus = NullEventBus.Instance;
        }

        public async Task<OutgoingTransfer> CreateAsync(OutgoingTransfer input)
        {
            //Date and time
            var currentDate = DateTime.Now;
            input.Date = new DateTime(
                input.Date.Year,
                input.Date.Month,
                input.Date.Day,
                currentDate.Hour,
                currentDate.Minute,
                currentDate.Second
                );

            IOutgoingTransferDomainService service = _outgoingTransferFactory.CreateService(input);
            return await service.CreateAsync();
        }

        public async Task<OutgoingTransfer> GetByIdAsync(int id)
        {
            return await _outgoingTransferRepository.FirstOrDefaultAsync(id);
        }

        public OutgoingTransfer GetById(int id)
        {
            return _outgoingTransferRepository.GetAllIncluding(
                b => b.Beneficiary,
                s => s.Sender
                ).FirstOrDefault();
        }

        public async Task<IList<OutgoingTransfer>> GetAsync(Dictionary<string, object> dic)
        {
            IEnumerable<OutgoingTransfer> outgoingTransfers = await _outgoingTransferRepository.GetAllListAsync(x =>
              x.Date >= DateTime.Parse(dic["FromDate"].ToString()) &&
              x.Date >= DateTime.Parse(dic["ToDate"].ToString()));

            if (outgoingTransfers != null && outgoingTransfers.Any())
            {
                if (dic["PaymentType"] != null)
                {
                    outgoingTransfers = outgoingTransfers
                        .Where(x => x.PaymentType == (PaymentType)int.Parse(dic["PaymantType"].ToString()));
                }

                if (dic["ClientId"] != null)
                {
                    outgoingTransfers = outgoingTransfers
                        .Where(x => x.FromClientId == int.Parse(dic["ClientId"].ToString()));
                }
            }

            return outgoingTransfers.ToList();
        }

        public IList<OutgoingTransfer> Get(Dictionary<string, object> dic)
        {
            IEnumerable<OutgoingTransfer> outgoingTransfers = GetAllWithDetails();

            if (outgoingTransfers != null && outgoingTransfers.Any())
            {
                if (dic["FromDate"] != null && dic["FromDate"] != null)
                {
                    outgoingTransfers = outgoingTransfers.Where(x =>
                      x.Date >= DateTime.Parse(dic["FromDate"].ToString()) &&
                      x.Date <= DateTime.Parse(dic["ToDate"].ToString())).ToList();
                }
                if (dic["PaymentType"] != null)
                {
                    outgoingTransfers = outgoingTransfers
                        .Where(x => x.PaymentType == (PaymentType)int.Parse(dic["PaymantType"].ToString()));
                }

                if (dic["ClientId"] != null)
                {
                    outgoingTransfers = outgoingTransfers
                        .Where(x => x.FromClientId == int.Parse(dic["ClientId"].ToString()));
                }

                if (dic["CompanyId"] != null)
                {
                    outgoingTransfers = outgoingTransfers
                        .Where(x => x.FromCompanyId == int.Parse(dic["CompanyId"].ToString()));
                }

                if (dic["CountryId"] != null)
                {
                    outgoingTransfers = outgoingTransfers
                        .Where(x => x.CountryId == int.Parse(dic["CountryId"].ToString()));
                }

                if (dic["Beneficiary"] != null)
                {
                    outgoingTransfers = outgoingTransfers
                        .Where(x => x.Beneficiary != null && x.Beneficiary.Name.Contains(dic["Beneficiary"].ToString()));
                }

                if (dic["BeneficiaryAddress"] != null)
                {
                    outgoingTransfers = outgoingTransfers
                        .Where(x => x.Beneficiary != null && x.Beneficiary.Address.Contains(dic["BeneficiaryAddress"].ToString()));
                }

                if (dic["Sender"] != null)
                {
                    outgoingTransfers = outgoingTransfers
                        .Where(x => x.Sender != null && x.Sender.Name.Contains(dic["Sender"].ToString()));
                }

                return outgoingTransfers.ToList();
            }

            return new List<OutgoingTransfer>();
        }

        IQueryable<OutgoingTransfer> GetAllWithDetails()
        {
            return _outgoingTransferRepository
                .GetAllIncluding(
                tc => tc.ToCompany,
                co => co.Country,
                cu => cu.Currency,
                be => be.Beneficiary,
                se => se.Sender
                );
        }
    }
}
