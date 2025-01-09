using Microsoft.AspNetCore.Identity;

namespace Pintxos.Models
{
    public class ManageUsersViewModel
    {
        public IdentityUser[] Administrators { get; set; }
        public IdentityUser[] Everyone { get; set; }
    }
}