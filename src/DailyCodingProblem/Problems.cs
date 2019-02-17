using DailyCodingProblem.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
    }
}