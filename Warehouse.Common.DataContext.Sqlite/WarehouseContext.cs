using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pckt.Shared;

public partial class WarehouseContext : DbContext
{
    public WarehouseContext()
    {
    }

    public WarehouseContext(DbContextOptions<WarehouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExpenceItem> ExpenceItems { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ReceiptItem> ReceiptItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string dir = Environment.CurrentDirectory;
            string path = string.Empty;
            if (dir.EndsWith("net7.0"))
            {
                // Running in the <project>\bin\<Debug|Release>\net7.0 directory.
                path = Path.Combine("..", "..", "..", "..", "Warehouse.Common.DataContext.Sqlite", "Warehouse.db");
            }
            else
            {
                // Running in the <project> directory.
                path = Path.Combine("..", "Warehouse.Common.DataContext.Sqlite", "Warehouse.db");
            }
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
