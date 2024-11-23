using System;
using System.IO;
using System.Reflection;

namespace AcademyGroupApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string[] dllFiles = Directory.GetFiles(currentDirectory, "*.dll");

            foreach (var dllFile in dllFiles)
            {
                Console.WriteLine($"Found DLL: {dllFile}");
            }

            // Динамическая загрузка сборок
            foreach (var dllFile in dllFiles)
            {
                Assembly assembly = Assembly.LoadFrom(dllFile);

                // Проверяем наличие класса AcademyGroup
                Type academyGroupType = assembly.GetType("AcademyGroup.AcademyGroup");
                if (academyGroupType != null)
                {
                    Console.WriteLine("Found AcademyGroup class in assembly.");

                    // Создание экземпляра AcademyGroup с помощью рефлексии
                    object academyGroupInstance = Activator.CreateInstance(academyGroupType, "Group A");

                    // Проверяем наличие метода AddStudent
                    MethodInfo addStudentMethod = academyGroupType.GetMethod("AddStudent");
                    if (addStudentMethod != null)
                    {
                        // Динамическое создание экземпляра Student
                        Type studentType = assembly.GetType("Student.Student");
                        if (studentType != null)
                        {
                            object studentInstance = Activator.CreateInstance(studentType, "John", "Doe", "Computer Science", 1);
                            addStudentMethod.Invoke(academyGroupInstance, new object[] { studentInstance });
                        }
                    }

                    // Проверяем наличие метода DisplayGroupInfo
                    MethodInfo displayGroupInfoMethod = academyGroupType.GetMethod("DisplayGroupInfo");
                    if (displayGroupInfoMethod != null)
                    {
                        displayGroupInfoMethod.Invoke(academyGroupInstance, null);
                    }
                }
            }
        }
    }
}
