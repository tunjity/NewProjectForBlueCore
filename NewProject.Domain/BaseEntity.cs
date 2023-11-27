

using System.ComponentModel.DataAnnotations;
namespace NewProject.Domain;

public class BaseEntity
{
    [Key]
    public long Id { get; set; }
    public string UniqueId { get; set; } 
    public DateTime DateCreated { get; set; } 
}  
