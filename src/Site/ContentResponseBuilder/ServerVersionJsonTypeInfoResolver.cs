using System.Text.Json.Serialization.Metadata;
using Umbraco.Cms.Api.Delivery.Json;
using Umbraco.Cms.Core.Models.DeliveryApi;

namespace Site.ContentResponseBuilder;

public class ServerVersionJsonTypeInfoResolver : DeliveryApiJsonTypeResolver
{
    protected override Type[] GetDerivedTypes(JsonTypeInfo jsonTypeInfo)
        => jsonTypeInfo.Type == typeof(IApiContentResponse)
            ? [typeof(ServerVersionContentResponse)]
            : base.GetDerivedTypes(jsonTypeInfo);
}