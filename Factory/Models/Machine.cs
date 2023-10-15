using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MechanicManager.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    [Required(ErrorMessage = "Please enter a model name for the machine.")]
    public string ModelName { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}