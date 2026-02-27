using System;

class Program
{
    public struct TaskItem
    {
        public int Id;
        public string Title;
        public bool IsDone;
    }
    static TaskItem[] tasks = new TaskItem[5]; // fixed size array
    static int taskCount = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Add Task");
            Console.WriteLine("2. Show Tasks");
            Console.WriteLine("3. Mark Done");
            Console.WriteLine("4. Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                AddTask();
            }
            else if (choice == "2")
            {
                ShowTasks();
            }
            else if (choice == "3")
            {
                MarkDone();
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }

    static void AddTask()
    {
        if (taskCount >= tasks.Length)
        {
            Console.WriteLine("Task list is full.");
            return;
        }

        Console.Write("Enter task title: ");
        string title = Console.ReadLine();

        tasks[taskCount] = new TaskItem
        {
            Id = taskCount + 1,
            Title = title,
            IsDone = false
        };

        taskCount++;
        Console.WriteLine("Task added.");
    }

    static void ShowTasks()
    {
        if (taskCount == 0)
        {
            Console.WriteLine("No tasks yet.");
            return;
        }

        for (int i = 0; i < taskCount; i++)
        {
            var t = tasks[i];
            string status = t.IsDone ? "Done" : "Pending";
            Console.WriteLine($"{t.Id}. {t.Title} - {status}");
        }
    }

    static void MarkDone()
    {
        Console.Write("Enter task id to mark done: ");
        int id = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < taskCount; i++)
        {
            if (tasks[i].Id == id)
            {
                tasks[i].IsDone = true;
                Console.WriteLine("Task marked as done.");
                return;
            }
        }

        Console.WriteLine("Task not found.");
    }
}