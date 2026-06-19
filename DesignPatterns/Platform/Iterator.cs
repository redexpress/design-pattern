namespace Redexpress.DesignPatterns.Platform;

public class MenuItem
{
    public string Name { get; }
    public string Description { get; }
    public bool Vegetarian { get; }
    public double Price { get; }

    public MenuItem(string name, string description, bool vegetarian, double price)
    {
        Name = name;
        Description = description;
        Vegetarian = vegetarian;
        Price = price;
    }
}

public class PancakeHouseMenu
{
    private readonly List<MenuItem> menuItems;

    public PancakeHouseMenu()
    {
        menuItems = new List<MenuItem>();

        AddItem("K&B's Pancake Breakfast", "Pancakes with scrambled eggs, and toast", true, 2.99);
        AddItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, 2.99);
        AddItem("Blueberry Pancakes", "Pancakes made with fresh blueberries", true, 3.49);
        AddItem("Waffles", "Waffles, with your choice of blueberries or strawberries", true, 3.59);
    }

    public void AddItem(string name, string description, bool vegetarian, double price)
    {
        menuItems.Add(new MenuItem(name, description, vegetarian, price));
    }

    public List<MenuItem> MenuItems => menuItems;

    public IEnumerator<MenuItem> CreateIterator()
    {
        return menuItems.GetEnumerator();
    }
}

public class DinerMenu
{
    private const int MaxItems = 6;

    private int numberOfItems;
    private readonly MenuItem[] menuItems;

    public DinerMenu()
    {
        menuItems = new MenuItem[MaxItems];

        AddItem("Vegetarian BLT", "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 2.99);
        AddItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99);
        AddItem("Soup of the day", "Soup of the day, with a side of potato salad", false, 3.29);
        AddItem("Hotdog", "A hot dog, with sauerkraut, relish, onions, topped with cheese", false, 3.05);
    }

    public void AddItem(string name, string description, bool vegetarian, double price)
    {
        if (numberOfItems >= MaxItems)
        {
            Console.WriteLine("Sorry, menu is full! Can't add item to menu");
            return;
        }

        menuItems[numberOfItems++] = new MenuItem(name, description, vegetarian, price);
    }

    public MenuItem[] MenuItems => menuItems;

    public IEnumerator<MenuItem> CreateIterator()
    {
        return GetItems().GetEnumerator();
    }

    private IEnumerable<MenuItem> GetItems()
    {
        for (int i = 0; i < numberOfItems; i++)
            yield return menuItems[i];
    }
}

public class Waitress
{
    private readonly PancakeHouseMenu pancakeHouseMenu;
    private readonly DinerMenu dinerMenu;

    public Waitress(PancakeHouseMenu pancakeHouseMenu, DinerMenu dinerMenu)
    {
        this.pancakeHouseMenu = pancakeHouseMenu;
        this.dinerMenu = dinerMenu;
    }

    public void PrintMenuWithoutIterator()
    {
        List<MenuItem> breakfastItems = pancakeHouseMenu.MenuItems;
        MenuItem[] lunchItems = dinerMenu.MenuItems;

        for (int i = 0; i < breakfastItems.Count; i++)
        {
            MenuItem menuItem = breakfastItems[i];
            Console.Write($"{menuItem.Name}, ");
            Console.Write($"{menuItem.Price} -- ");
            Console.WriteLine(menuItem.Description);
        }

        for (int i = 0; i < lunchItems.Length; i++)
        {
            MenuItem menuItem = lunchItems[i];
            if (menuItem == null)
                break;

            Console.Write($"{menuItem.Name}, ");
            Console.Write($"{menuItem.Price} -- ");
            Console.WriteLine(menuItem.Description);
        }
    }

    public void PrintMenu()
    {
        Console.WriteLine("MENU\n----\nBREAKFAST");
        PrintMenu(pancakeHouseMenu.CreateIterator());

        Console.WriteLine("\nLUNCH");
        PrintMenu(dinerMenu.CreateIterator());
    }

    private void PrintMenu(IEnumerator<MenuItem> iterator)
    {
        while (iterator.MoveNext())
        {
            MenuItem menuItem = iterator.Current;

            Console.Write($"{menuItem.Name}, ");
            Console.Write($"{menuItem.Price} -- ");
            Console.WriteLine(menuItem.Description);
        }
    }
}


