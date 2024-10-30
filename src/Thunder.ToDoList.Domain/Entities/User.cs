namespace Thunder.ToDoList.Domain.Entities;
public class User : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    public User(string name, string email)
    {
        SetName(name);
        Email = email;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}
