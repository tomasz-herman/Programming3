namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {
        // Create a LinkedList of type int
        LinkedList<int> numbers = new LinkedList<int>();
        
        // Adding elements to LinkedList
        numbers.AddLast(10);  // Adds 10 at the end of the list
        numbers.AddLast(20);  // Adds 20 at the end of the list
        numbers.AddFirst(5);  // Adds 5 at the start of the list
        numbers.AddLast(30);  // Adds 30 at the end of the list
        
        // Display the elements of the LinkedList
        Console.WriteLine("LinkedList Elements:");
        foreach (var number in numbers)
        {
            Console.Write(number + " ");  // Output will be: 5 10 20 30
        }
        Console.WriteLine();
        
        // Add an element in between two nodes
        LinkedListNode<int>? node = numbers.Find(20);  // Finding node containing 20
        if (node != null)
        {
            numbers.AddBefore(node, 15);  // Adds 15 before 20
        }

        // Display the modified LinkedList
        Console.WriteLine("\nLinkedList After Adding 15 Before 20:");
        foreach (var number in numbers)
        {
            Console.Write(number + " ");  // Output will be: 5 10 15 20 30
        }
        Console.WriteLine();

        // Removing an element from the LinkedList
        numbers.Remove(10);  // Remove node with value 10
        
        // Display the LinkedList after removal
        Console.WriteLine("\nLinkedList After Removing 10:");
        foreach (var number in numbers)
        {
            Console.Write(number + " ");  // Output will be: 5 15 20 30
        }
        Console.WriteLine();

        // Checking first and last element of the LinkedList
        Console.WriteLine("\nFirst Element: " + numbers.First?.Value);  // Output: 5
        Console.WriteLine("Last Element: " + numbers.Last?.Value);     // Output: 30

        // Removing first and last nodes
        numbers.RemoveFirst();
        numbers.RemoveLast();

        // Show remaining LinkedList after removal of first and last
        Console.WriteLine("\nLinkedList After Removing First and Last Nodes:");
        foreach (var number in numbers)
        {
            Console.Write(number + " ");  // Output will be: 15 20
        }
        Console.WriteLine();
    }
}