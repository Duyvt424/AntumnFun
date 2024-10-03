using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortAndSearch : ControllerBase
    {
        [HttpPost("insertion-sort")]
        public string InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++) // lặp từ vtri i = 1
            {
                int key = arr[i]; // gán key = gia trị tại arr[i]
                int j = i - 1; // Khởi tạo j bằng i - 1, đây là vị trí trước i trong mảng
                while (j >= 0 && arr[j] > key) // Vòng lặp while kiểm tra và di chuyển phần tử lớn hơn key về phía sau để tạo chỗ trống cho key
                {
                    arr[j + 1] = arr[j]; //Di chuyển phần tử lớn hơn key về phía sau.
                    j = j - 1; //Di chuyển vị trí j lên trên để tiếp tục so sánh với key.
                }
                arr[j + 1] = key; //Chèn key vào vị trí đúng trong mảng đã sắp xếp.
            }
            return "Mảng sau khi đã sắp xếp chèn là: " + string.Join(", ", arr);
        }

        [HttpPost("bubble-sort")]
        public string BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
            return "Mảng sau khi đã sắp xếp nổi bọt là: " + string.Join(", ", arr);
        }

        [HttpPost("selection-sort")]
        public string SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // Tìm vị trí giá trị nhỏ nhất trong đoạn từ i..n
                int minPosition = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[minPosition] > arr[j])
                    {
                        minPosition = j;
                    }
                }
                int tmp = arr[i];
                arr[i] = arr[minPosition];
                arr[minPosition] = tmp;
            }
            return "Mảng sau khi đã sắp xếp chọn là: " + string.Join(", ", arr);
        }

        [HttpPost("linear-search")]
        public string LinearSearch(int[] arr, int target)
        {
            int final = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (target == arr[i])
                {
                    final = i;
                }
            }
            return $"Index sau khi tìm kiếm tuyến tính là: {final}";
        }

        [HttpPost("binary-search")]
        public string BinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == target)
                {
                    return $"Index sau khi tìm kiếm nhị phân là: {mid}";
                }
                else if (arr[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return "Không tìm thấy";
        }
    }
}
