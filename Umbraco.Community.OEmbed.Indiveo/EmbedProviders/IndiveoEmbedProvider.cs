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

        public override async Task<string?> GetMarkupAsync(string url, int? maxWidth, int? maxHeight, CancellationToken cancellationToken)
        {
            var requestUrl = base.GetEmbedProviderUrl(url, maxWidth, maxHeight);
            OEmbedResponse? oembed = await GetJsonResponseAsync<OEmbedResponse>(requestUrl, cancellationToken);

            return oembed?.GetHtml();
        }
    }
}