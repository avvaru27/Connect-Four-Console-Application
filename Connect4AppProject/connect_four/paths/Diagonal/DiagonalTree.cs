using ConsoleApp.connect_four;
using ConsoleApp.connect_four.Diagonal;
using ConsoleApp.connect_four.paths.Diagonal;

public class DiagonalTree
{
    public Dictionary<int, Diagonal> positiveSlopeDiagonals;
    public Dictionary<int, Diagonal> negativeSlopeDiagonals;

    public DiagonalTree(int totalRows, int totalColumns , DiagonalFactory diagonalFactory)
    {
        positiveSlopeDiagonals = new();
        negativeSlopeDiagonals = new();
        var columnIndex = 0;
        var rowIndex = 0;
        while (columnIndex <= totalColumns - (Utils.CoinsToWin))
        {
            positiveSlopeDiagonals.Add(rowIndex - columnIndex , diagonalFactory.Create(rowIndex, columnIndex));
            columnIndex++;
        }
        columnIndex = 0;
        rowIndex = 1;
        while (rowIndex <= totalRows - (Utils.CoinsToWin))
        {
            positiveSlopeDiagonals.Add(rowIndex - columnIndex, diagonalFactory.Create(rowIndex, columnIndex));
            rowIndex++;
        }
        ///Positive Slope complete
        
        rowIndex = totalRows - 1;
        columnIndex = 0;

        while (columnIndex <= totalColumns - (Utils.CoinsToWin))
        {
            negativeSlopeDiagonals.Add(rowIndex+columnIndex , diagonalFactory.Create(rowIndex, columnIndex));
            columnIndex++;
        }

        rowIndex = totalRows - 2;
        columnIndex = 0;

        while (rowIndex >= totalRows - (Utils.CoinsToWin))
        {
            negativeSlopeDiagonals.Add(rowIndex+columnIndex, diagonalFactory.Create(rowIndex, columnIndex));
            
            rowIndex--;
        }

    }
}