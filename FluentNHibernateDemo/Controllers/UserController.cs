using FluentNHibernateDemo.DAO;
using Microsoft.AspNetCore.Mvc;

namespace DV_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        UserManage userManage = UserManage.Instance;

        [HttpGet]
        public IActionResult Index(string account,string password)
        {
            return Ok(userManage.Login(account,password));
        }

        [HttpPost]
        public IActionResult createAccount(string account, string password)
        {            
            return Ok(userManage.add(account, password));
        }

        [HttpDelete]
        public IActionResult delAccount(string account, string password)
        {
            return Ok(userManage.Delete(account, password));
        }
        [HttpPut]
        public IActionResult updatePassword(string account, string password, string newPassword)
        {
            return Ok(userManage.Updata(account, password, newPassword));
        }
    }
}