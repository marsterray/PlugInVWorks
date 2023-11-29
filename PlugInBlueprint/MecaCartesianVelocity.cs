using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugInBlueprint
{
    public class MecaCartesianVelocity
    {
        //Coordinates are in mm/s and degrees/s

        public MecaCartesianVelocity(double XVelocity, double YVelocity, double ZVelocity, double RxVelocity, double RyVelocity, double RzVelocity)
        {
            this.XVelocity = XVelocity;
            this.YVelocity = YVelocity;
            this.ZVelocity = ZVelocity;
            this.RxVelocity = RxVelocity;
            this.RyVelocity = RyVelocity;
            this.RzVelocity = RzVelocity;
        }

        public double XVelocity { get; set; }

        public double YVelocity { get; set; }

        public double ZVelocity { get; set; }

        public double RxVelocity { get; set; }

        public double RyVelocity { get; set; }

        public double RzVelocity { get; set; }
    }
}
