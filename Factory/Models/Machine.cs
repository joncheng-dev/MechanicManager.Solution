using System.Collections.Generic;

namespace MechanicManager.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    public string ModelName { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}