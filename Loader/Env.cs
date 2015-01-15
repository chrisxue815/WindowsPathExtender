using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsPathExtender.Loader
{
    public class Env : ListExt<string>
    {
        public bool ContainsIgnoreCase(string value)
        {
            return this.Any(s => s.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        public new void Add(string item)
        {
            if (!ContainsIgnoreCase(item)) base.Add(item);
        }

        public new void AddRange(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void AddRange(List<string> items, int startIndex)
        {
            for (var i = startIndex; i < items.Count(); i++)
            {
                Add(items[i]);
            }
        }

        public void AddRange(List<string> items, int startIndex, int length)
        {
            var endIndex = startIndex + length;
            for (var i = startIndex; i < endIndex; i++)
            {
                Add(items[i]);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var path in this)
            {
                builder.AppendLine(path);
            }

            return builder.ToString();
        }
    }
}
