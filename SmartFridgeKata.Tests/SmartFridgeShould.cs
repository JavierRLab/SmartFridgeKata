using Moq;

namespace SmartFridgeKata.Tests;

public class SmartFridgeShould
{
    [Fact]
    public void cannot_include_add_when_door_is_closed()
    {
        var printer = new Mock<IPrinter>();
        var repository = new Mock<IRepository>();
        var smartFridgeKata = new SmartFridge(printer.Object, repository.Object);
        var item = new Item("Milk", "21/10/21", "sealed");
        
        smartFridgeKata.AddItem(item);
        
        repository.Verify(m => m.add(item), Times.Never());
    }
    
    [Fact]
    public void can_include_add_when_door_is_opened()
    {
        var printer = new Mock<IPrinter>();
        var repository = new Mock<IRepository>();
        var smartFridgeKata = new SmartFridge(printer.Object, repository.Object);
        
        smartFridgeKata.OpenDoor();
        
        var item = new Item("Milk", "21/10/21", "sealed");
        smartFridgeKata.AddItem(item);
        
        repository.Verify(m => m.add(item), Times.Once());
    }
    
    [Fact]
    public void can_include_add_after_door_is_reopened()
    {
        var printer = new Mock<IPrinter>();
        var repository = new Mock<IRepository>();
        var smartFridgeKata = new SmartFridge(printer.Object, repository.Object);
        
        smartFridgeKata.OpenDoor();
        
        var item = new Item("Milk", "21/10/21", "sealed");
        smartFridgeKata.AddItem(item);
        
        smartFridgeKata.CloseDoor();
        smartFridgeKata.OpenDoor();
        
        smartFridgeKata.AddItem(item);
        
        repository.Verify(m => m.add(item), Times.Exactly(2));
    }

    [Fact]
    public void it_prints_expired_item_when_it_have_expired_item()
    {
        
        var printer = new Mock<IPrinter>();
        var repository = new Mock<IRepository>();
        var item = new Item("Milk", "21/10/21", "sealed");

        repository.Setup(x => x.getItems()).Returns(new List<Item>() { item });

        var smartFridgeKata = new SmartFridge(printer.Object, repository.Object);

        smartFridgeKata.Summary();
        

        printer.Verify(m => m.print("EXPIRED: Milk"));
        
    }
}