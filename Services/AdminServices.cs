using template_api_aspnet.Models;
namespace template_api_aspnet.Services
{
    public class AdminServices
    {
        public async Task<bool> SignIn(string username, string password)
        {
            Admin admin = new Admin();
            admin.username= "admin";
            admin.password= "admin";

            if(admin.username == username && admin.password == password)
            {
                return true;
            }
            return false;   
        } 

    }
}
