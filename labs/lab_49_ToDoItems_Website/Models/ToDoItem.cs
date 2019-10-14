namespace lab_49_ToDoItems_Website
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ToDoItem
    {
        public ToDoItem()
        {
            Users = new HashSet<User>();
        }

        public int ToDoItemId { get; set; }

        [StringLength(50)]
        public string Item { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? DateDue { get; set; }

        public bool? Done { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
