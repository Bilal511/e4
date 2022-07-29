using e4.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace e4.Pages.Users
{
    public class CreateUserModel : PageModel
    {
        [BindProperty]
        public UserViewModel ObjectToCreate { get; set; } = default!;

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please make sure that all the required fileds are not empty");
                return Page();
            }
            InsertUser(ObjectToCreate);
            return new RedirectToPageResult("Index");
        }

        private void InsertUser(UserViewModel userViewModel)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Users.Xml");
            var root = doc.SelectSingleNode("Users");
            XmlElement user = doc.CreateElement("User");
            if (root != null)
                root.AppendChild(user);

            XmlAttribute id = doc.CreateAttribute("id");
            id.Value = doc.SelectNodes("Users/User").Count.ToString();
            user.Attributes.Append(id);

            XmlElement name=doc.CreateElement("Name");
            name.InnerText = userViewModel.Name;
            user.AppendChild(name);

            XmlElement surnames = doc.CreateElement("Surname");
            surnames.InnerText = userViewModel.Surname;
            user.AppendChild(surnames);

            XmlElement cellNumber = doc.CreateElement("CellNumber");
            cellNumber.InnerText = userViewModel.CellNumber;
            user.AppendChild(cellNumber);

            doc.Save(@"Users.Xml");
        }
    }
}
