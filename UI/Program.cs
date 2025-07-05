namespace ConsoleEcomm;
public class Program
{
    public static void Main(string[] args)
    {
        bool RUNNING = true;
        
        // Initialize services 
        var diContainer = new DIContainer();
        var home = new HomePage(diContainer);
        
        Console.WriteLine("Welcome to the E-commerce Console Application!");
        while (RUNNING)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Make Order");
            Console.WriteLine("10. Exit");
            
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    home.ListProducts();
                    break;
                case "2":
                    home.MakeCustomerCartContext();
                    break;
                case "10":
                    RUNNING = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}