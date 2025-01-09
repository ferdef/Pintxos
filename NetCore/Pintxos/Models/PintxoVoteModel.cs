using System;
using Microsoft.AspNetCore.Identity;

namespace Pintxos.Models
{
    public class PintxoVoteModel
    {
        public Guid Id { get; set; }
        public PintxoModel Pintxo { get; set; }
        public Guid PintxoId { get; set; }
        public IdentityUser Voter { get; set; }
        public int Value { get; set; }
        
    }
}