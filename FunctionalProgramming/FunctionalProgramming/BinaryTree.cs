namespace FunctionalProgramming;

/// <summary>
/// Add a DepthFirstSearch method that takes three Action functions
/// with a parameter of type Node (preVisit, inVisit, postVisit).<br/>
/// The method should recursively traverse the tree,
/// invoking the appropriate actions at the appropriate times:<br/>
/// - preVisit should be invoked before descending recursively.<br/>
/// - inVisit should be invoked between recursive descents.<br/>
/// - postVisit should be invoked after recursive descents.<br/>
/// Add an implementation of the PrintInOrder method, using the previously implemented method:<br/>
/// - This method should print the values of the nodes in In-Order with appropriate indentation.<br/>
/// - The length of the indentation should be proportional to the level of the node in the tree.<br/>
/// - In the preVisit and postVisit methods, you can keep track of the recursion level.<br/>
/// - In the inVisit method, the value of the node should be printed along with the appropriate indentation.
/// </summary>
public class BinaryTree<T>
{
    public class Node(T value, Node? left = null, Node? right = null)
    {
        public T Value { get; set; } = value;
        public Node? Left { get; set; } = left;
        public Node? Right { get; set; } = right;
    }

    public Node? Root { get; set; }

    public BinaryTree(Node? root)
    {
        Root = root;
    }

    // TODO: DepthFirstSearch

    public void PrintInOrder()
    {
        // TODO: PrintInOrder
    }
}

// SOLUTION
// public class BinaryTree<T>
// {
//     public class Node(T value, Node? left = null, Node? right = null)
//     {
//         public T Value { get; set; } = value;
//         public Node? Left { get; set; } = left;
//         public Node? Right { get; set; } = right;
//     }
//
//     public Node? Root { get; set; }
//
//     public BinaryTree(Node? root)
//     {
//         Root = root;
//     }
//
//     public void DepthFirstSearch(Action<Node>? preVisit, Action<Node>? inVisit, Action<Node>? postVisit)
//     {
//         if (Root != null) Traverse(Root, preVisit, inVisit, postVisit);
//     }
//
//     private static void Traverse(Node node, Action<Node>? preVisit, Action<Node>? inVisit, Action<Node>? postVisit)
//     {
//         preVisit?.Invoke(node);
//         if (node.Left != null) Traverse(node.Left, preVisit, inVisit, postVisit);
//         inVisit?.Invoke(node);
//         if (node.Right != null) Traverse(node.Right, preVisit, inVisit, postVisit);
//         postVisit?.Invoke(node);
//     }
//
//     public void PrintInOrder()
//     {
//         var level = 0;
//         DepthFirstSearch(
//             _ => level++,
//             node => Console.WriteLine($"{new string('\t', level - 1)}{node.Value}"),
//             _ => level--);
//     }
// }