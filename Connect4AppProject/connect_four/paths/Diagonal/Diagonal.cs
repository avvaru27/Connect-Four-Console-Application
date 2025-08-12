using ConsoleApp.connect_four.Diagonal;

namespace ConsoleApp.connect_four.paths.Diagonal;

public class Diagonal(Tuple<int, int> start) : Path
{
    public readonly Tuple<int, int> Start = start;

    protected override List<Tuple<int, int>>? AddConnected4Paths(char entry, object? extras)
    {
        DiagonalSlope? slope = extras as DiagonalSlope?;
        var result = new List<Tuple<int,int>>();
        if (slope == DiagonalSlope.Positive)
        {
            
            ValidationHashMap[entry].ForEach((pathIndex) =>
            {
                result?.Add(new Tuple<int,int>(Start.Item1 + pathIndex , Start.Item2 + pathIndex));
            });
            return result;
        }
        ValidationHashMap[entry].ForEach((pathIndex) =>
        {
            result?.Add(new Tuple<int,int>(Start.Item1 - pathIndex ,Start.Item2 + pathIndex));
        });
        return result;
    }
}