﻿namespace Bwr.Exchange.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly ExchangeDbContext _context;

        public InitialHostDbBuilder(ExchangeDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new DefaultTreasuryCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
