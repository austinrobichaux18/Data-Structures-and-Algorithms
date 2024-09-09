namespace DSA;
internal class Queues
{
    public void Run()
    {
        PredictPartyVictory_649("DDRRR");
        PredictPartyVictory_649("DDRRR");
    }
    public Queue<int> queue_933 { get; set; } = new Queue<int>();
    public int Ping_933(int t)
    {
        // You have a RecentCounter class which counts the number of recent requests within a certain time frame.
        // Adds a new request at time t, where t represents some time in milliseconds,
        // and returns the number of requests that has happened in the past 3000 milliseconds(including the new request).
        // Specifically, return the number of requests that have happened in the inclusive range[t - 3000, t].
        var limit = t - 3000;
        queue_933.Enqueue(t);

        while (queue_933.Count > 0 && queue_933.Peek() < limit)
        {
            queue_933.Dequeue();
        }
        return queue_933.Count;
    }

    public string PredictPartyVictory_649(string senate)
    {
        var queue = new Queue<char>();
        foreach (char c in senate)
        {
            queue.Enqueue(c);
        }

        var done = false;
        while (!done)
        {
            var value = queue.Dequeue();
            queue.Enqueue(value);

            var index = 0;
            while (queue.Peek() == value)
            {
                var sameTeam = queue.Dequeue();
                queue.Enqueue(sameTeam);
                index++;
                if (index > queue.Count)
                {
                    done = true;
                    break;
                }
            }
            if (!done)
            {
                queue.Dequeue();
            }
            for (int i = 0; i < queue.Count - index; i++)
            {
                var reset = queue.Dequeue();
                queue.Enqueue(reset);
            }
        }
        return queue.Peek() == 'R' ? "Radiant" : "Dire";
    }
}
