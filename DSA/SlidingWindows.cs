namespace DSA;
internal class SlidingWindows
{
    public void Run()
    {
        LengthOfLongestSubstring_Naive("abcabcbb");
        LengthOfLongestSubstring_Naive("abcabcbb");
    }
    public int LengthOfLongestSubstring_Naive(string s)
    {
        //TODO Try this one again https://leetcode.com/problems/longest-substring-without-repeating-characters/ 
        //and use sliding window instead of this Naive approach
        //Given a string s, find the length of the longest
        //Input: s = "abcabcbb"
        //Output: 3
        //Explanation: The answer is "abc", with the length of 3.
        var result = 0;
        var word = "";
        for (int i = 0; i < s.Length; i++)
        {
            if (!word.Contains(s[i]))
            {
                word += s[i];
            }
            else
            {
                result = result > word.Length ? result : word.Length;
                word = word.Split(s[i])[1] + s[i].ToString();
            }
            if (i == s.Length - 1)
            {
                result = result > word.Length ? result : word.Length;
            }
        }
        return string.IsNullOrEmpty(s) ? 0 : result;
    }

    public double FindMaxAverage(int[] nums, int k)
    {
        var max = double.MinValue;
        var current = 0.0;

        if (nums.Length == k)
        {
            var avg = (double)nums.Sum() / k;
            if (avg > max)
            {
                max = avg;
            }
            return max;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (i < k)
            {
                current += nums[i];
            }
            else
            {
                current -= nums[i - k];
                current += nums[i];

                var avg = current / k;
                if (avg > max)
                {
                    max = avg;
                }
            }
        }
        return max;
    }
}
