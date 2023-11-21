using System.Text.Json;
using Domain;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";
    private DataContainer? dataContainer;
    
    public ICollection<User> Users
    {
        get
        {
            LoadData();
            return dataContainer!.users;
        }
    }

    public ICollection<Post> Posts
    {
        get
        {
            LoadData();
            return dataContainer!.posts;
        }
    }

    private void LoadData()
    {
        if (dataContainer != null) return;

        if (!File.Exists(filePath))
        {
            dataContainer = new()
            {
                users = new List<User>(),
                posts = new List<Post>()
            };
            return;
        }

        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }
    
    public void SaveChanges()
    {
        string content = JsonSerializer.Serialize(dataContainer);
        File.WriteAllText(filePath, content);
        dataContainer = null;
    }
}