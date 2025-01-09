using System;
using System.ComponentModel.DataAnnotations;

namespace Pintxos.Models
{
    public class FamilyModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}