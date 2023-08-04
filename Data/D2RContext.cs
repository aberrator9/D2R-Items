using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using D2RItems.Models;

namespace D2RItems.Data;

public class D2RContext : DbContext
{
    public D2RContext(DbContextOptions<D2RContext> options)
        : base(options)
    {
    }

    public DbSet<D2RItems.Models.Weapon> Weapons { get; set; } = default!;
}
