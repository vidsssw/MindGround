using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MindGround.Models
{
    public class MoodBoard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Your Mood")]
        public string Name { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
