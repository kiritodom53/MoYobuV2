using System.Collections.Generic;

namespace MangaDex.Client.Helpers
{
    /// <summary>
    /// Dictionary with possible duplicated keys
    /// </summary>
    public class QueryParameters : List<KeyValuePair<string, string>>
    {
        /// <summary>
        /// Add new KeyValuePair to List
        /// </summary>
        /// <param name="key">Key parameter</param>
        /// <param name="value">Value parameter</param>
        public void Add(string key, string value)
        {
            var element = new KeyValuePair<string, string>(key, value);
            this.Add(element);
        }
    }
}