using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
   public class RaceModel
    {
        public int Id { get; set; }
        public string Start { get; set; }
        public bool StartRace { get; set; }
        public RaceStatus status { get; set; }
    }

    public enum RaceStatus
    {
        pending,
        running,
        finished
    }
}
