using ConsoleApp.connect_four;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;

public class Game
{

    private readonly IServiceProvider _serviceProvider;


    public Game(
        IServiceProvider serviceProvider
        )
    {

        _serviceProvider = serviceProvider;
    }


    public void StartGame()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var match = scope.ServiceProvider.GetRequiredService<Match>();
            match.StartMatch();
        }
    }

    public void RestartGame()
    {
        Console.Write("Would you like to restart the game? y/n:");
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "y" || input == "Y")
            {
                StartGame();
                break;
            }
            else if (input == "n" || input == "N")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid response..Try again!");
            }
        }
        RestartGame();
    }


    
    
}