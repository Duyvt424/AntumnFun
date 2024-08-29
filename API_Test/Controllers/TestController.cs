using Microsoft.AspNetCore.Mvc;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("diem-tb")]
        public string DiemTrungBinh(double math, double eng, double his, int major)
        {
            double diemTb;
            if (major == 1)
            {
                diemTb = (math * major + eng * 1 + his * 1) / (major + 1 + 1);
                return $"Điểm trung bình của bạn là {diemTb.ToString("#.##")}";
            }
            else
            if (major == 2)
            {
                diemTb = (math * 1 + eng * major + his * 1) / (1 + major + 1);
                return $"Điểm trung bình của bạn là {diemTb.ToString("#.##")}";
            }
            else
            if (major == 5)
            {
                diemTb = (math * 1 + eng * 1 + his * major) / (1 + 1 + major);
                return $"Điểm trung bình của bạn là {diemTb.ToString("#.##")}";
            }
            else
            {
                diemTb = (math * 1 + eng * 1 + his * 1) / (1 + 1 + 1);
                return $"Điểm trung bình của bạn là {diemTb.ToString("#.##")}";
            }
        }

        [HttpPost("find-the-pivot-integer")]
        public string FindThePivot(int n)
        {
            if (n == 1)
            {
                return $"Phần tử pivot là: {n}";
            }
            int leftValue = 1;
            int rightValue = n;
            int sumLeft = leftValue;
            int sumRight = rightValue;
            while (leftValue < rightValue)
            {
                if (sumLeft < sumRight)
                {
                    leftValue++;
                    sumLeft += leftValue;
                }
                else
                {
                    rightValue--;
                    sumRight += rightValue;
                }
                if (sumLeft == sumRight && leftValue + 1 == rightValue - 1)
                {
                    return $"Phần tử pivot là: {leftValue + 1}";
                }
            }
            return "Phần tử pivot là: -1";
        }

        [HttpPost ("palindrome-number")]
        public string PalindromeNumber(int n)
        {
            string strN = Convert.ToString(n);
            char[] charN = strN.ToCharArray();
            Array.Reverse(charN);
            string soDaoNguoc = new string(charN);
            for (int i = 0; i < strN.Length / 2; i++)
            {
                if (strN[i] != strN[strN.Length - i - 1])
                {
                    return $"Đọc lại thì ko phải số palindrome rồi vì {n} đọc ngược lại là: {soDaoNguoc}";
                }
            }
            return $"{n} là số palindrome vì đọc ngược hay xuôi thì vẫn ra {n}";
        }
    }
}
