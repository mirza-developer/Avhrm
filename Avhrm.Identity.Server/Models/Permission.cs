using Avhrm.Core;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Identity.Server.Models;
public class Permission : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [ProtoMember(1)]
    public int Id { get; set; }
    
    [ProtoMember(2)]
    [Required]
    public string Title { get; set; }

    [Required]
    [ProtoMember(3)]
    public int Level { get; set; }

    [Required]
    [ProtoMember(4)]
    public string Url { get; set; }

    [ProtoMember(5)]
    public string? IconName { get; set; }

    [ProtoMember(6)]
    public DateTime CreateDateTime { get; set; }

    [ProtoMember(7)]
    public string CreatorUser { get; set; }

    [ProtoMember(8)]
    public DateTime? LastUpdateDateTime { get; set; }

    [ProtoMember(9)]
    public string? LastUpdateUser { get; set; }
}
