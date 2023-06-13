using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SignUPAndLoginSection.Model;

public class Player
{
    public string first_name;
        [Key]
        public int id;
        public int now_cost;
        public string second_name;
        public int team;
        public int element_type;

        public int total_points;
        // photo ->string
}