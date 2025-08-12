namespace ConsoleApp.connect_four;

public class Match
{
    
    private readonly ColumnsCollection _columnsCollection;
    private readonly Connect4Matrix _connect4Matrix;

    public Match(ColumnsCollection columnsCollection, Connect4Matrix connect4Matrix)
    {
        _columnsCollection = columnsCollection;
        _connect4Matrix = connect4Matrix;
    }

    public void StartMatch()
    {
        Console.WriteLine("Welcome to Connect-4!");
        
        Player? player = Player.First;
        
        Console.WriteLine($"{player} will start the game with \"{player.Coin}\"");
        Console.WriteLine($"{player.changeTurns()} will continue the game with \"{player.changeTurns().Coin}\"");
        
        Console.WriteLine("Let's start!");
        
        while (player != null && _connect4Matrix.isConnect4NotFull)
        {
            Console.WriteLine($"{player}\' Turn");
            int columnIndex = PromptForColumn($"Drop your coin in the range of {1} to {_columnsCollection.Columns.Count} : ");
            try
            {
                Column column = _columnsCollection.Columns[columnIndex];
                List<Tuple<int,int>>? PlayerConnected4 = column.AddEntry(player.Coin);
                int rowIndex = column.OccupiedRowIndex;
                _connect4Matrix.SetValue(rowIndex , columnIndex , player.Coin);
                _connect4Matrix.HighLightWinners(PlayerConnected4);
                if (PlayerConnected4!=null)
                {
                    Console.WriteLine($"{player} Declared winner");
                    //_connect4Matrix gets the pairs highlighted;
                    player = null;
                    return;
                }
                player = player.changeTurns();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Invalid Column Entry as it is already filled. Try a different Column Number");
            }
            
        }
        
        Console.WriteLine("The game ends in draw!!!");
    }
    
    
    int PromptForColumn(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message); // Show the prompt
            string input = Console.ReadLine();

            if (int.TryParse(input, out value))
            {
                if (value >= 1 && value <= _columnsCollection.Columns.Count)
                {
                    return value-1;// ✅ Valid integer, exit method
                } 
            }

            Console.WriteLine($"❌Invalid input. Enter Column number in {1} to {_columnsCollection.Columns.Count} range.");
        }
    }
}