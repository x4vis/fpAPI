using System;
using System.ComponentModel.DataAnnotations;

namespace fpAPI.DTO
{
    public class BaseProvider
    {
        [Required]
        [StringLength(32)]
        public string PersonType { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string ComercialName { get; set; }

        [Required]
        [StringLength(32)]
        public string Rfc { get; set; }

        [Phone]
        [StringLength(32)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Street { get; set; }

        [StringLength(32)]
        public string ExtNum { get; set; }

        [StringLength(32)]
        public string IntNum { get; set; }

        [StringLength(64)]
        public string Neighborhood { get; set; }

        public uint? Cp { get; set; }

        public DateTime? CreationDate { get; set; }
    }

    public class IdProvider : BaseProvider, IIdentified
    {
        public uint Id { get; set; }
    }
}
