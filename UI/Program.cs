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
            Console.WriteLine("3. View Carts");
            Console.WriteLine("4. View Customers");
            Console.WriteLine("5. View Shipping");
            Console.WriteLine("6. View cart summary");
            Console.WriteLine("0. Exit");
            
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    home.ListProducts();
                    break;
                case "2":
                    home.MakeCustomerCartContext();
                    break;
                case "3":
                    home.ViewCarts();
                    break;
                case "4":
                    home.ViewCustomers();
                    break;
                case "5":
                    break;
                case "6":
                    home.PrintCartSummary();
                    break;
                case "0":
                    RUNNING = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}