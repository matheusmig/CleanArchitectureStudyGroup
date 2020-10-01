using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public sealed class Notification
    {
        private readonly IDictionary<string, IList<string>> _errorMessages= new Dictionary<string, IList<string>>();

        public IDictionary<string, string[]> ModelState 
            => _errorMessages.ToDictionary(item => item.Key, item => item.Value.ToArray());

        public bool IsValid => !_errorMessages.Any();
        public bool IsInvalid => _errorMessages.Any();

        public void Add(string key, string message)
        {
            if (!_errorMessages.ContainsKey(key))
            {
                _errorMessages[key] = new List<string>();
            }

            _errorMessages[key].Add(message);
        }
    }
}
