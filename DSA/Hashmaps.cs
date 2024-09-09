namespace DSA;
internal class Hashmaps
{
    public void Run()
    {
        EqualPairs_2352([[3, 2, 1], [1, 7, 6], [2, 7, 7]]);
        EqualPairs_2352([[3, 2, 1], [1, 7, 6], [2, 7, 7]]);
    }
    public IList<IList<int>> FindDifference_2215(int[] nums1, int[] nums2)
    {
        var notInLeft = new Dictionary<int, int>();
        var notInRight = new Dictionary<int, int>();
        var leftElems = new Dictionary<int, int>();
        var rightElems = new Dictionary<int, int>();
        foreach (int i in nums1)
        {
            leftElems.TryAdd(i, i);
        }
        foreach (int i in nums2)
        {
            if (!leftElems.ContainsKey(i))
            {
                notInLeft.TryAdd(i, i);
            }
            rightElems.TryAdd(i, i);
        }
        foreach (int i in leftElems.Keys)
        {
            if (!rightElems.ContainsKey(i))
            {
                notInRight.TryAdd(i, i);
            }
        }
        return new List<IList<int>> { notInRight.Keys.ToList(), notInLeft.Keys.ToList() };
    }

    public bool UniqueOccurrences_1207(int[] arr)
    {
        var dict = new Dictionary<int, int>();
        foreach (int i in arr)
        {
            if (!dict.TryAdd(i, 1))
            {
                dict[i]++;
            }
        }
        var results = new HashSet<int>();
        foreach (int i in dict.Values)
        {
            if (!results.Add(i))
            {
                return false;
            }
        }

        return true;
    }

    public bool CloseStrings_1657(string word1, string word2)
    {
        var left = new Dictionary<char, int>();
        var right = new Dictionary<char, int>();

        foreach (char i in word1)
        {
            if (!left.TryAdd(i, 1))
            {
                left[i]++;
            }
        }
        foreach (char i in word2)
        {
            if (!right.TryAdd(i, 1))
            {
                right[i]++;
            }
        }
        if (left.Count != right.Count)
        {
            return false;
        }
        var rightKey = right.Keys.ToHashSet();
        var rightValue = right.Values.ToList();
        foreach (var item in left)
        {
            if (!rightKey.Contains(item.Key) || !rightValue.Contains(item.Value))
            {
                return false;
            }
            rightKey.Remove(item.Key);
            rightValue.Remove(item.Value);
        }
        return true;
    }

    public IList<IList<int>> FindDifference_2215_2(int[] nums1, int[] nums2)
    {
        //O(4n) -> O(n)
        var left = new HashSet<int>();
        var right = new HashSet<int>();
        foreach (int i in nums1)
        {
            left.Add(i);
        }
        foreach (int i in nums2)
        {
            right.Add(i);
        }
        return new List<IList<int>> { left.Except(right).ToList(), right.Except(left).ToList() };
    }
    public int EqualPairs_2352(int[][] grid)
    {
        //Given a 0 - indexed n x n integer matrix grid, return the number of pairs(ri, cj) such that row ri and column cj are equal.
        //A row and column pair is considered equal if they contain the same elements in the same order(i.e., an equal array).
        var matches = 0;
        var rows = new Dictionary<string, int>();
        var columns = new Dictionary<string, int>();
        for (int i = 0; i < grid.Length; i++)
        {
            var key = string.Join(",", grid[i]);
            if (!rows.TryAdd(key, 1))
            {
                rows[key]++;
            }
        }
        for (int i = 0; i < grid.Length; i++)
        {
            var column = new int[grid.Length];
            for (int j = 0; j < grid.Length; j++)
            {
                column[j] = grid[j][i];
            }

            var key = string.Join(",", column);
            if (!columns.TryAdd(key, 1))
            {
                columns[key]++;
            }

            if (rows.ContainsKey(key))
            {
                matches += rows[key];
            }
        }

        return matches;
    }
}
