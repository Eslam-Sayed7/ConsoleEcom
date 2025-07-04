namespace ConsoleEcomm.Printer;

public class PrintMessage
{
    public IList<string> messageLines;

    public PrintMessage(IList<string> messageLines)
    {
        this.messageLines = messageLines;
    }
    public PrintMessage()
    {
        messageLines = new List<string>();
    }
    public void AddMessage(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentException("Message cannot be null or empty.", nameof(message));
        }
        messageLines.Add(message);
    }
    public void Print()
    {
        if (messageLines.Count == 0)
        {
            Console.WriteLine("No messages to print.");
            return;
        }
        foreach (var line in messageLines)
        {
            Console.WriteLine(line);
        }
    }
}