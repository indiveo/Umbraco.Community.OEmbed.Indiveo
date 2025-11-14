using Umbraco.Cms.Core.Media.EmbedProviders;
using Umbraco.Cms.Core.Serialization;

namespace Umbraco.Community.OEmbed.Indiveo.EmbedProviders
{
    public class IndiveoEmbedProvider : OEmbedProviderBase
    {
        public IndiveoEmbedProvider(IJsonSerializer jsonSerializer)
            : base(jsonSerializer)
        { }

        public override string ApiEndpoint => "https://indiveo.services/oembed";

        public override string[] UrlSchemeRegex => new[]
        {
            @"https://indiveo.services/embed/.*",
            @"https://indiveo.services/divis/weblink/*",
        };

        public override Dictionary<string, string> RequestParams => new();

        public override string? GetMarkup(string url, int maxWidth = 0, int maxHeight = 0)
        {
            var requestUrl = base.GetEmbedProviderUrl(url, maxWidth, maxHeight);
            OEmbedResponse? oembed = GetJsonResponse<OEmbedResponse>(requestUrl);

            return oembed?.GetHtml();
        }
    }
}