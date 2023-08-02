using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test.Models;
[Table("Person1")]
public class Person1
{
    [Key]
    public string PersonID { get; set; }
    public string PersonName { get; set; }
}