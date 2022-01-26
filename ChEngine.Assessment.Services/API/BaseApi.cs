using RestSharp;

namespace ChEngine.Assessment.Services.API;

public abstract class BaseApi
{
    private const string API_URL = "";
    private const string API_KEY = "";

    private readonly RestClient _client;

    public BaseApi()
    {
        _client = new RestClient(API_URL);
    }

    protected virtual async Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request) where T : new()
    {
        request.AddQueryParameter("apikey", API_KEY);

        return await _client.ExecuteAsync<T>(request);
    }
}