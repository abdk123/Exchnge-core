using AutoMapper;
using Bwr.Exchange.Settings.Currencies.Dto;

namespace Bwr.Exchange.Settings.Currencies.Map
{
    public class ExpenseMapProfile:Profile
    {
        public ExpenseMapProfile()
        {
            CreateMap<Currency, CurrencyDto>();
            CreateMap<Currency, ReadCurrencyDto>();
            CreateMap<Currency, CreateCurrencyDto>();
            CreateMap<CreateCurrencyDto, Currency>();
            CreateMap<Currency, UpdateCurrencyDto>();
            CreateMap<UpdateCurrencyDto, Currency>();
        }
    }
}
