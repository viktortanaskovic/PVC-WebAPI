using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UpitiPVC.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [Required]
        [StringLength(500)]
        public string AnswerText { get; set; } = null!;
        public DateTime? CreatedTime { get; set; }
        public int QuestionId { get; set; }
        [ForeignKey(nameof(QuestionId))]
        [JsonIgnore]
        public Question? Question { get; set; }
    }
}
