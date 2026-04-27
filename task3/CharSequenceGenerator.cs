
public class CharSequenceGenerator : SequenceGenerator<char>
{
    public CharSequenceGenerator(char previous, char current) : base(previous, current){}

    public override void GetNext()
    {
        Next = (char)('A' + (Current - 'A' + Previous - 'A') % 26);
        Previous = Current;
        Current = Next;
        IncrementCount();

    }
}