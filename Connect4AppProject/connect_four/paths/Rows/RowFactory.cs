namespace ConsoleApp.connect_four.paths.Rows;

public class RowFactory
{
    public Row Create(int index)
    {
        return new Row(index);
    }
}