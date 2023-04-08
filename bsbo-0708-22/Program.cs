static void PrintArr(int[] arr)
{
    foreach (var item in arr)
    {
        Console.Write($"{item.ToString()} ");
    }
    Console.WriteLine();
}

static void SortBubble(int[] arr)
{
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
}

int[] arr = new[]
{
    7, 6, 5, 45, 0, -2, 30, -12, 33, 52, 129, -22
};

PrintArr(arr);
SortBubble(arr);
PrintArr(arr);
