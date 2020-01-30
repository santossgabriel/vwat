using System.ComponentModel.DataAnnotations;

namespace University.Models
{
  public class MailModel
  {
    [Required]
    public string From { get; set; }

    [Required]
    public string To { get; set; }

    [Required]
    public string Subject { get; set; }
    
    public string Body { get; set; }
  }
}