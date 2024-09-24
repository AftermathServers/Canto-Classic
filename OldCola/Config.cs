using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace OldCola
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    
        public bool Debug { get; set; }

        public float ColaDamageMultiplier { get; set; } = 1f;

        [Description("This must have atleast 4 values, the 1st value is given when the player's cola intensity is 1, etc.")]
        public List<int> SpeedIntensityPerCola { get; set; } = new()
        {
            1,
            1,
            1,
            1
        };

    }
}