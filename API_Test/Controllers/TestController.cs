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
    }
}
