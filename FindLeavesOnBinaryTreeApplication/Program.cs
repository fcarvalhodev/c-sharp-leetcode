using System;
using System.Collections.Generic;
using System.Linq;

namespace FindLeavesOnBinaryTreeApplication
{
    class Program
    {
        public static Dictionary<int, List<int>> nodeMap = new Dictionary<int, List<int>>();

        static void Main(string[] args)
        {
            TreeNode lNode = new TreeNode(2, new TreeNode(4), new TreeNode(5));
            TreeNode rNode = new TreeNode(3);
            TreeNode root = new TreeNode(1, lNode, rNode);

            var result = FindLeaves(root);

            foreach (var item in result)
            {
                Console.WriteLine("------Nodes removed -----");
                foreach (var node in item)
                {
                    Console.WriteLine(node);
                }
            }

            Console.ReadLine();
        }

        private static int Helper(TreeNode node, IDictionary<TreeNode, int> node2LeafLevel)
        {
            if (node == null)
            {
                return -1;
            }

            if (node.left == null && node.right == null)
            {
                node2LeafLevel[node] = 0;
                return 0;
            }

            var left = Helper(node.left, node2LeafLevel);
            var right = Helper(node.right, node2LeafLevel);
            int order = Math.Max(left, right) + 1;
            node2LeafLevel[node] = order;
            return order;
        }

        public static IList<IList<int>> FindLeaves(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }

            IDictionary<TreeNode, int> node2LeafLevel = new Dictionary<TreeNode, int>();
            Helper(root, node2LeafLevel);
            int max = node2LeafLevel.Values.Max();
            IList<IList<int>> res = new List<IList<int>>(max + 1);

            for (int i = 0; i <= max; i++)
            {
                res.Add(new List<int>());
            }

            foreach (var p in node2LeafLevel)
            {
                res[p.Value].Add(p.Key.val);
            }

            return res;
        }
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
