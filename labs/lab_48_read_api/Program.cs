using lab_48_api_todo_list_core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace lab_48_read_api
{
    class Program
    {
        static string url = "https://localhost:44383/api/TaskItems/";
        static HttpClient client = new HttpClient();
        static TaskItem taskItem = new TaskItem();
        static List<TaskItem> taskItems = new List<TaskItem>();

        static void Main(string[] args)
        {
            var t = new TaskItem()
            {
                Description = "New Task",
                TaskDone = false,
                DateDue = DateTime.Parse("10/10/2019"),
                UserID = 2,
                CategoryID = 3
            };

            

            TaskItem NewTaskItem  = PostNewTaskItemAsync(t).Result;

            PrintItems(GetTaskItemsAsync().Result);

            PrintItem(GetTaskItemAsync(1).Result);
            TaskItem item = GetTaskItemAsync(1).Result;
            //TaskItem item2 = UpdateCustomerAsync(item).Result;
            //PrintItem(item2);
        }

        static async Task<TaskItem> PostNewTaskItemAsync(TaskItem newItem)
        {
            var taskItemString = JsonConvert.SerializeObject(newItem);
            var taskItemHTTP = new StringContent(taskItemString);
            taskItemHTTP.Headers.ContentType.MediaType = "application/json";
            taskItemHTTP.Headers.ContentType.CharSet = "UTF-8";
            var response = await client.PostAsync(url, taskItemHTTP);
            var newItemAsJson = response.Content.ReadAsStringAsync();
            var newItemAsTask = JsonConvert.DeserializeObject<TaskItem>(newItemAsJson.Result);
            return newItemAsTask;
        }

        static async Task<TaskItem> GetTaskItemAsync(int itemID)
        {
            Console.WriteLine("Getting Task Item");
            var response = await client.GetAsync(url+itemID);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                taskItem = JsonConvert.DeserializeObject<TaskItem>(responseString);
            }
            
            return DeserializeObject(response);
        }
        static async Task<List<TaskItem>> GetTaskItemsAsync()
        {
            Console.WriteLine("Getting Task Items");
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                taskItems = DeserializeObjects(response);
            }
            return taskItems;
        }

        static async Task<T> UpdateCustomerAsync<T>(TaskItem taskItemToUpdate)
        {
            T item = default(T);
            int id = taskItemToUpdate.TaskItemID;
            var getResponse = await client.GetAsync(url + id);
            var gotItemAsJson = getResponse.Content.ReadAsStringAsync();
            Console.WriteLine(gotItemAsJson.ToString());
            var gotItemAsTask = JsonConvert.DeserializeObject<T>(gotItemAsJson.Result);
            
            var values = JsonConvert.SerializeObject(taskItemToUpdate);
            var content = new StringContent(values);

            content.Headers.ContentType.MediaType = "application/json";
            content.Headers.ContentType.CharSet = "UTF-8";

            var response = await client.PutAsync(url+id, content);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                //item = DeserializeObject(response);
                var objectAsJson = response.Content.ReadAsStringAsync();
                var objectAsTask = JsonConvert.DeserializeObject<TaskItem>(objectAsJson.Result);
            }

            return item;
        }

        static void PrintItems(List<TaskItem> items)
        {
            foreach (TaskItem item in items)
            {
                Console.WriteLine($"Task Item ID = {item.TaskItemID, -10} " +
                    $"Task Description = {item.Description, 20} " +
                    $"Task Done = {item.TaskDone, -25} " +
                    $"Date Due = {item.DateDue} ");
            }
        }
        static void PrintItem(TaskItem item)
        {
            Console.WriteLine($"Task Item ID = {item.TaskItemID} " +
                     $"Task Description = {item.Description} " +
                     $"Task Done = {item.TaskDone} " +
                     $"Date Due = {item.DateDue} ");
        }

        static TaskItem DeserializeObject(HttpResponseMessage response)
        {
            var objectAsJson = response.Content.ReadAsStringAsync();
            var objectAsTask = JsonConvert.DeserializeObject<TaskItem>(objectAsJson.Result);
            return objectAsTask;
        }

        static List<TaskItem> DeserializeObjects(HttpResponseMessage response)
        {
            var objectAsJson = response.Content.ReadAsStringAsync();
            var objectAsTask = JsonConvert.DeserializeObject<List<TaskItem>>(objectAsJson.Result);
            return objectAsTask;
        }
    }
}
