using Microsoft.VisualBasic;
using ToDoList;

Tasks tasks = new Tasks();


while (true)
{
    Console.WriteLine($@"Menu for your To Do list:
1: see your to do list
2: add a new task
3: remove a task
4: set a task to done
5: exit program
 ");
    var input = Console.ReadLine();
    switch (input)
    {
        case "1":
            tasks.DisplayTasks();
            break;
        case "2":
            tasks.AddTask();
            break;
        case "3":
            tasks.RemoveTask();
            break;
        case "4":
            tasks.TaskDone();
            break;
        case "5":
            return;
        default:
            Console.WriteLine("select 1-4 plz.");
            break;
    }
}
