class Program
{
    public static void Main(string[] args)
    {
        Person pr = new Person("Chokan", 27);
        Student student = new Student("Magzhan", 19, "KBTU", 3);
        Book book = new Book("clockwork orange", 1963, "Someone Anyone");
        pr.PrintInfo();
        student.PrintInfo();
        student.PrintStudentInfo();
        book.PrintInfo();

    }
}