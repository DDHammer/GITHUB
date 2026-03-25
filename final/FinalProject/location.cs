public abstract class Location
    {
        protected string _destinationName;
        protected string _weatherCondition;
        public Location(string name, string weather)
        {
            _destinationName = name;
            _weatherCondition = weather.ToLower();
        }

        public abstract List<GearItem> GetRequiredGear();
        public abstract void ShowSafetyTips();
    }