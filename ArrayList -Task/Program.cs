
using System;
internal class Program
{
    private static void Main(string[] args)
    {
        IntArrayList list = new IntArrayList();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.Add(6);


        list.GetElements();
        Console.WriteLine("firstindexof:" + list.FirstIndexOf(3) + "\n" +
            "lastindexof: " + list.LastIndexOf(3));

        list.Remove(2); 
        Console.WriteLine("After removing element at index 2:");
        list.GetElements();

        int invalidIndex = 1;
        try
        {
            Console.WriteLine($"Element at index {invalidIndex}: {list[invalidIndex]}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        
        Console.WriteLine("Element at index 4 before setting to zero: " + list[4]);
        list[4] = 0; 
        Console.WriteLine("Element at index 4 after setting to zero: " + list[4]);
        list.GetElements();


        
        try
        {
            int element = list[10]; 
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
        Console.WriteLine(list);
    }
}


    class IntArrayList
    {
        int[] _arr;
        public int Capacity { get; private set; } = 5;
        public int Count { get; private set; } = 0;

        public IntArrayList()
        {
            _arr = new int[Capacity];
        }
        public IntArrayList(int capacity)
        {
            Capacity = capacity;
            _arr = new int[Capacity];

        }
        public void Add(int value)
        {
            if ( _arr.Length == Count )
            {
                Array.Resize(ref _arr, Count + Capacity);
            }
            _arr[Count++] = value;
        }
        public void GetElements()
        {
            for (int i=0; i < Count; i++)
            {
                Console.WriteLine(_arr[i]);
            }
        }
        public int FirstIndexOf(int value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_arr[i] == value)
                {
                    return i;
                }
            }
            return -1; // Dəyər tapılmadı
        }

        public int LastIndexOf(int value)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                if (_arr[i] == value)
                {
                    return i;
                }
            }
            return -1; // If value is not found
        }
    public void Remove(int index)
    {
        if (index < 0 || index >= Count)
        {
            return;
        }

        _arr[index] = 0;
    }
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Yanlis indeks"); 
            }
            return _arr[index];
        }
        set
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Yanlis indeks"); 
            }
            _arr[index] = value;
        }
    }
    //public override string ToString()
    //{
    //    string[] elements = new string[Count];

    //    for (int i = 0; i < Count; i++)
    //    {
    //        elements[i] = _arr[i].ToString();
    //    }

    //    return "[" + string.Join(", ", elements) + "]";
    //}
    public override string ToString()
    {
        string[] elements = new string[Count];

        for (int i = 0; i < Count; i++)
        {
            elements[i] = _arr[i].ToString();
        }

        return "[" + string.Join(", ", elements) + "]";
    }



}
