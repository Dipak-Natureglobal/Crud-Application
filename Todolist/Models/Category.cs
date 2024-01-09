using System.ComponentModel;
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
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Display Order must be within the given range 1 to 100  !!")]
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        //dipak mourya  cahnges


    }
}
