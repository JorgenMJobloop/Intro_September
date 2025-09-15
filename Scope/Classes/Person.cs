/// <summary>
/// A basic Person class, holds information that is commonly associated with a person.
/// </summary>
public class Person
{
    public string? Name;
    public int Age;
    public List<string>? Hobbies;

    /// <summary>
    /// Primary constructor for our Person class
    /// </summary>
    /// <param name="name">The name of the person</param>
    /// <param name="age">The age of the person</param>
    /// <param name="hobbies">The hobbies the person has</param>
    public Person(string name, int age, List<string> hobbies)
    {
        Name = name;
        Age = age;
        Hobbies = hobbies;
    }

    /// <summary>
    /// Gets the name of the person, that is assigned when the class is instanciated.
    /// </summary>
    /// <returns>string</returns>
    public string GetPersonName()
    {
        return $"The name of the {this} is: {Name}";
    }
    /// <summary>
    /// Gets the age of the person, that is assigned when the class is instanciated.
    /// </summary>
    /// <returns>int</returns>
    public int GetAge()
    {
        return Age;
    }
    /// <summary>
    /// Prints out the hobbies of the person to the console, by utilizing the Console.WriteLine() method.
    /// </summary>
    public void GetHobbies()
    {
        if (Hobbies == null || Hobbies.Count == 0)
        {
            Console.WriteLine($"{Name} currently has {Hobbies!.Count} listed.");
            return;
        }
        // We want to assume that the if-statement above is never true, so below this line , we can implement a way to easily iterate over our Hobbies list.
        // The "content" variable stores the values inside the List<string> Hobbies field.
        string content;

        if (Hobbies.Count == 1)
        {
            content = Hobbies[0];
        }
        else
        {
            content = string.Join(", ", Hobbies.Take(Hobbies.Count - 1)) + " & " + Hobbies.Last();
        }
        Console.WriteLine($"{Name} is {Age} years old! And enjoys {content}.");
    }
}