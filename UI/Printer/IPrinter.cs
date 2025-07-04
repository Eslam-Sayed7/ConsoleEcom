using Domain.CartService;
using Domain.Order;
using Domain.Product;
using Domain.ShippingService;

namespace ConsoleEcomm.Printer;


public interface IPrinter
{
    void PrintMessages( PrintMessage printMessage );
}