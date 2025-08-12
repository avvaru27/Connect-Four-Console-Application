using ConsoleApp.connect_four.paths.Columns;

namespace ConsoleApp.connect_four;

public class ColumnsCollection
{
    public readonly List<Column> Columns = new();

    public ColumnsCollection(int totalColumns , ColumnFactory columnFactory)
    {
        var index = 0;

        while (index < totalColumns)
        {
            Columns.Add(columnFactory.Create(index));
            index++;
        }
    }
}