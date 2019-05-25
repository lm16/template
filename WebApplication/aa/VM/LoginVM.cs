using System.ComponentModel.DataAnnotations;

namespace Project.VM
{
    public class LoginVM
    {
        [Required]
        public string name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string pwd { get; set; }

    }
}
