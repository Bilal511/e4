using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace e4.ViewModel
{
    public class UserViewModel
    {
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = default!;

        [DisplayName("Surname")]
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; } = default!;

        [StringLength(10)]
        [DisplayName("Cell Number")]
        [Required(ErrorMessage = "Cell Number is required")]
        public string CellNumber { get; set; } = default!;
    }
}
