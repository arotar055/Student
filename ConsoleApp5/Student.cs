using Person;

namespace Student
{
    public class Student : Person.Person
    {
        public string Faculty { get; set; }
        public int Course { get; set; }

        public Student(string firstName, string lastName, string faculty, int course)
            : base(firstName, lastName)
        {
            Faculty = faculty;
            Course = course;
        }

        public void DisplayStudentInfo()
        {
            DisplayInfo();
            Console.WriteLine($"Faculty: {Faculty}, Course: {Course}");
        }
    }
}
