using System;
using System.Collections.Generic;
using System.Linq;
using TaskTracker.UI.Models;

namespace TaskTracker.UI.Utilities
{
    /// <summary>
    /// Generic CSV parser class for converting CSV strings to objects of type T.
    /// </summary>
    /// <typeparam name="T">Type of the object to parse CSV into. T must implement IRecord and have a parameterless constructor.</typeparam>
    public class CsvParser<T> where T : IRecord, new()
    {
        /// <summary>
        /// Parses a CSV string into an object of type T.
        /// </summary>
        /// <param name="csv">CSV string to parse.</param>
        /// <returns>An object of type T populated with values from the CSV string.</returns>
        public T Parse(string csv)
        {
            // Check for null or empty CSV string.
            if (string.IsNullOrEmpty(csv))
                throw new ArgumentNullException("Your given string is null or empty or you passed a null object");

            // Create an instance of type T.
            T result = new T();

            // Split CSV string into values.
            var values = csv.Split(',');

            // Get properties of type T.
            var properties = typeof(T).GetProperties();

            // Check if the number of values matches the number of properties.
            if (values.Length != properties.Length)
                throw new ArgumentException("Invalid CSV Format.");

            // Assign values to properties.
            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                var value = Convert.ChangeType(values[i], property.PropertyType);
                property.SetValue(result, value);
            }

            return result;
        }
    }
}
