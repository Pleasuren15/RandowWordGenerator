using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RandowWordGenerator.Models
{
    public class RandomWordsViewModel
    {
        [Required]
        [DisplayName("Words")]
        public int NumberOfOWords { get; set; }

        [Required]
        [DisplayName("First Letter")]
        public string FirstLetter { get; set; } 

        [Required]
        [DisplayName("Last Letter")]
        public string LastLetter { get; set; }  
        
        [Required]
        [DisplayName("Paragraph(s)")]
        public string NumberOfParagraphs { get; set; }

        [DisplayName("Minimum")]
        [Required]
        public int MinimumWordLength { get; set; }
        
        [Required]
        [DisplayName("Maximum")]
        public int MaximumWordLength { get; set; }
    }
}
