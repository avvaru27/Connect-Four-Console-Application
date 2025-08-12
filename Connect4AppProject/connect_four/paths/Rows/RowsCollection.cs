using ConsoleApp.connect_four.paths;
using ConsoleApp.connect_four.paths.Rows;

namespace ConsoleApp.connect_four;

public class RowsCollection
{
    
    public readonly List<Row> Rows = new();

    public RowsCollection(int totalRows , RowFactory rowFactory)
    {
        var index = 0;

        while (index < totalRows)
        {
            Rows.Add(rowFactory.Create(index));
            index++;
        }
    }
}