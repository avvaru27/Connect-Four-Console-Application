namespace ConsoleApp;

public class Player
{
    public static readonly Player First = new Player('X');
    public static readonly Player Second = new Player('O');

    public Char Coin { get; }

    public override string ToString()
    {
        if (Coin == 'X')
        {
            return "Player-A";
        }
        return "Player-B";
    }

    private Player(Char coin)
    {
        Coin = coin;
    }

    public Player changeTurns()
    {
        if (this == First)
        {
            return Second;
        }

        return First;
    }
}
