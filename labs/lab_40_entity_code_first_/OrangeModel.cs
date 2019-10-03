namespace lab_40_entity_code_first_
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OrangeModel : DbContext
    {
        public OrangeModel()
            : base("name=OrangeModel2")
        {
        }

        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Oranx> Oranges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
