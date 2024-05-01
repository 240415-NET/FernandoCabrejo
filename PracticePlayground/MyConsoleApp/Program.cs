public class TodoItem
     public static void Main(string[] arg){

    List<TodoItem> todoItems = new List<TodoItem>();

    for (int i = 0; i < 1; i++)
        Console.WriteLine("Type Description:\n");

        string description = Console.ReadLine();

        Console.WriteLine("Estimated Time:\n");

        int estimatedTime = int.Parse(Console.ReadLine());

        Console.WriteLine("Due Date:\n");

        string dueDate = Console.ReadLine();

        TodoItem newItem = new TodoItem(description, estimatedTime, dueDate, false);

        TodoItem.Add(newItem);
    }

   foreach(var item in todoItems){
      Console.WriteLine(item);
   }