using System.Security.Cryptography.X509Certificates;

class Program
{

    public static void Main(string[] args){
        string s = Console.ReadLine();
        LastWord ls = new LastWord();
        int t = ls.LengthOfLastWord(s);
        Console.WriteLine(t); 
    }
}