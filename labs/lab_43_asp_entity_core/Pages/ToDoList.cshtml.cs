using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab_43_asp_entity_core.Pages
{
    public class ToDoListModel : PageModel
    {
        public static List<ToDoItem> todos = new List<ToDoItem>();
        public void OnGet()
        {
            using(var db = new ToDoItemContext())
            {
                todos = db.ToDoItems.ToList();
            }
        }
    }
}