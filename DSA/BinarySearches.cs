namespace DSA;
internal class BinarySearches
{
    //Note: number is leetcode number
    public void Run()
    {
        GuessNumber_374(10);
        GuessNumber_374(1);
        GuessNumber_374(-1);
        GuessNumber_374(0);

        //var list = new int[6] { -1, 0, 3, 5, 9, 12 };
        //Search_704(list, 13);

        //SearchInsert_35(new int[5] { 3, 5, 7, 9, 10 }, 8);
    }
    public int Search_704(int[] nums, int target)
    {
        //Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums.If target exists, then return its index.Otherwise, return -1.
        //You must write an algorithm with O(log n) runtime complexity.
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return -1;
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
    public TreeNode SearchBST_700(TreeNode root, int val)
    {
        if (root.val == val)
        {
            return root;
        }
        else if (root.val < val && root.right != null)
        {
            return SearchBST_700(root.right, val);
        }
        else if (root.left != null)
        {
            return SearchBST_700(root.left, val);
        }
        return null;
    }

    public int[] FindMode_501(TreeNode root)
    {
        //Given the root of a binary search tree(BST) with duplicates, return all the mode(s) (i.e., the most frequently occurred element) in it.
        //If the tree has more than one mode, return them in any order.
        //dict is value, freq
        var dict = new Dictionary<int, int>();
        dfs_501(root, dict);

        var results = new List<int>();
        var max = -1;
        foreach (var key in dict.Keys)
        {
            var value = dict[key];
            if (value > max)
            {
                max = value;
                results = new List<int> { key };
            }
            else if (value == max)
            {
                results.Add(key);
            }
        }
        return results.ToArray();
    }
    private static void dfs_501(TreeNode root, Dictionary<int, int> dict)
    {
        if (root != null)
        {
            if (dict.ContainsKey(root.val))
            {
                dict[root.val]++;
            }
            else
            {
                dict[root.val] = 1;
            }
            dfs_501(root.left, dict);
            dfs_501(root.right, dict);
        }
    }

    public int SearchInsert_35(int[] nums, int target)
    {
        //Given a sorted array of distinct integers and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.
        //You must write an algorithm with O(log n) runtime complexity.
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return left;
    }

    public IList<string> BinaryTreePaths_257(TreeNode root)
    {
        //Given the root of a binary tree, return all root - to - leaf paths in any order.
        //A leaf is a node with no children.
        //Input: root = [1, 2, 3, null, 5]
        //Output: ["1->2->5", "1->3"]
        var results = new List<string>();
        dfs_257(root, results, null);
        return results;
    }
    private static void dfs_257(TreeNode root, List<string> results, string route)
    {
        if (root != null)
        {
            var fullRoute = route == null ? root.val.ToString() : $"{route}->{root.val}";
            if (root.left == null && root.right == null)
            {
                results.Add(fullRoute);
            }
            else
            {
                dfs_257(root.left, results, fullRoute);
                dfs_257(root.right, results, fullRoute);
            }
        }
    }

    public bool IsBalanced_110(TreeNode root)
    {
        //Given a binary tree, determine if it is height balanced
        if (root != null)
        {
            var left = dfs_GetHeight_110(root.left);
            var right = dfs_GetHeight_110(root.right);

            if (Math.Abs(left - right) > 1)
            {
                return false;
            }
            return IsBalanced_110(root.left) && IsBalanced_110(root.right);
        }
        return true;
    }
    private static int dfs_GetHeight_110(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var left = dfs_GetHeight_110(root.left);
        var right = dfs_GetHeight_110(root.right);
        return Math.Max(left, right) + 1;
    }

    public int[] BubbleSort(int[] nums)
    {
        //O(n^2)
        for (int j = 0; j <= nums.Length - 2; j++)
        {
            for (int i = 0; i <= nums.Length - 2; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    var temp = nums[i + 1];
                    nums[i + 1] = nums[i];
                    nums[i] = temp;
                }
            }
        }
        return nums;
    }
    //Given an array of integers nums, sort the array in ascending order and return it.
    //You must solve the problem without using any built-in functions in O(nlog(n)) time complexity and with the smallest space complexity possible.
    public int[] SortArray_912(int[] nums)
    {
        //This is Mergesort O(nlogN)
        //when you repeatedly half something, its logN complexity. Like Binarysearch
        var result = new List<int>();
        var mid = nums.Length / 2;
        if (nums.Length <= 1)
        {
            return nums;
        }

        var leftHalf = new List<int>();
        for (int i = 0; i < mid; i++)
        {
            leftHalf.Add(nums[i]);
        }
        var left = SortArray_912(leftHalf.ToArray()).ToList();

        var rightHalf = new List<int>();
        for (int i = mid; i < nums.Length; i++)
        {
            rightHalf.Add(nums[i]);
        }
        var right = SortArray_912(rightHalf.ToArray()).ToList();

        while (left.Count > 0 || right.Count > 0)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                if (left[0] > right[0])
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
                else
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
            }
            else if (left.Count > 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);

            }
            else if (right.Count > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
        }
        return result.ToArray();
    }

    public IList<int> RightSideView_199(TreeNode root)
    {
        //Given the root of a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
        if (root == null)
        {
            return new List<int>();
        }
        var level = 1;
        var results = new List<int> { root.val };
        dfs_199(root.right, results, level);
        dfs_199(root.left, results, level);

        return results;
    }
    public void dfs_199(TreeNode root, List<int> results, int level)
    {
        level++;
        if (root == null)
        {
            return;
        }
        if (results.Count < level)
        {
            results.Add(root.val);
        }
        dfs_199(root.right, results, level);
        dfs_199(root.left, results, level);
    }

    public int MaxLevelSum_1161(TreeNode root)
    {
        //Given the root of a binary tree, the level of its root is 1, the level of its children is 2, and so on.
        //Return the smallest level x such that the sum of all the values of nodes at level x is maximal.
        var dict = new Dictionary<int, int>();
        dfs_1161(root, dict, 0);

        var maxValue = int.MinValue;
        var maxIndex = int.MinValue;
        foreach (var item in dict)
        {
            if (item.Value > maxValue)
            {
                maxValue = item.Value;
                maxIndex = item.Key;
            }
        }
        return maxIndex;
    }

    private void dfs_1161(TreeNode root, Dictionary<int, int> dict, int level)
    {
        level++;
        if (root == null)
        {
            return;
        }

        if (dict.ContainsKey(level))
        {
            dict[level] = dict[level] + root.val;
        }
        else
        {
            dict[level] = root.val;
        }

        dfs_1161(root.left, dict, level);
        dfs_1161(root.right, dict, level);
    }

    public int MaxDepth_104(TreeNode root) => dfs_104(root, 0);
    private int dfs_104(TreeNode root, int level)
    {
        level++;
        if (root == null)
        {
            return 0;
        }
        var left = dfs_104(root.left, level);
        var right = dfs_104(root.right, level);
        return Math.Max(left, Math.Max(level, right));
    }

    public bool LeafSimilar_872(TreeNode root1, TreeNode root2)
    {
        var left = new List<int>();
        dfs_872(root1, left);

        var right = new List<int>();
        dfs_872(root2, right);

        if (right.Count != left.Count)
        {
            return false;
        }

        for (int i = 0; i < left.Count; i++)
        {
            if (right[i] != left[i])
            {
                return false;
            }
        }
        return true;
    }
    private void dfs_872(TreeNode root, List<int> results)
    {
        if (root == null)
        {
            return;
        }
        if (root.left == null && root.right == null)
        {
            results.Add(root.val);
        }
        else
        {
            dfs_872(root.left, results);
            dfs_872(root.right, results);
        }
    }

    public int GoodNodes_1448(TreeNode root)
    {
        //Given a binary tree root, a node X in the tree is named good if in the path from root to X there are no nodes with a value greater than X.
        //Return the number of good nodes in the binary tree.
        if (root.left == null && root.right == null)
        {
            return 1;
        }
        dfs_1448(root, root.val);
        return goodNodes_1448;
    }
    private int goodNodes_1448 { get; set; }
    private void dfs_1448(TreeNode root, int currentMax)
    {
        if (root == null)
        {
            return;
        }
        if (root.val >= currentMax)
        {
            currentMax = root.val;
            goodNodes_1448++;
        }
        dfs_1448(root.left, currentMax);
        dfs_1448(root.right, currentMax);
    }

    public TreeNode DeleteNode_450_WRONG(TreeNode root, int key)
    {
        if (root?.val == key)
        {
            if (root.left == null && root.right == null)
            {
                return null;
            }
            else if (root.left != null && root.right != null)
            {
                if (root.left.val >= root.right.val)
                {
                    orphanedNode_450 = root.right;
                    root = root.left;
                }
                else
                {
                    orphanedNode_450 = root.left;
                    root = root.right;
                }
            }
            else if (root.left != null)
            {
                orphanedNode_450 = root.right;
                root = root.left;
            }
            else if (root.right != null)
            {
                orphanedNode_450 = root.left;
                root = root.right;
            }
        }
        dfs_450(root, key);
        return root;
    }
    private TreeNode orphanedNode_450 { get; set; }
    private void dfs_450(TreeNode root, int key)
    {
        if (root == null)
        {
            return;
        }

        if (orphanedNode_450 != null)
        {
            if (root.left == null && orphanedNode_450.val < root.val)
            {
                root.left = orphanedNode_450;
                orphanedNode_450 = null;
            }
            else if (root.right == null && orphanedNode_450.val > root.val)
            {
                root.right = orphanedNode_450;
                orphanedNode_450 = null;
            }
        }

        if (root.left != null && root.left.val == key)
        {
            var deleteMe = root.left;
            root.left = deleteMe.left;
            orphanedNode_450 = deleteMe.right;
        }
        if (root.right != null && root.right.val == key)
        {
            var deleteMe = root.right;
            root.right = deleteMe.right;
            orphanedNode_450 = deleteMe.left;
        }

        dfs_450(root.left, key);
        dfs_450(root.right, key);
    }

    public int GuessNumber_374(int n)
    {
        var left = 0;
        var right = n;

        while (left <= right)
        {
            var guessValue = left + (right - left) / 2;
            //n = guess(guessValue);

            if (n == 0)
            {
                return guessValue;
            }
            else if (n == -1)
            {
                right = guessValue - 1;
            }
            else if (n == 1)
            {
                left = guessValue + 1;
            }
        }

        return -1;
    }

    public int FindPeakElement_162(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] >= nums[mid + 1])
            {
                right = mid - 1;
            }
            else if (nums[mid] <= nums[mid + 1])
            {
                left = mid + 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }
}
