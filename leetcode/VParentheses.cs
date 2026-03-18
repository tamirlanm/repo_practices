public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> st = new Stack<char>();
        bool th = false;
        if (s.Length % 2 != 0)
        {
            return false;
        }
        foreach (char c in s)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                st.Push(c);
            }
            else
            {
                if (st.Count == 0 || (st.Peek() != '(' && c == ')') || (st.Peek() != '{' && c == '}') || (st.Peek() != '[' && c == ']'))
                {
                    return false;
                }
                else if ((st.Peek() == '(' && c == ')') || (st.Peek() == '{' && c == '}') || (st.Peek() == '[' && c == ']'))
                {
                    st.Pop();
                }
            }
        }
        return st.Count == 0;
    }
}
