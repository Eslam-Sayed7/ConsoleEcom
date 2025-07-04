namespace ConsoleEcomm.Printer;
public class ConsolePrinter : IPrinter
{
    public void PrintMessages(PrintMessage printMessage)
    {
        foreach (var message in printMessage.messageLines)
        {
            Console.WriteLine(message);
        }
    }
}