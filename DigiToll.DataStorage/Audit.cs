using System.ComponentModel.DataAnnotations;
using DigiToll.DataStorage.EntityConfigurations.AccountManagement;

namespace DigiToll.DataStorage;

public class Audit
{
    public string AuditId { get; set; }

    public string AppUserId { get; set; }

    public ApplicationUser ApplicationUser { get; set; }

    [MaxLength(255)]
    public string Activity { get; set; }

    [MaxLength(255)]
    public string Action { get; set; }

    [MaxLength(100)]
    public string IpAddress { get; set; }

    public DateTime DateCreated { get; set; }

    [MaxLength(100)]
    public string TableName { get; set; }

    [MaxLength(100)]
    public string TableId { get; set; }

    [MaxLength(500)]
    public string ObjectSavedChanges { get; set; }

}