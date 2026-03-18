public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        List<char> ch = new List<char>(s);
        List<char> ch2 = new List<char>(t);
        int chlen = ch.Count();
        int chlen2 = ch2.Count();
        ch.Sort();
        ch2.Sort();
        for (int i = 0; i < chlen; i++)
        {
            if (ch[i] != ch2[i] || chlen != chlen2)
            {
                return false;

            }
        }
        return true;
    }
}