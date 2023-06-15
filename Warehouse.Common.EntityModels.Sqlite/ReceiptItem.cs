using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pckt.Shared;

[Table("ReceiptItem")]
public partial class ReceiptItem
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public double Cost { get; set; }

    public long Count { get; set; }

    public string Type { get; set; } = null!;
}
