using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RandowWordGenerator.Models
{
    public class RandomWordsViewModel
    {
        [Required]
        [DisplayName("Words")]
        public int NumberOfOWords { get; set; }

        [DisplayName("First Letter")]
        public string FirstLetter { get; set; } = "";

        [DisplayName("Last Letter")]
        public string LastLetter { get; set; } = "";

        [DisplayName("Minimum")]
        [Required]
        public int MinimumWordLength { get; set; }

        [Required]
        [DisplayName("Maximum")]
        public int MaximumWordLength { get; set; }
    }
}
