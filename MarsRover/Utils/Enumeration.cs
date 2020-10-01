using MarsRover.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MarsRover.Utils
{
    public static class Enumeration
    {
        public static string GetShortNameValue(this Enum enumValue)
        {
            Type type = enumValue.GetType();
            FieldInfo fieldInfo = type.GetField(enumValue.ToString());

            ShortNameAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(ShortNameAttribute), false) as ShortNameAttribute[];

            if (attribs.Length > 0)
            {
                return attribs[0].Value;
            }
            else
            {
                return fieldInfo.Name;
            }
        }

        public static T GetValueFromShortName<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(ShortNameAttribute)) is ShortNameAttribute attribute)
                {
                    if (attribute.Value == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
            // Or return default(T);
        }
    }
}
