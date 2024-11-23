using Student;
using System.Collections.Generic;
using System.IO;
using StudentLibrary;

namespace AcademyGroup
{
    public class AcademyGroup
    {
        public string GroupName { get; set; }
        public List<Student> Students { get; set; }

        public AcademyGroup(string groupName)
        {
            GroupName = groupName;
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void DisplayGroupInfo()
        {
            Console.WriteLine($"Group: {GroupName}");
            foreach (var student in Students)
            {
                student.DisplayStudentInfo();
            }
        }
    }
}
