using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Bwr.Exchange.Authorization.Roles;
using Bwr.Exchange.Authorization.Users;
using Bwr.Exchange.MultiTenancy;
using Bwr.Exchange.Settings.Countries;
using Bwr.Exchange.Settings.Treasuries;
using Bwr.Exchange.Settings.Currencies;
using Bwr.Exchange.Settings.Incomes;
using Bwr.Exchange.Settings.Expenses;
using Bwr.Exchange.Settings.Clients;
using Bwr.Exchange.Settings.Companies;

namespace Bwr.Exchange.EntityFrameworkCore
{
    public class ExchangeDbContext : AbpZeroDbContext<Tenant, Role, User, ExchangeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ExchangeDbContext(DbContextOptions<ExchangeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CompanyBalance> CompanyBalances { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Treasury> Treasuries { get; set; }
        public virtual DbSet<TreasuryBalance> TreasuryBalances { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientBalance> ClientBalances { get; set; }
        public virtual DbSet<ClientPhone> ClientPhones { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
    }
}
