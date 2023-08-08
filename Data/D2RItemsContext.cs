using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using D2RItems.Models;

namespace D2RItems.Data
{
    public class D2RItemsContext : DbContext
    {
        public D2RItemsContext (DbContextOptions<D2RItemsContext> options)
            : base(options)
        {
        }

        public DbSet<D2RItems.Models.Weapon> Weapons { get; set; } = default!;
        public DbSet<D2RItems.Models.Armor> Armors{ get; set; } = default!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Weapon>().ToTable("Weapon");
            modelBuilder.Entity<Weapon>().ToTable("Armor");
        }
	}
}
