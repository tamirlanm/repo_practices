// !!! Predefined class name 'Solution' and method names !!!
//                  !!! DO NOT CHANGE !!!

public static class Solution
{
    
    /// <summary>
    /// Generates a sequence of characters using the specified count, previous character, and current character.
    /// This method will call the `CharSequenceGenerator` to generate the sequence.
    /// </summary>
    /// <param name="count">The number of characters to generate in the sequence.</param>
    /// <param name="previous">The previous character in the sequence.</param>
    /// <param name="current">The current character in the sequence.</param>
    /// <returns>A list of characters representing the generated sequence.</returns>
    public static IList<char> HowToUseCharSequenceGenerator(int count, char previous, char current)
    {
        var generator = new CharSequenceGenerator(previous, current);
        var sequence = new List<char> { generator.Previous, generator.Current };

        for (int i = 0; i < count; i++)
        {
            generator.GetNext();
            sequence.Add(generator.Next);
        }
        return sequence;
    }

    /// <summary>
    /// Generates a sequence of integers using the specified count, previous integer, and current integer.
    /// This method will call the `IntegerSequenceGenerator` to generate the sequence.
    /// </summary>
    /// <param name="count">The number of integers to generate in the sequence.</param>
    /// <param name="previous">The previous integer in the sequence.</param>
    /// <param name="current">The current integer in the sequence.</param>
    /// <returns>A list of integers representing the generated sequence.</returns>
    public static IList<int> HowToUseIntegerSequenceGenerator(int count, int previous, int current)
    {
        // Add your code here similar to the `HowToUseCharSequenceGenerator` method.
        var generator = new IntegerSequenceGenerator(previous, current);
        var sequence = new List<int> {generator.Previous, generator.Current};
        for(int i = 0; i < count; i++){
          generator.GetNext();
          sequence.Add(generator.Next);
        }
        return sequence;
        //throw new NotImplementedException("HowToUseIntegerSequenceGenerator method is not implemented.");
    }

    /// <summary>
    /// Generates a sequence of integers using the specified count, previous integer, and current integer.
    /// This method will call the `FibonacciSequenceGenerator` to generate the sequence.
    /// </summary>
    /// <param name="count">The number of integers to generate in the sequence.</param>
    /// <param name="previous">The previous integer in the sequence.</param>
    /// <param name="current">The current integer in the sequence.</param>
    /// <returns>A list of integers representing the generated sequence.</returns>
    public static IList<int> HowToUseFibonacciSequenceGenerator(int count, int previous, int current)
    {
        // Add your code here similar to the `HowToUseCharSequenceGenerator` method.
        var generator = new FibonacciSequenceGenerator(previous, current);
        var sequence = new List<int> {generator.Previous, generator.Current};
        for(int i = 0;i < count; i++){
          generator.GetNext();
          sequence.Add(generator.Next);
        }
        return sequence;
        //throw new NotImplementedException("HowToUseFibonacciSequenceGenerator method is not implemented.");
    }

    /// <summary>
    /// Generates a sequence of doubles using the specified count, previous double, and current double.
    /// This method will call the `DoubleSequenceGenerator` to generate the sequence.
    /// </summary>
    /// <param name="count">The number of doubles to generate in the sequence.</param>
    /// <param name="previous">The previous double in the sequence.</param>
    /// <param name="current">The current double in the sequence.</param>
    /// <returns>A list of doubles representing the generated sequence.</returns>
    public static IList<double> HowToUseDoubleSequenceGenerator(int count, double previous, double current)
    {
        // Add your code here similar to the `HowToUseCharSequenceGenerator` method.
        var generator = new DoubleSequenceGenerator(previous, current);
        var sequence = new List<double> {generator.Previous, generator.Current};
        for(int i = 0; i < count; i++){
          generator.GetNext();
          sequence.Add(generator.Next);
        }
        return sequence;
        //throw new NotImplementedException("HowToUseDoubleSequenceGenerator method is not implemented.");
    }


    /// <summary>
    /// Generates a sequence of elements using the specified count, previous element, current element, and a delegate function.
    /// This method will call the `DelegateSequenceGenerator` to generate the sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sequence.</typeparam>
    /// <param name="count">The number of elements to generate in the sequence.</param>
    /// <param name="previous">The previous element in the sequence.</param>
    /// <param name="current">The current element in the sequence.</param>
    /// <param name="nextFunc">The delegate function to calculate the next element in the sequence.</param>
    /// <returns>A list of elements representing the generated sequence.</returns>
    public static IList<T> HowToUseDelegateSequenceGenerator<T>(int count, T previous, T current,
        Func<T, T, T> nextFunc)
    {
        // Add your code here similar to the `HowToUseCharSequenceGenerator` method.
        var generator = new DelegateSequenceGenerator<T>(previous, current, nextFunc);
        var sequence = new List<T> {generator.Previous, generator.Current};
        for(int i = 0; i < count; i++){
          generator.GetNext();
          sequence.Add(generator.Next);
        }
        return sequence;
        //throw new NotImplementedException("HowToUseDelegateSequenceGenerator method is not implemented.");
    }
}

// TODO: Implement the ISequenceGenerator interface.
public interface ISequenceGenerator<T>
{
    public T Previous {get;}
    public T Current{get;}
    public T Next {get;}
}
// TODO: Implement the SequenceGenerator class.
public abstract class SequenceGenerator<T> : ISequenceGenerator<T>
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
    protected void IncrementCount() => Count++;

    public abstract void GetNext();
}
// TODO: Implement the CharSequenceGenerator class.
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
// TODO: Implement the IntegerSequenceGenerator class.
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
// TODO: Implement the DelegateSequenceGenerator class.

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
// TODO: Implement the DoubleSequenceGeneratorD class.
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
// TODO: Implement the FibonacciSequenceGenerator class.
public class FibonacciSequenceGenerator : SequenceGenerator<int>
{
    public FibonacciSequenceGenerator(int previous, int current) : base(previous, current){}
    public override void GetNext()
    {
        Next = Previous + Current;
        Previous = Current;
        Current = Next;
        IncrementCount();
    }
}