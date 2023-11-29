using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugInBlueprint
{
    public class MecaCartesianCoordinate
    {
        public MecaCartesianCoordinate()
        {
            // Initialize properties with default values if needed
            X = 0.0;
            Y = 0.0;
            Z = 0.0;
            Rx = 0.0;
            Ry = 0.0;
            Rz = 0.0;
        }

        public MecaCartesianCoordinate(double X, double Y, double Z, double Rx, double Ry, double Rz)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.Rx = Rx;
            this.Ry = Ry;
            this.Rz = Rz;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public double Rx { get; set; }

        public double Ry { get; set; }

        public double Rz { get; set; }
    }
}
