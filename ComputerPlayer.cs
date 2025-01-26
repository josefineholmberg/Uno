public class ComputerPlayer : Player
{
    public ComputerPlayer(Deck deck, ICardChooser cardChooser) : base(GenerateName(), deck, cardChooser)
    {
    }

    public override void ShowHand()
    {
        foreach (IUnoCard card in hand)
        {
            Console.Write("[] ");
        }
        Console.WriteLine();
    }

    public static string GenerateName()
    {
        var textHandler = new TextFileHandler("computer_names.txt");
        var readTextNames = textHandler.Read();
        var random = new Random();
        return readTextNames[random.Next(readTextNames.Count)];
    }
}
