using Domain;

namespace FileData;

public class DataContainer
{
    public ICollection<User> users { get; set; }
    public ICollection<Post> posts { get; set; }

}