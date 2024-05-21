using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DeliveryApi;

namespace Site.MediaUrlProvider;

public class AbsolutePathApiUrlProviderComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
        => builder.Services.AddSingleton<IApiMediaUrlProvider, AbsolutePathApiUrlProvider>();
}
