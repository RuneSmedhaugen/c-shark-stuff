using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Tasks
    {
        private string _task;
        private DateTime _date;
        private bool _done;
        public List<Tasks> tasksList = new List<Tasks>();

        public Tasks()
        {
        }

        public Tasks(string Task, DateTime TheDate, bool Done)
        {
            _task = Task;
            _date = TheDate;
            _done = Done;
        }


        public void AddTask()
        {
            Console.WriteLine("Name of the task:");
            string taskName = Console.ReadLine();

            Console.WriteLine("Add a date the task to be done: (mm/dd/yyyy)");
            var taskDate = Console.ReadLine();

            if (DateTime.TryParse(taskDate, out DateTime taskDateTime))
            {
                var newTask = new Tasks(taskName, taskDateTime, false);
                tasksList.Add(newTask);
                Console.WriteLine($"Task '{taskName}' added with date {taskDateTime.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("Error, wrong format");
            }
        }

        public void RemoveTask()
        {
            Console.WriteLine("Enter the name of the task to remove:");
            string taskName = Console.ReadLine();
            var taskToRemove = tasksList.Find(t => t._task == taskName);
            if (taskToRemove != null)
            {
                tasksList.Remove(taskToRemove);
                Console.WriteLine($"Task '{taskName}' removed.");
            }
            else
            {
                Console.WriteLine($"Task '{taskName}' not found.");
            }
        }

        public void TaskDone()
        {
            if (tasksList.Count == 0)
            {
                Console.WriteLine("No tasks available to mark as done.");
                return;
            }

            Console.WriteLine("Select the task number to mark as done:");
            for (int i = 0; i < tasksList.Count; i++)
            {
                string status = tasksList[i]._done ? "Done" : "Not Done";
                Console.WriteLine($"{i + 1}. Task: {tasksList[i]._task}, Date: {tasksList[i]._date.ToShortDateString()}, Status: {status}");
            }

            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasksList.Count)
            {
                tasksList[taskNumber - 1]._done = true;
                Console.WriteLine($"Task '{tasksList[taskNumber - 1]._task}' marked as done.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        public void DisplayTasks()
        {
            foreach (var task in tasksList)
            {
                string status = task._done ? "Done" : "Not Done";
                Console.WriteLine($"Task: {task._task}, Date: {task._date.ToShortDateString()}, Status: {status}");
            }
        }
    }
}

