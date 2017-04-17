using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Looking4Group.Models
{
    public class Game
    {
        public int GameID { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(128, ErrorMessage = "Max size: 128")]
        public String Name { get; set; }

        [StringLength(1024, ErrorMessage = "Max size: 1024")]
        public String Description { get; set; }

        [StringLength(128, ErrorMessage = "Max size: 128")]
        [DataType(DataType.Url, ErrorMessage = "Please enter a valid URL!")]
        public String Link { get; set; }

        public ICollection<GameTag> Tags { get; set; }

        public Game()
        {
            Tags = new List<GameTag>();
        }
    }
}
