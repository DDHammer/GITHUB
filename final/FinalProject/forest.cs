 public class ForestTrip : Location
    {
        public ForestTrip(string name, string weather) : base(name, weather) { }
        public override List<GearItem> GetRequiredGear()
        {
            var gear = new List<GearItem>();
            gear.Add(new GearItem("High-power Flashlight", 1.0));
            gear.Add(new GearItem("Protection (Gun/Bear Spray)", 4.0));

            if (_weatherCondition.Contains("rain"))
                gear.Add(new GearItem("Waterproof Tarp, Rain gear", 4.0));
            return gear;
        }
        public override void ShowSafetyTips()
        {
            Console.WriteLine("SAFETY: Store food in bear canisters!");
            Console.WriteLine("FUN: You could bring hammocks to set up in the trees!");
        }
    }