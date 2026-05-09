using System;
using System.Collections.Generic;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("=== Testing Sequence Generators ===\n");

        // 1. Тестирование CharSequenceGenerator
        /*Console.WriteLine("1. Char Sequence:");
        // По заданию для n=10, Previous='A', Current='B' ожидается: A, B, B, C, D, F, I, N, V, I
        var charResult = HowToUseCharSequenceGenerator(10, 'A', 'B');
        Console.WriteLine($"Result: {string.Join(", ", charResult)}\n");
        */
        Console.WriteLine("1. Char Sequence:");
        // По заданию для n=10, Previous='Y', Current='Z' ожидается: Y, Z, X, W, T, P, I, X, F, C
        var charResult = HowToUseCharSequenceGenerator(10, 'Y', 'Z');
        Console.WriteLine($"Result: {string.Join(", ", charResult)}\n");
        

        // 2. Тестирование IntegerSequenceGenerator
        Console.WriteLine("2. Integer Sequence:");
        // По заданию для n=10, Previous=1, Current=2 ожидается: 1, 2, 4, 8, 16, 32, 64, 128, 256, 512
        var intResult = HowToUseIntegerSequenceGenerator(10, 1, 2);
        Console.WriteLine($"Result: {string.Join(", ", intResult)}\n");


        // 3. Тестирование FibonacciSequenceGenerator
        Console.WriteLine("3. Fibonacci Sequence:");
        // По заданию для n=10, Previous=0, Current=1 ожидается: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34
        var fibResult = HowToUseFibonacciSequenceGenerator(10, 0, 1);
        Console.WriteLine($"Result: {string.Join(", ", fibResult)}\n");


        // 4. Тестирование DoubleSequenceGenerator
        Console.WriteLine("4. Double Sequence:");
        // По заданию для n=10, Previous=1.0, Current=2.0 
        var doubleResult = HowToUseDoubleSequenceGenerator(10, 1.0, 2.0);
        
        // Для Double выведем с округлением до 5 знаков, чтобы было как в задании
        Console.Write("Result: ");
        foreach (var val in doubleResult)
        {
            Console.Write($"{val:F5}, "); // Форматирование вывода Double
        }
        Console.WriteLine("\n");


        // 5. Тестирование DelegateSequenceGenerator
        Console.WriteLine("5. Delegate Sequence (Custom Rule):");
        // Например, сделаем кастомное правило сложения (как Фибоначчи)
        Func<int, int, int> customRule = (prev, curr) => prev + curr;
        var delegateResult = HowToUseDelegateSequenceGenerator(10, 0, 1, customRule);
        Console.WriteLine($"Result: {string.Join(", ", delegateResult)}\n");
    }

    // --- Ниже идут методы из задания ---

    public static IList<char> HowToUseCharSequenceGenerator(int count, char previous, char current)
    {
        var generator = new CharSequenceGenerator(previous, current);
        var sequence = new List<char> { generator.Previous, generator.Current };

        for (int i = 0; i < count - 2; i++) // Используем count - 2, как было в правильной версии
        {
            generator.GetNext();
            sequence.Add(generator.Next);
        }
        return sequence;
    }

    public static IList<int> HowToUseIntegerSequenceGenerator(int count, int previous, int current)
    {
        var generator = new IntegerSequenceGenerator(previous, current);
        var sequence = new List<int> { generator.Previous, generator.Current };

        for (int i = 0; i < count - 2; i++)
        {
            generator.GetNext();
            sequence.Add(generator.Next);
        }
        return sequence;
    }

    public static IList<int> HowToUseFibonacciSequenceGenerator(int count, int previous, int current)
    {
        var generator = new FibonacciSequenceGenerator(previous, current);
        var sequence = new List<int> { generator.Previous, generator.Current };

        for (int i = 0; i < count - 2; i++)
        {
            generator.GetNext();
            sequence.Add(generator.Next);
        }
        return sequence;
    }

    public static IList<double> HowToUseDoubleSequenceGenerator(int count, double previous, double current)
    {
        var generator = new DoubleSequenceGenerator(previous, current);
        var sequence = new List<double> { generator.Previous, generator.Current };

        for (int i = 0; i < count - 2; i++)
        {
            generator.GetNext();
            sequence.Add(generator.Next);
        }
        return sequence;
    }

    public static IList<T> HowToUseDelegateSequenceGenerator<T>(int count, T previous, T current, Func<T, T, T> nextFunc)
    {
        var generator = new DelegateSequenceGenerator<T>(previous, current, nextFunc);
        var sequence = new List<T> { generator.Previous, generator.Current };

        for (int i = 0; i < count - 2; i++)
        {
            generator.GetNext();
            sequence.Add(generator.Next);
        }
        return sequence;
    }
}