using AdvertisingPlatforms.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdvertisingPlatforms.Tests
{
    public class PlatformServiceTests
    {
        private readonly PlatformsService _service;

        public PlatformServiceTests()
        {
            _service = new PlatformsService();
        }

        [Fact]
        public void LoadFromLines_ShouldLoadCorrectly()
        {
            var lines = new List<string>
            {
                "Яндекс.Директ:/ru",
                "Ревдинский рабочий:/ru/svrd/revda,/ru/svrd/pervik",
                "Крутая реклама:/ru/svrd"
            };

            _service.LoadFromLines(lines);

            var result = _service.Search("/ru/svrd/revda").ToList();

            Assert.Contains("Яндекс.Директ", result);
            Assert.Contains("Ревдинский рабочий", result);
            Assert.Contains("Крутая реклама", result);
        }

        [Fact]
        public void GetPlatformsByLocation_ShouldReturnGlobalPlatforms()
        {
            var lines = new List<string>
            {
                "Яндекс.Директ:/ru",
                "Газета уральских москвичей:/ru/msk,/ru/permobl"
            };
            _service.LoadFromLines(lines);

            var result = _service.Search("/ru/msk").ToList();

            Assert.Contains("Яндекс.Директ", result);
            Assert.Contains("Газета уральских москвичей", result);
        }

        [Fact]
        public void GetPlatformsByLocation_ShouldReturnEmpty_WhenNoMatches()
        {
            var lines = new List<string>
            {
                "Яндекс.Директ:/ru",
                "Крутая реклама:/ru/svrd"
            };
            _service.LoadFromLines(lines);

            var result = _service.Search("/us/ny");

            Assert.Empty(result);
        }
    }
}
