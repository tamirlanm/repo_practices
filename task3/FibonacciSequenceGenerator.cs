public class FibonacciSequenceGenerator : SequenceGenerator<int>
{
    public FibonacciSequenceGenerator(int previous, int current) : base(previous, current)
    {
    }
    public override void GetNext()
    {
        Next = Previous + Current;
        Previous = Current;
        Current = Next;
        Count++;
    }
}