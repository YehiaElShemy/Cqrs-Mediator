using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs_Mediator.Application.Features.Product
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
