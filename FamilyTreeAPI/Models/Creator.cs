﻿using System.ComponentModel.DataAnnotations;

namespace FamilyTreeAPI.Models
{
    public class Creator : BaseAuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        [MinLength(2)]
        public string FirstName { get; set; } = "John";
        [MaxLength(100)]
        [MinLength(2)]
        public string LastName { get; set; } = "Doe";
        public DateTime? DateOfBirth { get; set; }
    }
}
