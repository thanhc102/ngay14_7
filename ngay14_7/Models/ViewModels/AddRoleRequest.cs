using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ngay14_7.Models.ViewModels
{
    public class AddRoleRequest
    {
        [Required(ErrorMessage ="ko dc bo trong truong nay")]
        public string RoleName { get; set; }
    }
}
