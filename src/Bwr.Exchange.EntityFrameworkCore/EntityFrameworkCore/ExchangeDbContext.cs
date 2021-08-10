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
using Bwr.Exchange.Settings;
using Bwr.Exchange.Customers;
using Bwr.Exchange.Transfers;
using Bwr.Exchange.CashFlows.ClientCashFlows;
using Bwr.Exchange.CashFlows.CompanyCashFlows;
using Bwr.Exchange.CashFlows.TreasuryCashFlows;
using System.Transactions;

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
        public virtual DbSet<Commision> Commisions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OutgoingTransfer> OutgoingTransfers { get; set; }
        public virtual DbSet<ClientCashFlow> ClientCashFlows { get; set; }
        public virtual DbSet<CompanyCashFlow> CompanyCashFlows { get; set; }
        public virtual DbSet<TreasuryCashFlow> TreasuryCashFlows { get; set; }

    }
}
