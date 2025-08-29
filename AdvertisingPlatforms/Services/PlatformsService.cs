using AdvertisingPlatforms.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AdvertisingPlatforms.Services
{
    public class PlatformsService
    {
        private readonly ConcurrentDictionary<string, List<string>> _locationToPlatforms = new();
        private readonly List<Platforms> _platforms = new();

        public void LoadFromLines(IEnumerable<string> lines)
        {
            var newPlatforms = new List<Platforms>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || !line.Contains(':'))
                    continue;

                var parts = line.Split(':', 2);
                var name = parts[0].Trim();
                var locations = parts[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .ToList();

                if (!string.IsNullOrWhiteSpace(name) && locations.Count > 0)
                    newPlatforms.Add(new Platforms { Name = name, Locations = locations });
            }

            _platforms.Clear();
            _platforms.AddRange(newPlatforms);

            _locationToPlatforms.Clear();
            foreach (var platform in _platforms)
            {
                foreach (var loc in platform.Locations)
                {
                    if (!_locationToPlatforms.ContainsKey(loc))
                        _locationToPlatforms[loc] = new List<string>();
                    _locationToPlatforms[loc].Add(platform.Name);
                }
            }
        }


        public List<string> Search(string location)
        {
            var result = new HashSet<string>();

            var current = location;
            while (!string.IsNullOrEmpty(current))
            {
                if (_locationToPlatforms.TryGetValue(current, out var platforms))
                {
                    foreach (var p in platforms)
                        result.Add(p);
                }

                var idx = current.LastIndexOf('/');
                if (idx <= 0) break;
                current = current.Substring(0, idx);
            }

            return result.OrderBy(x => x).ToList();
        }
    }
}
