using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Mời bạn nhập độ dài mảng: ");
        int[] arrLength = new int[Convert.ToInt32(Console.ReadLine())];
        for (int i = 0; i < arrLength.Length; i++)
        {
            Console.Write($"Mời bạn nhập giá trị cho phần tử thứ {i + 1}: ");
            arrLength[i] = Convert.ToInt32(Console.ReadLine());
        }
        InsertionSort(arrLength);
        Console.WriteLine("Mảng sau khi sắp xếp chèn là: ");
        foreach (var x in arrLength)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
        //
        Console.WriteLine("Mảng sau khi sắp xếp nổi bọt là: ");
        BubbleSort(arrLength);
        foreach (var x in arrLength)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
        //
        Console.WriteLine("Mảng sau khi sắp xếp chọn là: ");
        SelectionSort(arrLength);
        foreach (var x in arrLength)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
        //
        Console.WriteLine("Mời bạn nhập số cần tìm kiếm: ");
        int key = Convert.ToInt32(Console.ReadLine());
        int value = BinarySearch(arrLength, key);
        Console.Write($"Vị trí của số cần tìm trong mảng là: {value}");
    }
    public static void InsertionSort(int[] arr)
    {
        for(int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while(j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }

    public static void BubbleSort(int[] arr)
    {
        for(int i = 0; i < arr.Length - 1; i++)
        {
            for(int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] < arr[j])
                {
                    int tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
            }
        }
    }

    public static void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minP = i;
            for(int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minP])
                {
                    minP = j;
                }
            }
            int tmp = arr[i];
            arr[i] = arr[minP];
            arr[minP] = tmp;
        }
    }

    public static int LinearSearch(int[] arr, int key)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == key)
            {
                return i;
            }
        }
        return -1;
    }

    public static int BinarySearch(int[] arr, int key)
    {
        int left = 0;
        int rigth = arr.Length - 1;
        while(left <= rigth)
        {
            int mid = left + (rigth - left) / 2;
            if (arr[mid] == key)
            {
                return mid;
            }
            else if (arr[mid] < key)
            {
                left = mid + 1;
            }
            else
            {
                rigth = mid - 1;
            }
        }
        return - 1;
    }
}