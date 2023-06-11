using SignUPAndLoginSection.businessLayer;
using System;
using SignUPAndLoginSection.DataAccessLayer;
namespace SignUPAndLoginSection.presentationLayer;

public class Player
{ 
        public string first_name{ get; set; }
        public int id{ get; set; }
        public int now_cost{ get; set; }
        public string second_name{ get; set; }
        public int team{ get; set; }
        public int element_type{ get; set; }

        public int total_points{ get; set; }
        // photo ->string
        
}