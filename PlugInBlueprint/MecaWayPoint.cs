using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugInBlueprint
{
    public class MecaWayPoint
    {
        public MecaWayPoint(MecaCartesianCoordinate CartesianCoordinates, MecaConfiguration ArmConfiguration)
        {
            this.CartesianCoordinates = CartesianCoordinates;
            this.ArmConfiguration = ArmConfiguration;
        }

        public MecaCartesianCoordinate CartesianCoordinates { get; set; }

        public MecaConfiguration ArmConfiguration { get; set; }
    }
}
