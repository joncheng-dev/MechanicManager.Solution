using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MechanicManager.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Please enter up to 40 alphanumeric characters. '_' is also a valid character.")]
    [Required(ErrorMessage = "Please enter a valid name for the engineer.")]
    public string Name { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}