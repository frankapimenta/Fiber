using System.ComponentModel.DataAnnotations;

namespace Fiber.Examples.Data
{
    public class PostCreateDTO
    {
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        
    }
}
