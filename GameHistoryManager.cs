public class GameHistoryManager
{
public void AddHistory(GameHistoryEntry newHistory)
    {
        var handler = new JsonFileHandler<Dictionary<string, GameHistoryEntry>>("game_history.json");

        // Hämta nuvarande historik, eller skapa en ny dictionary om filen är tom.
        Dictionary<string, GameHistoryEntry> currentHistory = handler.Read() ?? new Dictionary<string, GameHistoryEntry>();

        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");    
        // Lägg till den nya historiken, använd t.ex. "Date" som nyckel.
        currentHistory[date] = newHistory;

        // Skriv tillbaka hela historiken till filen.
        handler.Write(currentHistory);
    }

    // Hämta hela historiken
    public Dictionary<string, GameHistoryEntry> GetHistory()
    {
        var handler = new JsonFileHandler<Dictionary<string, GameHistoryEntry>>("game_history.json");
        return handler.Read() ?? new Dictionary<string, GameHistoryEntry>();
        
    }


    public void WriteHistory()
    {
       var History = GetHistory();
       foreach (var game in History)
       {
        Console.WriteLine($"Date: {game.Key}");
        Console.WriteLine($"Player1: {game.Value.Player1}");
        Console.WriteLine($"Player2: {game.Value.Player2}");
        Console.WriteLine($"Winner: {game.Value.Winner}");
        Console.WriteLine($"Duration: {game.Value.GameDuration}");
        Console.WriteLine();
        Console.WriteLine();


       }
        
    }
}
