using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugInBlueprint
{
    public class MecaJointVelocity
    {
        public MecaJointVelocity(double Joint1Velocity, double Joint2Velocity, double Joint3Velocity, double Joint4Velocity, double Joint5Velocity, double Joint6Velocity)
        {
            this.Joint1Velocity = Joint1Velocity;
            this.Joint2Velocity = Joint2Velocity;
            this.Joint3Velocity = Joint3Velocity;
            this.Joint4Velocity = Joint4Velocity;
            this.Joint5Velocity = Joint5Velocity;
            this.Joint6Velocity = Joint6Velocity;
        }

        public double Joint1Velocity { get; set; }

        public double Joint2Velocity { get; set; }

        public double Joint3Velocity { get; set; }

        public double Joint4Velocity { get; set; }

        public double Joint5Velocity { get; set; }

        public double Joint6Velocity { get; set; }

    }
}
