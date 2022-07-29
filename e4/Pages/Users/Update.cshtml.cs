using e4.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;

namespace e4.Pages.Users
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public UpdateUserViewModel ObjectToUpdate { get; set; } = default!;
        public void OnGet(string id)
        {
            XmlDocument doc = xmlDocument();
            XmlNode? name, surname, CellNumber;
            PopulateUser(doc, out name, out surname, out CellNumber, id);

            ObjectToUpdate = new UpdateUserViewModel()
            {
                Id = id,
                Name = name.InnerText,
                Surname = surname.InnerText,
                CellNumber = CellNumber.InnerText
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            UdateUser(ObjectToUpdate);
            return new RedirectToPageResult("Index");
        }

        public void UdateUser(UpdateUserViewModel userViewModel)
        {
            XmlDocument doc = xmlDocument();
            XmlNode? name, surname, CellNumber;
            PopulateUser(doc, out name, out surname, out CellNumber,ObjectToUpdate.Id);

            name.InnerText = ObjectToUpdate.Name;
            surname.InnerText = ObjectToUpdate.Surname;
            CellNumber.InnerText = ObjectToUpdate.CellNumber;
            doc.Save(@"Users.Xml");
        }

        private static void PopulateUser(XmlDocument doc, out XmlNode? name, out XmlNode? surname, out XmlNode? CellNumber,string id)
        {
            name = doc.SelectSingleNode("Users/User[@id=" + id + "]/Name");
            surname = doc.SelectSingleNode("Users/User[@id=" + id + "]/Surname");
            CellNumber = doc.SelectSingleNode("Users/User[@id=" + id + "]/CellNumber");
        }

        private static XmlDocument xmlDocument()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Users.Xml");
            return doc;
        }
    }
}
