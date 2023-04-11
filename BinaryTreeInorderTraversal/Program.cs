namespace BinaryTreeInorderTraversal;

internal class Program
{
    static void Main(string[] args)
    {
        var result = InorderTraversalIterative(new TreeNode(1, null, new TreeNode(2, new TreeNode(3))));

        foreach (var elem in result)
        {
            Console.Write($"{elem} ");
        }
    }

    public static IList<int> InorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        if (root == null)
            return result;

        result.Add(root.val);
        if (root.left == null && root.right == null)
        {
            return result;
        }

        return InorderTraversal(root.left)
            .Concat(result)
            .Concat(InorderTraversal(root.right))
            .ToList();
    }

    public static IList<int> InorderTraversalIterative(TreeNode root)
    {
        var result = new List<int>();
        
        var stack = new Stack<TreeNode>();

        while (root != null || stack.Count > 0)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }

            root = stack.Pop();
            result.Add(root.val);

            root = root.right;
        }

        return result;
    }

    public class TreeNode
    {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
         {
            this.val = val;
            this.left = left;
            this.right = right;

         }
    }
}