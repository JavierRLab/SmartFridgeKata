using System.ComponentModel;
using Moq;

namespace SmartFridgeKata.Tests;

public class AcceptanceTests
{
    [Fact(DisplayName = "Should open fridge, add items and close door and print report")]
    public void Test1()
    {
        var printer = new Mock<IPrinter>();
        var repository = new Mock<IRepository>();

        var smartFridgeKata = new SmartFridge(printer.Object, repository.Object);

        smartFridgeKata.SetCurrentDate("23/02/2023");
        smartFridgeKata.OpenDoor();
        smartFridgeKata.AddItem(new Item("Milk", "21/10/21", "sealed"));
        smartFridgeKata.AddItem(new Item("Lettuce", "23/02/2023", "sealed"));
        smartFridgeKata.AddItem(new Item("Milk", "24/02/2023", "sealed"));
        smartFridgeKata.AddItem(new Item("Milk", "26/02/2023", "sealed"));
        smartFridgeKata.CloseDoor();
        smartFridgeKata.Summary();
        

        printer.Verify(m => m.print("EXPIRED: Milk"));
        printer.Verify(m => m.print("Lettuce: 0 days remaining"));
        printer.Verify(m => m.print("Peppers: 1 day remaining"));
        printer.Verify(m => m.print("Cheese: 3 days remaining"));
    }
}