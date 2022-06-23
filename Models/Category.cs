namespace projectef.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Category")]
public class Category
{
    [Key]
    public Guid CategoryId { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Task> Categories { get; set; }
}
