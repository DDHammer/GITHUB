    public class EssentialGear
    {
        public List<GearItem> GetStandardItems()
        {
            return new List<GearItem>
            {
                new GearItem("Food ", 5.0),
                new GearItem("Water (2L)", 4.4),
                new GearItem("Camping Tent", 6.0),
                new GearItem("Lighter/Matches", 0.1),
                new GearItem("Sleeping Bag", 3.0),
                new GearItem("Extra Clothes", 2.5),
                new GearItem("Flashlight", 0.5),
                new GearItem("Hiking Shoes", 2.0),
                new GearItem("Pocket Knife", 0.3),
                new GearItem("First Aid Kit", 1.2),
                new GearItem("Power Bank", 0.8)
            };
        }
    }