using Umbraco.Cms.Api.Common.DependencyInjection;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DeliveryApi;

namespace Site.ContentResponseBuilder;

public class ServerVersionResponseBuilderComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services
            .AddSingleton<IApiContentResponseBuilder, ServerVersionResponseBuilder>();

        builder.Services
            .AddControllers()
            .AddJsonOptions(
                Constants.JsonOptionsNames.DeliveryApi, 
                options => options
                    .JsonSerializerOptions
                    .TypeInfoResolver = new ServerVersionJsonTypeInfoResolver());
    }
}