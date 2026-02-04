using _11_repository_pattern.Models;

namespace _11_repository_pattern.Repository
{
    public interface IStudent
    {
        List<Student> getAllStudents();

        Student getStudentById(int id);
    } 
}
