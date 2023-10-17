using System;
using System.Linq;

class ListInt
{
    private int[] array;
    private int size;

    public ListInt(int size)
    {
        array = new int[size];
        this.size = size;
    }

    public int this[int index]
    {
        get
        {
            return array[index];
        }
        set
        {
            array[index] = value;
        }
    }

    public void Add(int num)
    {
        if (size == array.Length)
        {
            int newSize = Math.Max(4, size * 2);
            Array.Resize(ref array, newSize);
        }

        array[size] = num;
        size++;
    }

    public void AddRange(params int[] nums)
    {
        if (size + nums.Length > array.Length)
        {
            int newSize = Math.Max(size + nums.Length, array.Length * 2);
            Array.Resize(ref array, newSize);
        }

        foreach (int num in nums)
        {
            array[size] = num;
            size++;
        }
    }

   public bool Contains(int num)
{
    return array.Contains(num);
}

    public int Sum()
{
    int sum = 0;
    for (int i = 0; i < size; i++)
    {
        sum += array[i];
    }
    return sum;
}

    public void Remove(int num)
    {
        array = array.Where(x => x != num).ToArray();
        size = array.Length;
    }

    public void RemoveRange(params int[] nums)
    {
        ///??? :(
    }

    public override string ToString()
{
    if (size == 0)
    {
        return string.Empty;
    }

    string result = array[0].ToString();
    for (int i = 1; i < size; i++)
    {
        result += $", {array[i]} ";
    }

    return result;
}
}

class Program
{
    static void Main(string[] args)
    {
        ListInt list = new ListInt(5);

        list.Add(5);
        list.AddRange(10, 20, 30);
        Console.WriteLine(list);
        Console.WriteLine("Contains 10: " + list.Contains(10));
        Console.WriteLine("Sum: " + list.Sum());

        list.Remove(10);
        list.RemoveRange(20, 30);
        Console.WriteLine("List after removal: " + list);
    }
}
