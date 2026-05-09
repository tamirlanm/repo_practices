public class Vanagram
{
    public bool IsAnagram(string s, string t)
    {
        if(s.Length != t.Length)
        {
            return false;
        }
        Dictionary <char, int> map = new Dictionary<char, int>();
        for(int i = 0; i < s.Length; i++)
        {
            if (map.ContainsKey(s[i]))
            {
                map[s[i]]++;
            }
            else
            {
                map[s[i]] = 1;
            }
        }
        for(int i = 0; i < t.Length; i++)
        {
            if (!map.ContainsKey(t[i]))
            {
                return false;
            }
            map[t[i]]--;
            if(map[t[i]] == 0)
            {
                map.Remove(t[i]);
            }
        }
        return map.Count == 0;
        
        // a = 0, n = 1, a = 2, g = 3, r = 4, a = 5, m = 6
        // n = 0, a = 1, g = 2, a = 3, r = 4, a = 5, m = 6


        /*
        List<char> ch = new List<char>(s);
        List<char> ch2 = new List<char>(t);
        int chs = ch.Count();
        int cht = ch2.Count();
        ch.Sort();
        ch2.Sort();
        for (int i = 0; i < chs; i++)
        {
            if (ch[i] != ch2[i] || chs != cht)
            {
                return false;

            }
        }
        return true;
        */
    }
}