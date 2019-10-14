using System.Web;
using System.Web.Mvc;

namespace lab_49_mvc_Users_Categories_ToDoItems
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
