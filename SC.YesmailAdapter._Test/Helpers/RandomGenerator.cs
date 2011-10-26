using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SC.YesmailAdapter._Test.Helpers
{
    public static class RandomGenerator
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);

        public static string RandomString(int size)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < size; i++)
            {
                char character = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(character);
            }

            return builder.ToString();
        }

        public static string RandomEmail()
        {
            return RandomString(10) + "@testmail.com";
        }

        public static int RandomInt(int min, int max)
        {
            return random.Next(min, max);
        }

        public static string RandomConsumerId()
        {
            return random.Next(1000000, 9999999).ToString();
        }
    }
}
