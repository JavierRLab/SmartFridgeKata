namespace SmartFridgeKata;

public interface IRepository
{
    void add(Item item);
    IEnumerable<Item> getItems();
}