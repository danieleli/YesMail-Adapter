using System.Collections.Generic;
using System.Reflection;
using SC.YesMailAdapter.Attributes;

namespace SC.YesMailAdapter.Mappers
{
    public class KeyValueMapper
    {
        public static keyValue[] FlattenPropertiesToNameValueList(object dto)
        {
            var list = new List<keyValue>();

            foreach (PropertyInfo property in dto.GetType().GetProperties())
            {
                if (property.GetCustomAttributes(typeof(SideTableTolkenAttribute), false).Length > 0)
                {
                    AddToList(dto, list, property);
                }
            }

            return list.ToArray();
        }

        private static void AddToList(object dto, List<keyValue> list, PropertyInfo property)
        {
            var propertyValue = property.GetValue(dto, null);
            if (propertyValue != null)
            {
                list.Add(new keyValue()
                {
                    name = property.Name.ToLower(),
                    value = property.GetValue(dto, null).ToString()
                });
            }
        }
    }
}
