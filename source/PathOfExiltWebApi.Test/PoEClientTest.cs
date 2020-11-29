using Xunit;

using PathOfExileWebApi;

namespace PathOfExiltWebApi.Test
{
    public class PoEClientTest
    {
        [Fact]
        public async void SeasonsTest()
        {
            var client = new PoEClient();
            var seasons = await client.Seasons.Get();

            Assert.NotNull(seasons);
        }
    }
}
