using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Later.Models
{
	public class LaterContext : DbContext
	{
		public DbSet<Capsule> Capsules { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			//Equipments
			modelBuilder.Entity<Capsule>().HasKey(e => e.ID);
			modelBuilder.Entity<Capsule>().Property(e => e.ID).IsRequired().HasMaxLength(50);
			modelBuilder.Entity<Capsule>().Property(e => e.Deadline).IsRequired();
			modelBuilder.Entity<Capsule>().Property(e => e.Message).IsRequired();
		}
	}

}