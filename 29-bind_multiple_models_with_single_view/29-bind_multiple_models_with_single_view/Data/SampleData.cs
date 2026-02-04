using _29_bind_multiple_models_with_single_view.Models;

namespace _29_bind_multiple_models_with_single_view.Data
{
    public class SampleData
    {
        public static List<Student> StudentData()
        {
            return new List<Student> 
            {
                new Student { Id=1, Name="Aniket", Standard="11",Address="Karjat" },
                new Student { Id=2, Name="Arpita", Standard="12",Address="Chakan" },
                new Student { Id=3, Name="Anuja", Standard="10",Address="Baramati" },
                new Student { Id=4, Name="Akash", Standard="9",Address="Nashik" },
            };
        }

        public static List<Teacher> TeachersData()
        {
            return new List<Teacher>
            {
                new Teacher { Id=1, Name="Harshal Sir", Department="Math", Salary=30000 },
                new Teacher { Id=2, Name="Sane Sir", Department="Computer", Salary=24000 },
                new Teacher { Id=3, Name="Rutuja Madam", Department="Statistics", Salary=50000 },
            };
        }

        public static List<Employee> EmployeeData()
        {
            return new List<Employee>
            {
                //new Employee { Id = 1, Name = "Akash", Role = "Clerk", Salary = 30000 },
                //new Employee { Id = 2, Name = "Tejas", Role = "Librarian", Salary = 35000 },
                //new Employee { Id = 3, Name = "Chota Don", Role = "Janitor", Salary = 25000 }
            };
        }
    }
}
