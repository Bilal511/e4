using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;

namespace e4.Pages.Users
{
    public class DeleteModel : PageModel
    {
        public IActionResult OnGet(string id)
        {
            XmlDocument doc = xmlDocument();
            var root = doc.SelectSingleNode("Users");
            var node = root.SelectSingleNode("User[@id="+id+"]");
            root.RemoveChild(node);
            doc.Save(@"Users.Xml");
            return new RedirectToPageResult("Index");
        }


        private static XmlDocument xmlDocument()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Users.Xml");
            return doc;
        }
    }
}
