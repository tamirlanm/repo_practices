
class Box<T>
{
    public T SomeObj {get;}

    public Box(T someobj)
    {
        SomeObj = someobj;
    }
    public void Show()
    {
        Console.WriteLine(SomeObj);
    }
}