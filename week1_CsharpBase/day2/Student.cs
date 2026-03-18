class Student : Person
{
    public string University { get; set; }
    public int Year { get; set; }
    public Student(string name, int age, string university, int year) : base(name, age)
    {
        University = university;
        Year = year;
    }

    public void PrintStudentInfo() => Console.WriteLine($"Student University: {University}\nCourse year: {Year}");
}