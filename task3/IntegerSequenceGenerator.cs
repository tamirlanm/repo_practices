public class IntegerSequenceGenerator : SequenceGenerator<int>
{
    public IntegerSequenceGenerator(int previous, int current) : base(previous, current){}

    public override void GetNext()
    {
        Next = (6 * Current) - (8 * Previous);
        Previous = Current;
        Current = Next;
        IncrementCount();
    }

}