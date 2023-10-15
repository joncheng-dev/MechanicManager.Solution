using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MechanicManager.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "Please enter a name for the engineer.")]
    public string Name { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}