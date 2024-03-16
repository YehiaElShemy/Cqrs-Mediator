using System.ComponentModel.DataAnnotations.Schema;

namespace Cqrs_Mediator_Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(category))]
        public int Cate_id { get; set; }
        public Category category { get; set; } = new Category();
    }
}
