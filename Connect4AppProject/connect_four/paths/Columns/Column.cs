using System.Collections;
using ConsoleApp.connect_four.Diagonal;
using ConsoleApp.connect_four.paths;
using Path = ConsoleApp.connect_four.paths.Path;

namespace ConsoleApp.connect_four;

public class Column : Path
{
    private int _rowIndexToOccupy = -1;

    private readonly RowsCollection _rowsCollection;
    private readonly DiagonalTree _diagonalTree;
    
    public Column(int Index , RowsCollection rowsCollection , DiagonalTree diagonalTree) {
        PathIndex = Index;
        _rowsCollection = rowsCollection;
        _diagonalTree = diagonalTree;
    }

    public int OccupiedRowIndex
    {
        get{
            return _rowIndexToOccupy;
        }
    }


    public override List<Tuple<int, int>>? AddEntry(char entry, int? indexData = null , object? extras = null)
    {
        _rowIndexToOccupy++;
        
        if (ValidationHashMap.ContainsKey(entry))
        {
            ValidationHashMap[entry].Add(OccupiedRowIndex);
        }
        else{
            ValidationHashMap.Add(entry ,new List<int>() { OccupiedRowIndex } );
        }

        var columnResults = ValidateEntries(entry);

        if ( columnResults != null)
        {
            return columnResults;
        }
        
        var rowResults = ValidateRowValues(entry);
        
        if (rowResults != null)
        {
            return rowResults;
        }
        
        var diagonalResults = ValidateDiagonal(entry);

        return diagonalResults;
    }

    protected override List<Tuple<int, int>>? AddConnected4Paths(char entry , Object? extras = null)
    {
        var result = new List<Tuple<int,int>>();
        ///Emit event that player with char has won
        ValidationHashMap[entry].ForEach((pathIndex) =>
        {
            result.Add(new Tuple<int,int>(pathIndex , PathIndex));
                
        });
        return result;
    }


    List<Tuple<int,int>>? ValidateRowValues(Char entry)
    {
        Row row = _rowsCollection.Rows[OccupiedRowIndex];
        return row.AddEntry(entry , PathIndex);
    }
    
    

    List<Tuple<int,int>>? ValidateDiagonal(Char entry)
    {
        
        var rowIndex = OccupiedRowIndex;
        var columnIndex = PathIndex;
        ///Fetch 2 Columns
        var keyForPositiveSlope = rowIndex - columnIndex;
        List<Tuple<int, int>>? positiveSlopeResult = null;
        if (_diagonalTree.positiveSlopeDiagonals.ContainsKey(keyForPositiveSlope))
        {
            var diagonal = _diagonalTree.positiveSlopeDiagonals[keyForPositiveSlope];
            var diagonalRowIndex = diagonal.Start.Item1;
            positiveSlopeResult = diagonal.AddEntry(entry , rowIndex - diagonalRowIndex , extras: DiagonalSlope.Positive);
        }

        if (positiveSlopeResult != null)
        {
            return positiveSlopeResult;
        }
        
        var keyForNegativeSlope = rowIndex + columnIndex;
        List<Tuple<int, int>>? negativeSlopeResult = null;
        if (_diagonalTree.negativeSlopeDiagonals.ContainsKey(keyForNegativeSlope))
        {
            var diagonal = _diagonalTree.negativeSlopeDiagonals[keyForNegativeSlope];
            var diagonalRowIndex = diagonal.Start.Item1;
            negativeSlopeResult = diagonal.AddEntry(entry , diagonalRowIndex - rowIndex , extras: DiagonalSlope.Negative);
        }
        
        return negativeSlopeResult;

        
    }
    
}