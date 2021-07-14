using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Bwr.Exchange.Authorization
{
    public class ExchangeAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            //Countries
            context.CreatePermission(PermissionNames.Pages_Countries, L("Countries"));
            context.CreatePermission(PermissionNames.Pages_Countries_Create, L("CreateNewCountry"));
            context.CreatePermission(PermissionNames.Pages_Countries_Edit, L("EditCountry"));
            context.CreatePermission(PermissionNames.Pages_Countries_Delete, L("DeleteCountry"));

            //TreasuryBalances
            context.CreatePermission(PermissionNames.Pages_TreasuryBalances, L("TreasuryBalances"));
            context.CreatePermission(PermissionNames.Pages_TreasuryBalances_Create, L("CreateNewBalance"));
            context.CreatePermission(PermissionNames.Pages_TreasuryBalances_Edit, L("EditBalance"));
            //context.CreatePermission(PermissionNames.Pages_TreasuryBalances_Delete, L("DeleteBalance"));

            //Incomes
            context.CreatePermission(PermissionNames.Pages_Incomes, L("Incomes"));
            context.CreatePermission(PermissionNames.Pages_Incomes_Create, L("CreateNewIncome"));
            context.CreatePermission(PermissionNames.Pages_Incomes_Edit, L("EditIncome"));
            context.CreatePermission(PermissionNames.Pages_Incomes_Delete, L("DeleteIncome"));

            //Expenses
            context.CreatePermission(PermissionNames.Pages_Expenses, L("Expenses"));
            context.CreatePermission(PermissionNames.Pages_Expenses_Create, L("CreateNewExpense"));
            context.CreatePermission(PermissionNames.Pages_Expenses_Edit, L("EditExpense"));
            context.CreatePermission(PermissionNames.Pages_Expenses_Delete, L("DeleteExpense"));

            //Companies
            context.CreatePermission(PermissionNames.Pages_Companies, L("Companies"));
            context.CreatePermission(PermissionNames.Pages_Companies_Create, L("CreateNewCompany"));
            context.CreatePermission(PermissionNames.Pages_Companies_Edit, L("EditCompany"));
            context.CreatePermission(PermissionNames.Pages_Companies_Delete, L("DeleteCompany"));

            //Clients
            context.CreatePermission(PermissionNames.Pages_Clients, L("Clients"));
            context.CreatePermission(PermissionNames.Pages_Clients_Create, L("CreateNewClient"));
            context.CreatePermission(PermissionNames.Pages_Clients_Edit, L("EditClient"));
            context.CreatePermission(PermissionNames.Pages_Clients_Delete, L("DeleteClient"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ExchangeConsts.LocalizationSourceName);
        }
    }
}
