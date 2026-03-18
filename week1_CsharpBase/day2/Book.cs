class Book
{
    public string Title { get; set; }
    public int DateYear { get; set; }
    public string Author { get; set; }
    public Book(string title, int dateYear, string author)
    {
        Title = title;
        DateYear = dateYear;
        Author = author;
    }
    public void PrintInfo() => Console.WriteLine($"Book Title: {Title}\nYear: {DateYear}\nAuthor: {Author}");
}