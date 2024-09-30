using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortAndSearch : ControllerBase
    {
        [HttpPost("insertion-sort")]
        public string InsertionSort(int[] arr)
        {
            int n = arr.Length; // gán n = chiều dài mảng
            int key = 0; 
            int j = 0;
            for (int i = 1; i < n; i++) // lặp từ vtri i = 1
            {
                key = arr[i]; // gán key = gia trị tại arr[i]
                j = i - 1; // Khởi tạo j bằng i - 1, đây là vị trí trước i trong mảng
                while (j >= 0 && arr[j] > key) // Vòng lặp while kiểm tra và di chuyển phần tử lớn hơn key về phía sau để tạo chỗ trống cho key
                {
                    arr[j + 1] = arr[j]; //Di chuyển phần tử lớn hơn key về phía sau.
                    j = j - 1; //Di chuyển vị trí j lên trên để tiếp tục so sánh với key.
                }
                arr[j + 1] = key; //Chèn key vào vị trí đúng trong mảng đã sắp xếp.
            }
            return "Mảng sau khi đã sắp xếp là: " + string.Join(", ", arr);
        }
    }
}
