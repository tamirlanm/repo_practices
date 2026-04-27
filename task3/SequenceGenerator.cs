namespace task3;

abstract class SequenceGenerator<T> : ISequenceGenerator<T>
{
    public T Previous {get; protected set;}
    public T Current {get; protected set;}
    public T Next {get; protected set;}
    public int Count {get; private set;}
    public SequenceGenerator(T previous, T current)
    {
        Previous = previous;
        Current = current;
        Count = 2;
    }
    protected void IncrementCount()
    {
        Count++;
    }

    public abstract void GetNext();
}