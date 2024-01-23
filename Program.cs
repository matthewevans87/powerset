internal class Program
{
    private static void Main(string[] args)
    {
        var inputSet = new List<int>() { 1, 2, 3, 4, 5 };
        Console.WriteLine($"Input Set ({inputSet.Count}):");
        PrintSet(inputSet);

        var powerSet = GetPowerSet(inputSet);
        Console.WriteLine($"Power Set ({powerSet.Count}):");
        powerSet.ForEach(e => PrintSet(e));
    }

    private static List<List<int>> GetPowerSet(IList<int> inputSet)
    {
        var powerSet = new List<List<int>>();
        int psSize = 1 << inputSet.Count;   //2 ^ n
        for (int i = 0; i < psSize; i++)
        {
            powerSet.Add(GetSet(i, inputSet));
        }
        return powerSet;
    }

    private static List<int> GetSet(int flags, IList<int> inputSet)
    {
        var resultSet = new List<int>();
        int mutFlags = flags;
        int shift = 0;
        while (mutFlags > 0)
        {
            var isSet = mutFlags & 1;
            if (isSet == 1)
            {
                resultSet.Add(inputSet[shift]);
            }
            shift++;
            mutFlags >>= 1;
        }
        return resultSet;
    }

    private static void PrintSet(List<int> set)
    {
        var output = $"{{{string.Join(", ", set)}}}";
        Console.WriteLine(output);
    }
}