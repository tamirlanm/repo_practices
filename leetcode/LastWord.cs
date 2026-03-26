
class LastWord
{
    public int LengthOfLastWord(string s)
    {
        s = s.Trim();
        string[] words = s.Split(new char[] {' '});
        
        return words[^1].Length;
    }
}