class BaseAction : IAction
{
    public virtual void Move() => Console.WriteLine("Move in Base Action.");
}