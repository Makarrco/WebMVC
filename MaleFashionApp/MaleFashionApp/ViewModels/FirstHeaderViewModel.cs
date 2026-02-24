using MaleFashionApp.Entities;

namespace MaleFashionApp.Models;

public class FirstHeaderViewModel
{
    public Option SignIn { get; set; }
    
    public Option FAQ { get; set; }
    
    public IEnumerable<Option> Currencies { get; set; }
}