using Umbraco.Cms.Core.DeliveryApi;
using Umbraco.Cms.Core.Models.DeliveryApi;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Site.ContentResponseBuilder;

public class ServerVersionResponseBuilder : ApiContentResponseBuilder
{
    private static readonly Version ServerVersion = new (1, 2, 345);
    
    public ServerVersionResponseBuilder(
        IApiContentNameProvider apiContentNameProvider,
        IApiContentRouteBuilder apiContentRouteBuilder,
        IOutputExpansionStrategyAccessor outputExpansionStrategyAccessor)
        : base(apiContentNameProvider, apiContentRouteBuilder, outputExpansionStrategyAccessor)
    {
    }

    protected override IApiContentResponse Create(
        IPublishedContent content,
        string name,
        IApiContentRoute route,
        IDictionary<string, object?> properties)
    {
        var cultures = GetCultures(content);
        return new ServerVersionContentResponse(
            content.Key,
            name,
            content.ContentType.Alias,
            content.CreateDate,
            content.UpdateDate,
            route,
            properties,
            cultures,
            ServerVersion);
    }
}