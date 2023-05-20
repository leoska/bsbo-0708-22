using bsbo_0708_22;
using System;

internal class Program
{
    public static int N_OP = 0;
    
    // Вывод массива в консоль
    static void PrintArr(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write($"{item.ToString()} ");
        }
        Console.WriteLine();
    }
    
    // Сортировка обычного массива алгоритмом пузырька
    static void SortBubble()
    {
        int[] arr = new[]
        {
            7, 6, 5, 45, 0, -2, 30, -12, 33, 52, 129, -22
        };

        PrintArr(arr);
        
        int N = arr.Length;
        bool flag = false;
        for (int i = 0; i < N; i++)
        {
            flag = false;

            for (int j = 0; j < N - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Способ #1 (доп. память)
                    // O(9), M(1)
                    // int tmp = arr[j];
                    // arr[j] = arr[j + 1];
                    // arr[j + 1] = tmp;

                    // Способ #2 (больше вычислений)
                    // O(20), M(0)
                    // arr[j + 1] = arr[j + 1] + arr[j];
                    // arr[j] = arr[j + 1] - arr[j];
                    // arr[j + 1] = arr[j + 1] - arr[j];

                    // Способ #3 (Tuple swap)
                    // O(6 + k), M(2k)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);

                    flag = true;
                }
            }

            if (!flag)
            {
                break;
            }
        }
        
        PrintArr(arr);
    }

    // Ref vs Value types
    static void RefVsValueTypes()
    {
        // Value Types
        ElemValue a = new ElemValue(15);
        ElemValue b = a;
        
        // a = 15; b = 15;
        Console.WriteLine($"a: {a.value}; b: {b.value}");
        b.value = 33;
        // a = 15; b = 33
        Console.WriteLine($"a: {a.value}; b: {b.value}");


        // Ref Types
        Element p = new Element(15);
        Element l = p;
        
        // p = 15; l = 15;
        Console.WriteLine($"p: {p.value}; l: {l.value}");
        l.value = 33;
        // p = 33; l = 33
        Console.WriteLine($"p: {p.value}; l: {l.value}");
    }

    // Создание указателей между собой в Elem (подобие линейно-связанного списка)
    static void RefElems()
    {
        Element a = new Element(15);
        Element b = new Element(33);
        Element c = new Element(77);

        a.next = b;
        b.next = c;
        
        Console.WriteLine($"a: {a.value}, b: {a.next?.value}, c: {a.next?.next?.value}");
    }

    // Сортировка линейно-связанного списка алгоритмом Пузырек
    static void SortListElem()
    {
        ListElem list = new ListElem();
        Random rnd = new Random();

        int N = 5;

        for (int i = 0; i < N; i++)
        {
            list.Push(new Element(rnd.Next(0, 100)));
        }
        
        list.Print();

        // START SORTING
        Program.N_OP += 1;
        bool flagSwap = false;
        Program.N_OP += 2;
        // 2
        for (int i = 0; i < N; i++)
        {
            flagSwap = false; // 1

            Program.N_OP += 3;
            // 5
            for (int j = 0; j < N - i - 1; j++) // 2 + 3 = 5
            {
                Program.N_OP += 4;
                if (list[j] > list[j + 1]) // 1 + 3 = 4
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    Program.N_OP += 9;
                    flagSwap = true;
                }

                Program.N_OP += 5;
            }

            Program.N_OP += 2;
            if (!flagSwap)
            {
                Program.N_OP += 1;
                break;
            }
        }
        
        // END SORTING
        
        list.Print();
        Console.WriteLine($"N_OP: {Program.N_OP}");
    }
    
    // Сортировка стэка алгоритмом Пузырек
    static void SortStackElem()
    {
        StackElem stack = new StackElem();
        Random rnd = new Random();

        int N = 5;

        for (int i = 0; i < N; i++)
        {
            stack.Push(new Element(rnd.Next(0, 100)));
        }
        
        stack.Print();

        bool flagSwap = false;
        for (int i = 0; i < N; i++)
        {
            flagSwap = false;

            for (int j = 0; j < N - i - 1; j++)
            {
                if (stack[j] > stack[j + 1])
                {
                    (stack[j], stack[j + 1]) = (stack[j + 1], stack[j]);
                    flagSwap = true;
                }
            }

            if (!flagSwap)
                break;
        }
        
        stack.Print();
    }
    
    static void Main(string[] args)
    {
        // SortBubble();
        // RefVsValueTypes();
        // RefElems();
        SortListElem();
        // SortStackElem();
    }
}