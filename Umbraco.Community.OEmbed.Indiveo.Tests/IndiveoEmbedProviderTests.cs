using System.Threading;
using System.Threading.Tasks;
using Moq;
using Umbraco.Cms.Core.Serialization;
using Xunit;
using Umbraco.Cms.Core.Media.EmbedProviders;
using Umbraco.Community.OEmbed.Indiveo.EmbedProviders;

namespace Umbraco.Community.OEmbed.Indiveo.Tests
{
    public class TestableIndiveoEmbedProvider : IndiveoEmbedProvider
    {
        public object? FakeResponse { get; set; }

        public TestableIndiveoEmbedProvider(IJsonSerializer serializer) : base(serializer) { }

        public override Task<T?> GetJsonResponseAsync<T>(string url, CancellationToken cancellationToken = default) where T : class
        {
            return Task.FromResult(FakeResponse as T);
        }
    }

    public class IndiveoEmbedProviderTests
    {
        [Fact]
        public async Task GetMarkupAsync_ReturnsHtml_FromFakeResponse()
        {
            var serializerMock = new Mock<Umbraco.Cms.Core.Serialization.IJsonSerializer>();

            var fake = new OEmbedResponse
            {
                Html = "mock_oembed_result"
            };

            var provider = new TestableIndiveoEmbedProvider(serializerMock.Object)
            {
                FakeResponse = fake
            };

            var markup = await provider.GetMarkupAsync("https://indiveo.services/embed/f1557bd7-1584-495a-aecd-827189d6a471", null, null, CancellationToken.None);

            Assert.Equal("mock_oembed_result", markup);
        }

        [Fact]
        public void GetEmbedProviderUrl_ReturnsOEmbedUrl_With_Values()
        {
            var serializerMock = new Mock<Umbraco.Cms.Core.Serialization.IJsonSerializer>();

            var provider = new IndiveoEmbedProvider(serializerMock.Object){};

            var markup = provider.GetEmbedProviderUrl("https://indiveo.services/embed/f1557bd7-1584-495a-aecd-827189d6a471", 400, 600);

            Assert.Equal("https://indiveo.services/oembed?url=https%3A%2F%2Findiveo.services%2Fembed%2Ff1557bd7-1584-495a-aecd-827189d6a471&maxwidth=400&maxheight=600", markup);
        }

        [Fact]
        public void GetEmbedProviderUrl_ReturnsOEmbedUrl_With_Null_Values()
        {
            var serializerMock = new Mock<Umbraco.Cms.Core.Serialization.IJsonSerializer>();

            var provider = new IndiveoEmbedProvider(serializerMock.Object){};

            var markup = provider.GetEmbedProviderUrl("https://indiveo.services/embed/f1557bd7-1584-495a-aecd-827189d6a471", null, null);

            Assert.Equal("https://indiveo.services/oembed?url=https%3A%2F%2Findiveo.services%2Fembed%2Ff1557bd7-1584-495a-aecd-827189d6a471", markup);
        }

        [Fact]
        public void ApiEndpoint_ItCanGet()
        {
            var serializerMock = new Mock<Umbraco.Cms.Core.Serialization.IJsonSerializer>();

            var provider = new IndiveoEmbedProvider(serializerMock.Object){};

            Assert.Equal("https://indiveo.services/oembed", provider.ApiEndpoint);
        }

        [Fact]
        public void UrlSchemeRegex_ItCanGet()
        {
            var serializerMock = new Mock<Umbraco.Cms.Core.Serialization.IJsonSerializer>();

            var provider = new IndiveoEmbedProvider(serializerMock.Object){};

            Assert.Equal(new[] { "https://indiveo.services/embed/.*", "https://indiveo.services/divis/weblink/*" }, provider.UrlSchemeRegex);
        }
    }
}