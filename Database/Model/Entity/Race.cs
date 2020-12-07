using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Model.Entity
{
    public class Race
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Start")]
        public string Start { get; set; }
      //  public bool StartRace { get; set; }
        public RaceStatus status { get; set; }
        public Race() { }
        public Race(string number) {Start = number; }
    }
}
