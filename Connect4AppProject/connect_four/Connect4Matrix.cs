namespace ConsoleApp.connect_four;

public class Connect4Matrix
{
    
    private List<List<Char?>> matrix = new();

    private int valueCounter = 0;

    private readonly int maxValues;

    public Boolean isConnect4NotFull
    {
        get
        {
            return valueCounter != maxValues;
        }
    }

    public Connect4Matrix(int row, int column)
    {
        var rowIndex = 0;

        while (rowIndex < row)
        {
            var columnIndex = 0;
            matrix.Add(new List<Char?>());
            while (columnIndex < column)
            {
                matrix[rowIndex].Add(null);
                columnIndex++;
            }
            rowIndex++;
        }

        maxValues = row * column;
    }


    public void SetValue(int rowIndex, int colIndex , Char? Coin)
    {
        matrix[rowIndex][colIndex] = Coin;
        valueCounter++;
    }

    public void HighLightWinners(List<Tuple<int, int>>? winningValue) {
        if (matrix == null || matrix.Count == 0)
        {
            return;
        }
        int rows = matrix.Count; 
        int cols = matrix[0].Count; 
        // Precompute winners set for O(1) lookup
        var winnerSet = new HashSet<(int, int)>(); 
        bool hasWinners = winningValue != null && winningValue.Count > 0;
        if (hasWinners) { 
            foreach (var (wr, wc) in winningValue) 
                winnerSet.Add((wr, wc)); 
        } 
        string horizontalBorder = "+" + string.Join("+", Enumerable.Repeat("---", cols)) + "+"; 
        int consoleWidth = Console.WindowWidth; 

        int headerRowLength = cols * 4 + 1; 
        int headerPadding = Math.Max((consoleWidth - headerRowLength) / 2, 0);
        Console.Write(new string(' ', headerPadding));
        for (int c = 0; c < cols; c++)
        {
            Console.Write("  " + (c + 1) + " ");
        }

        Console.WriteLine();
        
        for (int r = rows - 1; r > -1; r--) 
        {
            
            int topBorderPadding = Math.Max((consoleWidth - horizontalBorder.Length) / 2, 0); 
            Console.WriteLine(new string(' ', topBorderPadding) + horizontalBorder);

            int leftPadding = Math.Max((consoleWidth - headerRowLength) / 2, 0);
            Console.Write(new string(' ', leftPadding));
            for (int c = 0; c < cols; c++) 
            { 
                Console.Write("| "); 
                if (hasWinners && winnerSet.Contains((r, c))) 
                { 
                    Console.ForegroundColor = ConsoleColor.Green; 
                }
                
                var cell = matrix[r][c]; 
                string value = cell.HasValue ? cell.Value.ToString() : " "; 
                Console.Write(value);
                
                Console.ResetColor(); 
                Console.Write(" "); 
            } 
            Console.WriteLine("|"); 
        } 
        int bottomBorderPadding = Math.Max((consoleWidth - horizontalBorder.Length) / 2, 0); 
        Console.WriteLine(new string(' ', bottomBorderPadding) + horizontalBorder); 
    }

    

}