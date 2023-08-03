using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using D2R_Items.Models;

namespace D2R_Items.Services;

public class ItemContext : DbContext
{
    public DbSet<Weapon> Weapons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=D2R;Trusted_Connection=True");
    }
}

public class DataAccessService
{
    public IEnumerable<Weapon>? Query(string query)
    {
        return null;
    }
}