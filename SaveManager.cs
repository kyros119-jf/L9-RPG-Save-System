using System.IO;
using System.Text.Json;
public class SaveManager
{
    public static void Save(ISaveable entity)
    {

        Directory.CreateDirectory("Saves");

        string path = Path.Combine("Saves", "player.json");
        File.WriteAllText(path, entity.ToJson());
    }


    public static T Load<T>(string path)
    {
        if (!File.Exists(path))
        {
            return default(T);
        }

        string json = File.ReadAllText(path);
        T loadedObject = JsonSerializer.Deserialize<T>(json);
        return loadedObject;


    }
}