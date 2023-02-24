namespace SmartFridgeKata;

public class SmartFridge
{
    private readonly IPrinter _printer;
    private readonly IRepository _repositoryObject;
    private DateTime _currentDate;
    private bool _doorIsOpened;

    public SmartFridge(IPrinter printer, IRepository repositoryObject)
    {
        _printer = printer;
        _repositoryObject = repositoryObject;
        _doorIsOpened = false;
    }

    public void SetCurrentDate(string date)
    {
        _currentDate = DateTime.Parse(date);
    }

    public void OpenDoor()
    {
        _doorIsOpened = true;
    }

    public void AddItem(Item item)
    {
        if (_doorIsOpened)
        {
            _repositoryObject.add(item);
        }
    }

    public void CloseDoor()
    {
        _doorIsOpened = false;
    }

    public void Summary()
    {
    }
}