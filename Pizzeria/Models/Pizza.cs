using System.ComponentModel.DataAnnotations.Schema;

namespace Pizzeria.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Name { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Image { get; set; }

        public Pizza()
        {

        }

        public Pizza(int id, string name, string description, string image)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
        }
    }
}
