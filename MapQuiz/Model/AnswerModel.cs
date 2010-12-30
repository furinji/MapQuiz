using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapQuiz
{
    public sealed class AnswerModel
    {
        public AnswerModel()
        {
            Items = new List<Item>();
        }

        //[System.Xml.Serialization.XmlArrayItem(typeof(AnswerModel.Item))]
        public List<Item> Items { get; set; }
        //public IList<Item> Items { get; set; }

        public bool InRangeIdx(int idx)
        {
            if (0 <= idx && idx < Items.Count)
            {
                return true;
            }
            return false;
        }

        public void ExchangeItemsAt(int idx1, int idx2)
        {
            var temp = Items[idx1];
            Items[idx1] = Items[idx2];
            Items[idx2] = temp;
        }

        public string GetFirstValue()
        {
            var item = Items.FirstOrDefault();
            return (item != null) ? item.Value : null;
        }

        public class Item
        {
            public Item()
            {
            }
            public Item(string value)
            {
                Value = value;
            }

            public string Value { get; set; }
        }

    }
}
