namespace MtxApp.WebApi.Controllers;

public static class MediaMtxController
{
    public static void MapMediaMtxEndpoints(this IEndpointRouteBuilder app)
    {
        // Returns all RTMP connections
        app.MapGet("/v3/rtmpconns/list",
                async (IHttpClientFactory httpClientFactory) =>
                {
                    var client = httpClientFactory.CreateClient("mediamtx");
                    var response = await client.GetAsync("/v3/rtmpconns/list");

                    if (!response.IsSuccessStatusCode)
                    {
                        return Results.Problem("Failed to retrieve data from MediaMTX");
                    }

                    var json = await response.Content.ReadAsStringAsync();

                    return Results.Content(json, "application/json");
                })
            .WithName("GetRtmpConnections")
            .WithDescription("Returns a list of all active RTMP connections")
            .WithTags("RTMP");

        // Returns a single RTMP connection by id
        app.MapGet("/v3/rtmpconns/get/{id}",
                async (string id, IHttpClientFactory httpClientFactory) =>
                {
                    var client = httpClientFactory.CreateClient("mediamtx");
                    var response = await client.GetAsync($"/v3/rtmpconns/get/{id}");

                    if (!response.IsSuccessStatusCode)
                    {
                        return Results.Problem($"Failed to retrieve RTMP connection with id {id}");
                    }

                    var json = await response.Content.ReadAsStringAsync();

                    return Results.Content(json, "application/json");
                })
            .WithName("GetRtmpConnectionById")
            .WithDescription("Returns details of a single RTMP connection")
            .WithTags("RTMP");

        // Kicks (disconnects) a specific RTMP connection
        app.MapPost("/v3/rtmpconns/kick/{id}",
                async (string id, IHttpClientFactory httpClientFactory) =>
                {
                    var client = httpClientFactory.CreateClient("mediamtx");
                    var response = await client.PostAsync($"/v3/rtmpconns/kick/{id}", content: null);

                    if (!response.IsSuccessStatusCode)
                    {
                        return Results.Problem($"Failed to kick RTMP connection with id {id}");
                    }

                    return Results.Ok(new { message = $"RTMP connection {id} has been kicked" });
                })
            .WithName("KickRtmpConnection")
            .WithDescription("Disconnects a single RTMP connection by id")
            .WithTags("RTMP");
    }
}
