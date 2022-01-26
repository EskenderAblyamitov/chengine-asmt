using ChEngine.Assessment.Services.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace ChEngine.Assessment.Services.API;

public abstract class BaseApi
{
    private readonly RestClient _client;
    private readonly string? _apiKey;

    public BaseApi(IConfiguration configuration)
    {
        var apiSettings = new ApiSettings();
        configuration.GetSection("ApiSetings").Bind(apiSettings);
        _apiKey = apiSettings.ApiKey;

        _client = new RestClient(apiSettings.BaseUrl);
    }

    protected virtual async Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request) where T : new()
    {
        request.AddQueryParameter("apikey", _apiKey);

        return await _client.ExecuteAsync<T>(request);
    }
}