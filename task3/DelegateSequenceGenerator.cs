
public class DelegateSequenceGenerator<T> : SequenceGenerator<T>
{
    private Func<T, T, T> Del{get;set;}
    public DelegateSequenceGenerator(T previous, T current, Func<T, T, T> func) : base(previous, current)
    {
        this.Del = func;
    }

    public override void GetNext()
    {
        Next = Del(Previous, Current);
        Previous = Current;
        Current = Next;
        IncrementCount();
    }
}