
public class DoubleSequenceGenerator : SequenceGenerator<double>
{
    public DoubleSequenceGenerator(double previous, double current) : base(previous, current){}

    public override void GetNext()
    {
        Next = Current + (Previous/Current);
        Previous = Current;
        Current = Next;
        IncrementCount();
    }
}