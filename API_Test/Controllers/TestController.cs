using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace API_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

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

        [HttpPost("roman-to-integer")]
        public string RoManToInt(string s)
        {
            if (s.Length <= 1 || s.Length >= 15)
            {
                return "S không được quá dài hoặc quá ngắn!";
            }
            foreach (char c in s)
            {
                if (c != 'I' && c != 'V' && c != 'X' && c != 'L' && c != 'C' && c != 'D' && c != 'M')
                {
                    return "Chuỗi chứa ký tự không hợp lệ!";
                }
            }
            Dictionary<char, int> roManValues = new Dictionary<char, int>()
            {
                {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
            };
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1 && roManValues[s[i]] < roManValues[s[i + 1]])
                {
                    result -= roManValues[s[i]];
                }
                else
                {
                    result += roManValues[s[i]];
                }
            }
            if (result < 1 || result > 3999)
            {
                return "Vui lòng nhập số từ 1 - 3999!";
            }
            return $"Giá trị của số la mã là: {result}";
        }
        //kho vcl del hieu
        [HttpPost("majority-element")]
        public string MajorityElement(int[] nums)
        {
            int candidate = 0;
            int count = 0;

            foreach (int num in nums)
            {
                if (count == 0)
                {
                    candidate = num;
                    count = 1;
                }
                else if (candidate == num)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }
            return $"Phần tử xuất hiện nhiều nhất trong mảng là: {candidate}";
        }

        [HttpPost("longest-common-prefix")]
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            var shortest = strs[0];
            foreach (var str in strs)
            {
                if (str.Length < shortest.Length)
                {
                    shortest = str;
                }
            }
            for (int i = 0; i < shortest.Length; i++) // Sửa strs.Length thành shortest.Length
            {
                char currentChar = shortest[i];
                foreach (var str in strs)
                {
                    if (i >= str.Length || str[i] != currentChar) // Thêm kiểm tra i >= str.Length
                    {
                        return shortest.Substring(0, i);
                    }
                }
            }
            return shortest;
        }

        [HttpPost("valid-parentheses")]
        public bool IsValid(string s)
        {
            while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
            {
                s = s.Replace("()", "").Replace("[]", "").Replace("{}", "");
            }
            if (s.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost("search-insert-position")]
        public string SearchInsert(int[] nums, int target)
        {
            var num = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (target == nums[i])
                {
                    num = i;
                    break;
                }
                else if (target < nums[i])
                {
                    num = i;
                    break;
                }
                else if (i == nums.Length - 1)
                {
                    num = nums.Length;
                }
            }
            return $"Vị trí taget trong mảng là: {num}";
        }

        [HttpPost("length-of-last-word")]
        public string LengthOfLastWord(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "Chuỗi bạn nhập vào không đúng!";
            }

            s = s.Trim();
            int length = 0;
            for (int i = s.Length - 1; i >= 0 ; i--)
            {
                if (s[i] == ' ')
                {
                    break;
                }
                length++;
            }
            return $"Chiều dài của từ cuối trong đoạn là: {length}";
        }

        [HttpPost("sqrtx")]
        public string MySqrt(long x)
        {
            var number = x;
            var y = 1;
            var epsilon = 0.1;
            while (number - y > epsilon)
            {
                number = (number + y) / 2;
                y = Convert.ToInt32(x / number);
            }
            return $"căn bậc hai của {x} là: {number}";
        }
    }
}
