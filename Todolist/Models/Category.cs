using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Todolist.Models
{
    public class Category
    {
        // control+ . using system.compoenent etc
        [Key]
        public int Id { get; set; }
        [Required]        
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;


    }
}
