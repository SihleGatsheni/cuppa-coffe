using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using onlineShop.ViewModel;

namespace onlineShop.Controllers;

public class BaseController : Controller
{
    
    public void notify(string message, string title ="Foods",NotificationType notificationType = NotificationType.success){
        var msg = new 
        {
            message = message,
            title = title,
            icon = notificationType.ToString(),
            type = notificationType.ToString(),
            provider ="sweetAlert"
        };
        TempData["Notify"] = JsonConvert.SerializeObject(msg);
        
    }
}