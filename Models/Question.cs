using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UpitiPVC.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [Required]
        [StringLength(100)]
        public string EmailAddress { get; set; } = null!;
        [Required]
        [StringLength(500)]
        public string QuestionText { get; set; } = null!;
        [Required]
        public bool IsAnswered { get; set; } = false;
        public DateTime? CreatedTime { get; set; } = DateTime.Now;
        public DateTime? AnsweredTime { get; set; }
        [JsonIgnore]
        public ICollection<Answer>? Answers { get; set; }
    }
}
