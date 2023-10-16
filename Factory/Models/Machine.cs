using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MechanicManager.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    [RegularExpression(@"^[a-zA-Z0-9_. ]+$", ErrorMessage = "Please enter up to 40 alphanumeric characters. '_' is also a valid character.")]
    [Required(ErrorMessage = "Please enter a model name for the machine.")]
    public string ModelName { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}