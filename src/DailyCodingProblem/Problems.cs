using DailyCodingProblem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyCodingProblem
{
    public class Problems
    {
        /*
           This problem was recently asked by Google.           
           Given a list of numbers and a number k, return whether any two numbers the list add up to k.           
           For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.           
           Bonus: Can you do this in one pass?
         */
        public static bool DoesTwoNumbersAddUp(int[] array, int number)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /*
           This problem was asked by Uber.
Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.
For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].
Follow-up: what if you can't use division?
         */
        public static int[] TransformUsingDivision(int[] input)
        {
            var transformed = new int[input.Length];
            long allMultiplied = 1;
            foreach (var i in input)
            {
                allMultiplied *= i;
            }

            for (int i = 0; i < input.Length; i++)
            {
                transformed[i] = (int) (allMultiplied / input[i]);
            }

            return transformed;
        }

        /*
           This problem was asked by Google.
           
           Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.
           
           For example, given the following Node class
           
           class Node:
           def __init__(self, val, left=None, right=None):
           self.val = val
           self.left = left
           self.right = right
           The following test should pass:
           
           node = Node('root', Node('left', Node('left.left')), TreeNode('right'))
           assert deserialize(serialize(node)).left.left.val == 'left.left'
         */
        public class TreeNode
        {
            public string Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }

            public TreeNode(string value, TreeNode left, TreeNode right)
            {
                Value = value;
                Left = left;
                Right = right;
            }
        }

        public static string SerilalizeRoot(TreeNode root)
        {
            return string.Empty;
        }

        public static TreeNode DeserilalizeRoot(string serialized)
        {
            return null;
        }

        /*
           This problem was asked by Stripe.
           
           Given an array of integers, find the first missing positive integer in linear time and constant space. 
           In other words, find the lowest positive integer that does not exist in the array. 
           The array can contain duplicates and negative numbers as well.
           
           For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.
           
           You can modify the input array in-place.
         */
        public static int GetFirstMissingPositiveNumber(int[] array)
        {
            SortedDictionary<int, int> keys = new SortedDictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    keys[array[i]] = 1;
                }
            }

            int missing = 1;
            foreach (var key in keys.Keys)
            {
                if (key != missing)
                {
                    break;
                }

                missing++;
            }

            return missing;
        }

        /*
         *This problem was asked by Google.
Given a list of integers S and a target number k, write a function that returns a subset of S that adds up to k. If such a subset cannot be made, then return null.
Integers can appear more than once in the list. You may assume all numbers in the list are positive.
For example, given S = [12, 1, 61, 5, 9, 2] and k = 24, return [12, 9, 2, 1] since it sums up to 24.
         */
        public static int[] GetSubsetAddingToNumber(int[] arr, int requiredSum)
        {
            if (requiredSum == 0)
            {
                return new int[0];
            }

            if (requiredSum < 0)
            {
                return null;
            }

            var total = arr.Sum();
            if (total < requiredSum)
            {
                return null;
            }

            if (total == requiredSum)
            {
                return arr;
            }

            List<int> subset = new List<int>(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                var a = arr[i];
                subset.Clear();
                subset.Add(a);
                var subArr = GetSubsetAddingToNumber(GetArrayWithoutIndexValue(arr, i), requiredSum - a);
                if (subArr != null)
                {
                    subset.AddRange(subArr);
                    return subset.ToArray();
                }

                continue;
            }

            return null;
        }

        private static int[] GetArrayWithoutIndexValue(int[] arr, int indexToRemove)
        {
            int[] newArray = new int[arr.Length - 1];
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == indexToRemove)
                {
                    continue;
                }

                newArray[j++] = arr[i];
            }

            return newArray;
        }

        /*
         * This problem was asked by Google.
Given the head of a singly linked list, reverse it in-place.
         */
        public static void Rearrange(SllNode head)
        {
            Rearrange(head, head.Next, head.Next?.Next);
        }

        private static void Rearrange(SllNode head, SllNode first, SllNode second)
        {
            if (second != null) // Can happen when list has only 1 item
            {
                if (second.Next == null)
                {
                    head.Next = second;
                }
                else
                {
                    Rearrange(head, second, second.Next);
                }

                second.Next = first;
            }
            else
            {
                head.Next = first;
            }

            first.Next = null;
        }

        /*
         * Given k sorted singly list, write a function to merge all
    into once sorted singly linked list
         */
        public static SllNode GetMergedList(IList<SllNode> headNodes)
        {
            SllNode mergeNodeHead = new SllNode();
            SllNode lastNodeInMergeList = null;
            while (headNodes.Any(h => h.Next != null))
            {
                SllNode minHead = null;
                foreach (var head in headNodes)
                {
                    if (head.Next == null)
                    {
                        continue;
                    }

                    if (minHead == null)
                    {
                        minHead = head;
                    }
                    else if (head.Next.Val <= minHead.Next.Val)
                    {
                        minHead = head;
                    }
                }

                if (mergeNodeHead.Next == null)
                {
                    mergeNodeHead.Next = minHead.Next;
                    lastNodeInMergeList = minHead.Next;
                }
                else
                {
                    lastNodeInMergeList.Next = minHead.Next;
                    lastNodeInMergeList = minHead.Next;
                }

                minHead.Next = minHead.Next.Next;
            }

            return mergeNodeHead;
        }

        /*
         * Given a list of possibly overlapping intervals, return a new list of intervals where all overlapping intervals have been merged.
         The input list is not necessarily ordered in any way.
         For example, given [(1, 3), (5, 8), (4, 10), (20, 25)], you should return [(1, 3), (4, 10), (20, 25)].         
         */
        public static IList<RangeNode> GetMergedNodes(IList<RangeNode> originalNodes)
        {
            IList<RangeNode> mergedNodes = new List<RangeNode>(originalNodes.Count);
            RangeNode previousNode = null;
            foreach (var originalNode in originalNodes.OrderBy(n => n.Start))
            {
                var candidateNode = originalNode;
                if (previousNode != null)
                {
                    if (NodesOverlap(originalNode, previousNode))
                    {
                        mergedNodes.Remove(previousNode);
                        candidateNode = new RangeNode(
                            Math.Min(originalNode.Start, previousNode.Start),
                            Math.Max(originalNode.End, previousNode.End));
                    }
                }

                mergedNodes.Add(candidateNode);
                previousNode = candidateNode;
            }

            return mergedNodes;
        }

        private static bool NodesOverlap(RangeNode firstNode, RangeNode secondNode)
        {
            return (firstNode.Start >= secondNode.Start && firstNode.Start <= secondNode.End) ||
                   (firstNode.End >= secondNode.Start && firstNode.End <= secondNode.End) ||
                   (firstNode.Start <= secondNode.Start && firstNode.End >= secondNode.End);
        }

        /*
         * This problem was asked by Google.
Given the root of a binary tree, return a deepest node. For example, in the following tree, return d.
    1
   / \
  2   3
 /
4
*/
        public static BTreeNode GetDeepestNode(BTreeNode rootNode, out int depth)
        {
            if (rootNode == null)
            {
                depth = 0;
                return null;
            }

            depth = 1;
            BTreeNode deepestLeftTreeNode = GetDeepestNode(rootNode.Left, out int leftTreeDepth);
            BTreeNode deepestRightTreeNode = GetDeepestNode(rootNode.Right, out int rightTreeDepth);
            if (leftTreeDepth == 0 && rightTreeDepth == 0) // no left or right trees
            {
                return rootNode;
            }

            if (leftTreeDepth >= rightTreeDepth)
            {
                depth += leftTreeDepth;
                return deepestLeftTreeNode;
            }

            depth += rightTreeDepth;
            return deepestRightTreeNode;
        }

        /*
         * This problem was asked by Google.

Invert a binary tree.

For example, given the following tree:

    a
   / \
  b   c
 / \  /
d   e f
should become:

  a
 / \
 c  b
 \  / \
  f e  d
         */
        public static void InvertBinaryTreee(BTreeNode rootNode)
        {
            if (rootNode == null)
            {
                return;
            }

            InvertBinaryTreee(rootNode.Left);
            InvertBinaryTreee(rootNode.Right);

            var temp = rootNode.Left;
            rootNode.Left = rootNode.Right;
            rootNode.Right = temp;
        }

        /*
         * This problem was asked by Google.
         * Given a set of closed intervals, find the smallest set of numbers that covers all the intervals.
         * If there are multiple smallest sets, return any of them.
         * For example, given the intervals [0, 3], [2, 6], [3, 4], [6, 9], one set of numbers that covers all these intervals is {3, 6}.
         */
        public static IEnumerable<int> GetSmallestSet(IList<RangeNode> nodes)
        {
            if (nodes.Count == 0)
            {
                return Enumerable.Empty<int>();
            }

            BTreeNode tree = new BTreeNode {Val = -1};
            foreach (var rangeNode in nodes)
            {
                AddToLeafNode(tree, rangeNode);
            }

            return GetItemsInShortestPath(tree).Except(new[] {-1});
        }

        private static IEnumerable<int> GetItemsInShortestPath(BTreeNode treeNode)
        {
            if (treeNode == null)
            {
                return Enumerable.Empty<int>();
            }

            var currentItem = new[] {treeNode.Val};
            if (treeNode.Left == null) // Right will also be null
            {
                return currentItem;
            }

            var leftSubTreeItemsInShortestPath = GetItemsInShortestPath(treeNode.Left).ToList();
            var rightSubTreeItemsInShortestPath = GetItemsInShortestPath(treeNode.Right).ToList();

            return (leftSubTreeItemsInShortestPath.Count <= rightSubTreeItemsInShortestPath.Count
                ? leftSubTreeItemsInShortestPath
                : rightSubTreeItemsInShortestPath).Union(currentItem);
        }

        private static void AddToLeafNode(BTreeNode treeNode, RangeNode rangeNode)
        {
            if (treeNode == null)
            {
                return;
            }

            // if node already has one of the value, ignore.
            if (treeNode.Val == rangeNode.Start || treeNode.Val == rangeNode.End)
            {
                return;
            }

            if (treeNode.Left == null) // Right will also be null
            {
                treeNode.Left = new BTreeNode {Val = rangeNode.Start};
                treeNode.Right = new BTreeNode {Val = rangeNode.End};
            }
            else
            {
                AddToLeafNode(treeNode.Left, rangeNode);
                AddToLeafNode(treeNode.Right, rangeNode);
            }
        }

        /*
         *This problem was asked by Google.
         * Given two non-empty binary trees s and t, check whether tree t has exactly the same structure and node values with a subtree of s.
         * A subtree of s is a tree consists of a node in s and all of this node's descendants. The tree s could also be considered as a subtree of itself.
         */
        public static bool HasSubTree(BTreeNode main, BTreeNode subtree)
        {
            if (main == null)
            {
                return subtree == null;
            }

            if (main.Val == subtree.Val && HasSubTree(main.Left, subtree.Left) &&
                HasSubTree(main.Right, subtree.Right))
            {
                return true;
            }

            if (HasSubTree(main.Left, subtree) || HasSubTree(main.Right, subtree))
            {
                return true;
            }

            return false;
        }

        /*
         * This problem was asked by Facebook.
         * Given a string and a set of delimiters, reverse the words in the string while maintaining the relative order of the delimiters.
         * For example, given "hello/world:here", return "here/world:hello"
         * Follow-up: Does your solution work for the following cases: "hello/world:here/", "hello//world:here"
         */
        public static string SplitJoinPreservingDelimiters(string input, char[] delimiters)
        {
            List<char> delimiterOrder = new List<char>();
            List<string> wordsOrder = new List<string>();
            string word = string.Empty;

            foreach (char t in input)
            {
                if (delimiters.Contains(t))
                {
                    delimiterOrder.Add(t);
                    wordsOrder.Add(word);
                    word = string.Empty;
                }
                else
                {
                    word += t;
                }
            }

            wordsOrder.Add(word);

            StringBuilder sb = new StringBuilder();
            for (int i = wordsOrder.Count - 1, j = 0; i > 0; i--, j++)
            {
                sb.Append($"{wordsOrder[i]}{delimiterOrder[j]}");
            }

            sb.Append(wordsOrder[0]);

            return sb.ToString();
        }

        /*
         * This problem was asked by Alibaba.
         * Given an even number (greater than 2), return two prime numbers whose sum will be equal to the given number.
         * A solution will always exist. See Goldbach’s conjecture.
         * Example:
         * Input: 4
         * Output: 2 + 2 = 4
         * If there are more than one solution possible, return the lexicographically smaller solution.
         * If [a, b] is one solution with a <= b, and [c, d] is another solution with c <= d, then [a, b] < [c, d] If a < c OR a==c AND b < d.
         */
        public static Tuple<int, int> GetTwoPrimeWithSumEquals(int sum)
        {
            int first = 2;
            int second = sum - first;
            while (!IsPrime(first) || !IsPrime(second))
            {
                first++;
                second = sum - first;
            }

            return new Tuple<int, int>(first, second);
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            var boundary = (int) Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /*
         * This problem was asked by Google.
         * Given a sorted list of integers, square the elements and give the output in sorted order.
         * For example, given [-9, -2, 0, 2, 3], return [0, 4, 4, 9, 81].
         */
        public static IEnumerable<int> GetOrderedSquares(int[] array)
        {
            // we split the array into two. Once half will be negative numbers and other will be 0 and +ve numbers.
            // iterated on both halfs comparing the absolute values since square of -ve will be a +ve number

            // right will have the index for first 0 or +ve number
            int right;
            for (right = 0; right < array.Length; right++)
            {
                if (array[right] >= 0)
                {
                    break;
                }
            }

            int left = right - 1;
            while (left >= 0 && right < array.Length)
            {
                if (Math.Abs(array[left]) > array[right])
                {
                    yield return GetSquareAndIncrementIndex(array, ref right, 1);
                }
                else
                {
                    yield return GetSquareAndIncrementIndex(array, ref left, -1);
                }
            }
            // at this one of left or right will have reached the end. Return the remaining in the other. 
            while (left >= 0)
            {
                yield return GetSquareAndIncrementIndex(array, ref left, -1);
            }

            while (right < array.Length)
            {
                yield return GetSquareAndIncrementIndex(array, ref right, 1);
            }
        }

        private static int GetSquareAndIncrementIndex(int[] array, ref int index, int increment)
        {
            var item = array[index];
            index += increment;
            return item * item;
        }

        /*
         * This problem was asked by Microsoft.
         * Implement the singleton pattern with a twist.
         * First, instead of storing one instance, store two instances.
         * And in every even call of getInstance(), return the first instance and in every odd call of getInstance(),
         * return the second instance.
         */
        public class TwoInstanceSingleton
        {
            private TwoInstanceSingleton()
            {
            }

            private static int _instanceCount;

            private static readonly Lazy<TwoInstanceSingleton> LazyOddInstance =
                new Lazy<TwoInstanceSingleton>(() => new TwoInstanceSingleton());

            private static readonly Lazy<TwoInstanceSingleton> LazyEvenInstance =
                new Lazy<TwoInstanceSingleton>(() => new TwoInstanceSingleton());

            private static readonly object LockObject = new object();

            public static TwoInstanceSingleton Instance
            {
                get
                {
                    lock (LockObject)
                    {
                        _instanceCount++;
                        return _instanceCount % 2 == 0 ? LazyEvenInstance.Value : LazyOddInstance.Value;
                    }
                }
            }
        }

        /*
         * This question was asked by Zillow.
         * You are given a 2-d matrix where each cell represents number of coins in that cell.
         * Assuming we start at matrix[0][0], and can only move right or down,
         * find the maximum number of coins you can collect by the bottom right corner.
         * For example, in this matrix
         * 0 3 1 1
         * 2 0 0 4
         * 1 5 3 1
         * The most we can collect is 0 + 2 + 1 + 5 + 3 + 1 = 12 coins.
         */
        public static int GetMaxCoins(int[,] array)
        {
            /* Solution is to construct a binary tree with the root = array[0,0]
             * Left of node will be value of down element, right of node will be value of right element
             * In case of a a[2,2], the tree will be as below
             *                a[0,0]
             *               /     \
             *              /       \
             *          a[1,0]     a[0,1]
             *              \       /
             *               \     /
             *            a[1,1] a[1,1]
             * Once we have the tree, we select the path to leaf with the highest sum. That will be the result.
             */ 
            var root = new BTreeNode {Val = array[0,0]};
            AddChildren(root, array, 0, 0);

            return GetMaxCountToLeaf(root);
        }

        private static int GetMaxCountToLeaf(BTreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            var leftCount = GetMaxCountToLeaf(node.Left);
            var rightCount = GetMaxCountToLeaf(node.Right);
            return node.Val + Math.Max(leftCount, rightCount);
        }

        private static void AddChildren(BTreeNode parent, int[,] array, int rowIndex, int colIndex)
        {
            var rowCount = array.GetLength(0);
            var colCount = array.GetLength(1);
            if (rowIndex + 1 < rowCount && colIndex < colCount)
            {
                parent.Left = new BTreeNode {Val = array[rowIndex + 1, colIndex]};
                AddChildren(parent.Left, array, rowIndex + 1, colIndex);
            }
            if (rowIndex < rowCount && colIndex + 1 < colCount)
            {
                parent.Right = new BTreeNode { Val = array[rowIndex, colIndex + 1] };
                AddChildren(parent.Right, array, rowIndex, colIndex + 1);
            }
        }
    }
}