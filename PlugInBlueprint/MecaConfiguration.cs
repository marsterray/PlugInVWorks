using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlugInBlueprint
{
    public class MecaConfiguration
    {
        public MecaConfiguration(int ShoulderConfiguration, int ElbowConfiguration, int WristConfiguration, int TurnConfiguration)
        {
            this.ShoulderConfiguration = ShoulderConfiguration;
            this.ElbowConfiguration = ElbowConfiguration;
            this.WristConfiguration = WristConfiguration;
            this.TurnConfiguration = TurnConfiguration;
        }

        public int ShoulderConfiguration { get; set; }

        public int ElbowConfiguration { get; set; }

        public int WristConfiguration { get; set; }

        public int TurnConfiguration { get; set; }
    }
}
