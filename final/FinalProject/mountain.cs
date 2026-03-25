public class MountainTrip : Location
    {
        public MountainTrip(string name, string weather) : base(name, weather) { }
        public override List<GearItem> GetRequiredGear()
        {
            var gear = new List<GearItem>();
            gear.Add(new GearItem("Light Windbreaker/Jacket", 1.0));

            if (_weatherCondition.Contains("cold") || _weatherCondition.Contains("snow"))
            {
                gear.Add(new GearItem("Winter Clothes (Snow pants, jacket, boots, gloves)", 6.0));
                gear.Add(new GearItem("Hand warmers, Heater", 0.5));
            }
            return gear;
        }
        public override void ShowSafetyTips()
        {
            Console.WriteLine("SAFETY: Watch for frostbite or hypothermia!");
            Console.WriteLine("FUN: Bring lots of firewood for a bonfire and some hot chocolate!");
        }
    }