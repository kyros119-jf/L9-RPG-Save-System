public class Item
{
    private string name;
    private int quantity;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
        }
    }

    public int Quantity
    {
        get
        {
            return quantity;
        }
        set
        {
            if (value >= 0)
            {
                quantity = value;
            }
        }
    }

    public Item(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}
