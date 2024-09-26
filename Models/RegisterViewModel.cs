using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RegisterViewModel
    {
        public string  Username { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Confirm Password")]
        [Compare("Password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
        public string Address { get; set; }

    }
}
