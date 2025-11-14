using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Umbraco.Community.OEmbed.Indiveo.Composers
{
    public class RegisterEmbedProvidersComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
            => builder.EmbedProviders().Append<EmbedProviders.IndiveoEmbedProvider>();
    }
}