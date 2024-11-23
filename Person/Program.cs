namespace Person
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {FirstName} {LastName}");
        }
    }
}
