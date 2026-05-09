
public interface ISequenceGenerator<T>
{
    public T Previous {get;}
    public T Current{get;}
    public T Next {get;}
}