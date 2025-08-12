using ConsoleApp.connect_four;
using ConsoleApp.connect_four.Diagonal;
using ConsoleApp.connect_four.paths.Diagonal;

public class DiagonalFactory
{
    public Diagonal Create(int rowIndex, int columnIndex)
    {
        return new Diagonal(new Tuple<int, int>(rowIndex, columnIndex));
    }
}