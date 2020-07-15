using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ngay14_7.Models.ViewModels
{
    public class LoginAccountRequest
    {
        [Required(ErrorMessage ="Ten TK ko dc bo trong")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mk ko dc bo trong")]
        [DataType(DataType.Password)]
        public string Passwword { get; set; }
    }
}
