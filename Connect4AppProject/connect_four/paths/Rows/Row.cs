namespace ConsoleApp.connect_four.paths;

public class Row : Path
{
    
    
    public Row(int rowPathIndex)
    {
        PathIndex = rowPathIndex;
    }


    protected override List<Tuple<int, int>>? AddConnected4Paths(char entry, object? extras = null)
    {
        var result = new List<Tuple<int,int>>();
        ///Emit event that player with char has won
        ValidationHashMap[entry].ForEach((pathIndex) =>
        {
            result?.Add(new Tuple<int,int>(PathIndex , pathIndex));
        });
        return result;
    }
}