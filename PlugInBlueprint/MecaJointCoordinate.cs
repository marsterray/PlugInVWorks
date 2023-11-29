using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugInBlueprint
{
    public class MecaJointCoordinate
    {
        public MecaJointCoordinate(double Joint1, double Joint2, double Joint3, double Joint4, double Joint5, double Joint6)
        {
            this.Joint1 = Joint1;
            this.Joint2 = Joint2;
            this.Joint3 = Joint3;
            this.Joint4 = Joint4;
            this.Joint5 = Joint5;
            this.Joint6 = Joint6;
        }

        public double Joint1 { get; set; }

        public double Joint2 { get; set; }

        public double Joint3 { get; set; }

        public double Joint4 { get; set; }

        public double Joint5 { get; set; }

        public double Joint6 { get; set; }
    }
}
