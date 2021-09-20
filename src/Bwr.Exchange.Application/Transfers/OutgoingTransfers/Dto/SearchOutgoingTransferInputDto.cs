namespace Bwr.Exchange.Transfers.OutgoingTransfers.Dto
{
    public class SearchOutgoingTransferInputDto
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int? PaymentType { get; set; }
        public int? CountryId { get; set; }
        public int? ClientId { get; set; }
        public int? CompanyId { get; set; }
        public int? BeneficiaryId { get; set; }
        public string BeneficiaryAddress { get; set; }
        public int? SenderId { get; set; }

    }
}
