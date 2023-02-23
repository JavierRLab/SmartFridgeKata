namespace SmartFridgeKata;

public class Item
{
    private readonly string _milk;
    private readonly string _expiry;
    private readonly string _condition;

    public Item(string milk, string expiry, string condition)
    {
        _milk = milk;
        _expiry = expiry;
        _condition = condition;
    }
}