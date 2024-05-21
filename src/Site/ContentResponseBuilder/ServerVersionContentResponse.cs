using Umbraco.Cms.Core.Models.DeliveryApi;

namespace Site.ContentResponseBuilder;

public class ServerVersionContentResponse : ApiContentResponse
{
    public ServerVersionContentResponse(
        Guid id,
        string name,
        string contentType,
        DateTime createDate,
        DateTime updateDate,
        IApiContentRoute route,
        IDictionary<string, object?> properties,
        IDictionary<string, IApiContentRoute> cultures,
        Version serverVersion)
        : base(id, name, contentType, createDate, updateDate, route, properties, cultures)
        => ServerVersion = serverVersion;

    public Version ServerVersion { get; set; }
}