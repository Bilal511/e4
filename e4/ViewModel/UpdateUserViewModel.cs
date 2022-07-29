using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace e4.ViewModel
{
    public class UpdateUserViewModel
    {
        [DisplayName("Id")]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; } = default!;

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
