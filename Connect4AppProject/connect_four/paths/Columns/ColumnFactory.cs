namespace ConsoleApp.connect_four.paths.Columns;

public class ColumnFactory(RowsCollection rowsCollection , DiagonalTree diagonalTree)
{
    public Column Create(int index)
    {
        return new Column(index, rowsCollection , diagonalTree);
    }
}