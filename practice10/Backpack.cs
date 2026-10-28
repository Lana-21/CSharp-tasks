using System;
using System.Collections.Generic;
using System.Text;

namespace Practice10
{
    public delegate void BackpackHandler(string message);
    public class Backpack
    {
        public string Color { get; set; }
        public string Brand { get; set; }
        public double Weight { get; set; }
        public double MaxVolume { get; set; }

        private Item[] items = new Item[0];
        public event BackpackHandler ItemAdded;
        public event BackpackHandler ItemRemoved;
        public Backpack(string color, string brand, double weight, double maxVolume)
        {
            Color = color;
            Brand = brand;
            Weight = weight;
            MaxVolume = maxVolume;
        }
        public void Put(Item item)
        {
            double currentVolume = 0;
            foreach (var i in items)
            {
                if (i != null) currentVolume += i.Volume;
            }
            if (currentVolume + item.Volume > MaxVolume)
            {
                throw new InvalidOperationException($"Not enough space for {item.Name}");
            }
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = item;
            ItemAdded?.Invoke($"Added: {item.Name} (Volume: {item.Volume})");
        }
        public void Remove(string itemName)
        {
            int index = -1;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i]?.Name == itemName)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new ArgumentException($"Item {itemName} not found in the backpack");
            }
            Item[] newItems = new Item[items.Length - 1];
            for (int i = 0, j = 0; i < items.Length; i++)
            {
                if (i != index)
                {
                    newItems[j++] = items[i];
                }
            }
            items = newItems;
            ItemRemoved?.Invoke($"Removed: {itemName}");
        }
    }
}
