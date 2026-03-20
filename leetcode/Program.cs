using System.Security.Cryptography.X509Certificates;

class Program
{

    public static void Main(string[] args){
        int x = int.Parse(Console.ReadLine());
        palindromeNumber pn = new palindromeNumber();
        bool s = pn.IsPalindrome(x);
        Console.WriteLine(s);    
    }
}