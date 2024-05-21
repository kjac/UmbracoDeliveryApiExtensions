using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.DeliveryApi;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Web.Common.Controllers;

namespace Site.Controllers;

/// <remarks>
/// This controller is ONLY to exemplify the use of custom APIs that conform to the Delivery API, and
/// should NOT be used as-is. Explore the Delivery API querying and filtering options before going the
/// route of custom APIs.
/// See https://docs.umbraco.com/umbraco-cms/reference/content-delivery-api for details.
/// </remarks>
public class PostsQueryController : UmbracoApiController
{
    private readonly IPublishedSnapshotAccessor _publishedSnapshotAccessor;
    private readonly IApiContentResponseBuilder _apiContentResponseBuilder;

    public PostsQueryController(
        IPublishedSnapshotAccessor publishedSnapshotAccessor,
        IApiContentResponseBuilder apiContentResponseBuilder)
    {
        _publishedSnapshotAccessor = publishedSnapshotAccessor;
        _apiContentResponseBuilder = apiContentResponseBuilder;
    }

    public IActionResult ByName(string name)
    {
        if (name.IsNullOrWhiteSpace())
        {
            return BadRequest("Please supply a name query");
        }
        
        var contentCache = _publishedSnapshotAccessor
            .GetRequiredPublishedSnapshot()
            .Content ?? throw new InvalidOperationException("Could not obtain the content cache");

        var posts = contentCache
            .GetAtRoot()
            .FirstOrDefault(c => c.ContentType.Alias == "posts");

        if (posts is null)
        {
            return NotFound("The Posts root was not found");
        }

        var matches = posts
            .Children
            .Where(post => post.Name.InvariantContains(name));
        return Ok(matches.Select(_apiContentResponseBuilder.Build).WhereNotNull());
    }
}
