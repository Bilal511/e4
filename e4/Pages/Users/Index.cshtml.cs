using e4.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;

namespace e4.Pages.Users
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<UpdateUserViewModel>? ObjectToDisplay { get; set; }

        public IActionResult OnGet()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(@"Users.Xml");
            var nodes = doc.SelectNodes("Users/User");
            var user = new List<UpdateUserViewModel>();
            if (nodes != null)
            {
                foreach (XmlNode i in nodes)
                {
                    user.Add(new UpdateUserViewModel { Id = i.Attributes[0].Value, Name = i.ChildNodes[0].InnerText, Surname = i.ChildNodes[1].InnerText, CellNumber = i.ChildNodes[2].InnerText });
                }
            }
            ObjectToDisplay = user;
            return Page();
        }
    }
}
