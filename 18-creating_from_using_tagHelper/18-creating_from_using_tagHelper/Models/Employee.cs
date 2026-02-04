namespace _18_creating_from_using_tagHelper.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Married { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
        public string Description { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }

}
