public class LakeTrip : Location
    {
        public LakeTrip(string name, string weather) : base(name, weather) { }
        public override List<GearItem> GetRequiredGear()
        {
            var gear = new List<GearItem>();
            gear.Add(new GearItem("Fishing Pole and Tackle", 3.5));

            if (_weatherCondition.Contains("sunny")) gear.Add(new GearItem("Sun Screen", 0.5));
            else gear.Add(new GearItem("A Hoodie", 1.5));
            return gear;
        }
        public override void ShowSafetyTips()
        {
            Console.WriteLine("SAFETY: Make sure you wear a Life Jacket!");
            Console.WriteLine("FUN: Try to catch some fish with your gear!");
        }
    }