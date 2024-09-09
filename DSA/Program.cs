namespace DSA;

internal class Program
{
    //Data Structures and Algorithms
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        //Stacks();

        //new Hashmaps().Run();
        //new Queues().Run();
        new BinarySearches().Run();
        //new SlidingWindows().Run();

        //var stopwatch = new Stopwatch();

        //var max = 1000000000;
        //var range = Enumerable.Range(0, max).ToArray();
        //var target = new Random().Next(max);
        //Console.WriteLine("target: " + target);
        //Console.WriteLine("Binary search");
        //stopwatch.Start();
        //BinarySearch(range, target);
        //Console.WriteLine("BS DONE " + stopwatch.ElapsedMilliseconds);

        //Console.WriteLine("linear search");

        //stopwatch.Restart();
        //LinearSearch(range, target);
        //Console.WriteLine("LS DONE " + stopwatch.ElapsedMilliseconds);
        //stopwatch.Stop();

        //var builtIn = Array.BinarySearch(range, target);
    }

    public static int[] TwoSum_OofN(int[] nums, int target)
    {
        // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        // You may assume that each input would have exactly one solution, and you may not use the same element twice.
        // You can return the answer in any order.
        // Example 1:
        // Input: nums = [2, 7, 11, 15], target = 9
        // Output: [0, 1]
        // Explanation: Because nums[0] +nums[1] == 9, we return [0, 1].

        //Good Solution - O(n)
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (dict.ContainsKey(complement))
            {
                return new int[] { i, dict[complement] };
            }
            dict[nums[i]] = i;
        }
        return null;
    }
    public static int[] TwoSum_Naive(int[] nums, int target)
    {
        // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        // You may assume that each input would have exactly one solution, and you may not use the same element twice.
        // You can return the answer in any order.
        // Example 1:
        // Input: nums = [2, 7, 11, 15], target = 9
        // Output: [0, 1]
        // Explanation: Because nums[0] +nums[1] == 9, we return [0, 1].

        //Naive
        //Problems: O(n^2) 
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i != j && nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }
        return null;
    }
    public static void Stacks()
    {
        // STACK is LIFO, last in, first out
        // Similar to a List, but it shows intention - if you should read the collection front to back or back to front.
        // Stack
        // - Push adds to the top of the stack
        // - peek views the top item without removing it
        // - Pop removes the item
        var st = new Stack<char>();

        st.Push('A');
        st.Push('B');
        st.Push('C');
        st.Push('D');

        Console.WriteLine("Current stack: ");
        foreach (char c in st)
        {
            Console.Write(c + " ");
        }

        Console.WriteLine();

        st.Push('P');
        st.Push('Q');
        Console.WriteLine("The next poppable value in stack: {0}", st.Peek());
        Console.WriteLine("Current stack: ");

        foreach (char c in st)
        {
            Console.Write(c + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Removing values....");
        st.Pop();
        st.Pop();
        st.Pop();

        Console.WriteLine("Current stack: ");
        foreach (char c in st)
        {
            Console.Write(c + " ");
        }
    }

    public static int BinarySearch(int[] ints, int target)
    {
        var iterations = 0;
        int left = 0;
        int right = ints.Length - 1;
        while (left <= right)
        {
            //var middle = (left + right) / 2;
            var middle = left + ((right - left) / 2);
            if (target == ints[middle])
            {
                Console.WriteLine("Iterations: " + iterations);
                return middle;
            }
            else if (target > ints[middle])
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;

            }
            iterations++;
        }
        return -1;
    }
    public static int LinearSearch(int[] ints, int target)
    {
        for (int i = 0; i < ints.Length; i++)
        {
            if (target == ints[i])
            {
                Console.WriteLine("Iterations: " + i);
                return i;
            }
        }
        return -1;
    }
}
