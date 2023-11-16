using System;
using System.Collections.Generic;
public interface IGame
{
    void Play();
}
public class BeachGame : IGame
{
    public void Play()
    {
        Console.WriteLine("Игра на пляже");
    }
}
public class MouseTrapGame : IGame
{
    public void Play()
    {
        Console.WriteLine("Игра в мышеловке");
    }
}
public class SeaGame : IGame
{
    public void Play()
    {
        Console.WriteLine("Игра в море");
    }
}
public class FishingGame : IGame
{
    public void Play()
    {
        Console.WriteLine("Рыбалка");
    }
}
public class PostmenGame : IGame
{
    public void Play()
    {
        Console.WriteLine("Игра с почтальонами");
    }
}
public class SlideGame : IGame
{
    public void Play()
    {
        Console.WriteLine("Игра на горке");
    }
}
public class GameDecorator : IGame
{
    private IGame _game;
    public GameDecorator(IGame game)
    {
        _game = game;
    }
    public void Play()
    {
        _game.Play();
    }
}
public class NewGame : GameDecorator
{
    public NewGame(IGame game) : base(game)
    {
    }
    public void PlayNewGame()
    {
        Console.WriteLine("Новая игра!");
    }
    public new void Play()
    {
        base.Play();
        PlayNewGame();
    }
}
public class Team
{
    private List<IGame> _games = new List<IGame>();
    public void AddGame(IGame game)
    {
        _games.Add(game);
    }
    public void PlayGames()
    {
        foreach (var game in _games)
        {
            game.Play();
        }
    }
}
class Program
{
    static void Main()
    {
        Team russiaTeam = new Team();
        Team franceTeam = new Team();
        Team chinaTeam = new Team();
        Team kazakhstanTeam = new Team();
        russiaTeam.AddGame(new BeachGame());
        russiaTeam.AddGame(new MouseTrapGame());
        russiaTeam.AddGame(new SeaGame());
        russiaTeam.AddGame(new FishingGame());
        russiaTeam.AddGame(new PostmenGame());
        russiaTeam.AddGame(new SlideGame());
        franceTeam.AddGame(new BeachGame());
        franceTeam.AddGame(new MouseTrapGame());
        franceTeam.AddGame(new SeaGame());
        franceTeam.AddGame(new FishingGame());
        franceTeam.AddGame(new PostmenGame());
        franceTeam.AddGame(new SlideGame());
        chinaTeam.AddGame(new BeachGame());
        chinaTeam.AddGame(new MouseTrapGame());
        chinaTeam.AddGame(new SeaGame());
        chinaTeam.AddGame(new FishingGame());
        chinaTeam.AddGame(new PostmenGame());
        chinaTeam.AddGame(new SlideGame());
        kazakhstanTeam.AddGame(new BeachGame());
        kazakhstanTeam.AddGame(new MouseTrapGame());
        kazakhstanTeam.AddGame(new SeaGame());
        kazakhstanTeam.AddGame(new FishingGame());
        kazakhstanTeam.AddGame(new PostmenGame());
        kazakhstanTeam.AddGame(new SlideGame());
        russiaTeam.AddGame(new NewGame(new BeachGame()));
        franceTeam.AddGame(new NewGame(new MouseTrapGame()));
        chinaTeam.AddGame(new NewGame(new SeaGame()));
        kazakhstanTeam.AddGame(new NewGame(new FishingGame()));
        Console.WriteLine("Игры команды России:");
        russiaTeam.PlayGames();
        Console.WriteLine("\nИгры команды Франции:");
        franceTeam.PlayGames();
        Console.WriteLine("\nИгры команды Китая:");
        chinaTeam.PlayGames();
        Console.WriteLine("\nИгры команды Казахстана:");
        kazakhstanTeam.PlayGames();
    }
}
