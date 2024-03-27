using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_Mediator.Application.Features.Product
{
    public class productsVm
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        [Required(ErrorMessage ="please choose Category")]
        public int Cate_id { get; set; }
    }
}
