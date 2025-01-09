using System;
using Microsoft.AspNetCore.Identity;

namespace Pintxos.Models
{
    public class PintxoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ContestId { get; set; }
        public ContestModel Contest { get; set; }
        public IdentityUser Owner {get; set;}

    }
}