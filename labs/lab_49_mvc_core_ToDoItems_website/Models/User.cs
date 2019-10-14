namespace lab_49_mvc_core_ToDoItems_website

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User
    {
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        //public DateTime? LastLoggedIn { get; set; }

        public int? ToDoItemID { get; set; }

        public int? CategoryID { get; set; }


        public virtual Category Category { get; set; }

        public virtual ToDoItem ToDoItem { get; set; }
    }
}
