using System.Collections.Generic;
using System.Reflection;
using SC.YesMailAdapter.Attributes;

namespace SC.YesMailAdapter.Mappers
{
    public class SubcriberTolkenMapper
    {
        public static attributesAttribute[] FlattenPropertiesToNameValueList(object dto)
        {
            var list = new List<attributesAttribute>();

            foreach (PropertyInfo property in dto.GetType().GetProperties())
            {
                if (property.GetCustomAttributes(typeof(SubscriberTolkenAttribute), false).Length > 0)
                {
                    AddToList(dto, list, property);
                }
            }

            return list.ToArray();
        }

        private static void AddToList(object dto, List<attributesAttribute> list, PropertyInfo property)
        {
            var propertyValue = property.GetValue(dto, null);
            if (propertyValue != null)
            {
                list.Add(new attributesAttribute()
                {
                    name = property.Name.ToLower(),
                    value = property.GetValue(dto, null).ToString()
                });
            }
        }
    }
}
