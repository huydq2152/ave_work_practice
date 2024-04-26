using System;
using System.Text;

namespace Contract
{
    public class Base26
    {
        public uint StringToUint(string val)
        {
            uint ret = 0;

            var values = val.ToCharArray();
            var last = values.Length - 1;

            for (int x = 0; x < values.Length; x++)
            {
                if (values[x] < 'a' || values[x] > 'z')
                    throw new ArgumentException("Not a valid Base26 string.", val);

                ret += (uint)(Math.Pow(26.0, x) * (values[last - x] - 'A'));
            }

            return ret;

        }
        public string UintToString(uint i)
        {
            var result = new StringBuilder();

            while (i > 0)
            {
                var remainder = i % 26;
                i /= 26;
                result.Insert(0, (char)((char)remainder + 'A'));
            };

            return result.ToString();
        }
    }
}
