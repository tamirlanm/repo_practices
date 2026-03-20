
public class palindromeNumber
{
    public bool IsPalindrome(int x)
    {
        string str = x.ToString();
        string trs = "";
        for(int i = str.Length - 1; i >= 0; i--)
        {
            trs += str[i];
        }
        if(str == trs)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}