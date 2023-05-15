using Microsoft.AspNetCore.Authorization;

namespace InvoiceManagementSystemPaymentApi.Utilities.Attributes
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            Roles = string.Join(',', roles);
        }
    }
}
