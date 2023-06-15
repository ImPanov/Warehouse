using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pckt.Shared;

[Table("ExpenceItem")]
public partial class ExpenceItem
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long Count { get; set; }

    public double Cost { get; set; }

    public string Recipient { get; set; } = null!;
}
