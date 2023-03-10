using System.ComponentModel.DataAnnotations;

namespace Avhrm.Domain.Common;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime CreateDateTime { get; set; }

    [Required]
    public Guid CreatorUser { get; set; }
}
