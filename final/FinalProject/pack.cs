public class Pack
    {
        private List<GearItem> _items = new List<GearItem>();
        public void AddItems(List<GearItem> items) => _items.AddRange(items);
        public void DisplayPack()
        {
            double total_weight = 0;
            Console.WriteLine("\n--- YOUR PACKING LIST ---");
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item._itemName} ({item._weight} lbs)");
                total_weight += item._weight;
            }
            Console.WriteLine($"TOTAL WEIGHT: {total_weight:F1} lbs");
        }
    }
