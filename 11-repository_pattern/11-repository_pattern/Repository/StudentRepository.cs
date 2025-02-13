using _11_repository_pattern.Models;

namespace _11_repository_pattern.Repository
{
    public class StudentRepository : IStudent
    {
        public List<Student> getAllStudents()
        {
            return DataSource();
        }

        public Student getStudentById(int id)
        {
            return DataSource().Where(data => data.RollNo == id).FirstOrDefault();
        }

        private List<Student> DataSource()
        {
            return new List<Student> 
            { 
                new Student{RollNo=1,Name="Agastya",Gender="Female",Standard=10},
                new Student{RollNo=2,Name="Arpita",Gender="Female",Standard=11},
                new Student{RollNo=3,Name="Akash",Gender="Male",Standard=12},
                new Student{RollNo=4,Name="Anuja",Gender="Female",Standard=11},
                new Student{RollNo=5,Name="Harshal",Gender="Male",Standard=10},
            };
        }
    }
}
