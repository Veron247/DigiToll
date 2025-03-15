using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DigiToll.DataStorage.EntityConfigurations.AccountManagement;

public class ApplicationUser : IdentityUser{
    [Required]
    [MaxLength(255)]
    public string FullName { get; set; }

    public DateTime DeletedDated { get; set; }

    public bool Active { get; set; }

    public bool IsAuthorized { get; set; } = false;

    [MaxLength(255)]
    public string AuthorizedById { get; set; }

    [MaxLength(300)]
    public string AuthorizedBy { get; set; }

    public DateTime AuthorizedDate { get; set; }

    [MaxLength(300)]
    public string CreatedBy { get; set; }

    [MaxLength(255)]
    public string CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    [MaxLength(300)]
    public string ModifiedBy { get; set; }

    [MaxLength(255)]
    public string ModifiedId { get; set; }

    public DateTime ModifiedDate { get; set; }

    [MaxLength(20)]
    public string Role { get; set; }

    public int AgencyId { get; set; }

    public ICollection<Audit> Audit { get; set; }

}
