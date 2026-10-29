
Console.WriteLine("1 - New Player ");
Console.WriteLine("2 - Load Player \n");
string choice = Console.ReadLine();
Console.WriteLine();

if (choice == "1")
{
    Console.WriteLine("Enter player name: ");
    string playerName = Console.ReadLine();
    Player player = new Player(playerName);
    // Example of adding items to the player's inventory
    player.AddItem(new Item("Sword", 1));
    player.AddItem(new Item("Potion", 3));
    // Save the player data
    SaveManager.Save(player);
    Console.WriteLine($"Player {player.Name} created and saved.");
}

else if (choice == "2")
{
    string path = Path.Combine("Saves", "player.json");
    Player loadedPlayer = SaveManager.Load<Player>(path);
    if (loadedPlayer != null)
    {
        Console.WriteLine($"Loaded Player: {loadedPlayer.Name}, Level: {loadedPlayer.Level}, Health: {loadedPlayer.Health}\n");

        foreach (Item item in loadedPlayer.Inventory)
        {
            Console.WriteLine($"Item: {item.Name}, Quantity: {item.Quantity}\n");
        }

        loadedPlayer.TakeDamage(20); 

        Console.WriteLine($"Health after taking 20 damage: {loadedPlayer.Health}\n");

        loadedPlayer.LevelUp();

        Console.WriteLine($"Level after leveling up: {loadedPlayer.Level}\n");
        SaveManager.Save(loadedPlayer);
        Console.WriteLine("Updated player saved.");
    }
    else
    {
        Console.WriteLine("No saved player found.");
    }

}
else
{
    Console.WriteLine("Invalid choice.");
}

