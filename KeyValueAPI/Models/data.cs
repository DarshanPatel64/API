using System.ComponentModel.DataAnnotations;

namespace KeyValueAPI.Models
{
    public class data
    {
        [Required]
        [Key]
        public string Key { get; set; } 
        public string Value { get; set; }    
    }
}
