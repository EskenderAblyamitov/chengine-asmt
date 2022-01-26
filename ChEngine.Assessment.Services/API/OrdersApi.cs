using System.Net;
using RestSharp;
using ChEngine.Assessment.Services.Contracts;
using ChEngine.Assessment.Services.Models;
using Microsoft.Extensions.Configuration;

namespace ChEngine.Assessment.Services.API;

/// <inheritdoc />
public class OrdersApi : BaseApi, IOrdersApi
{
    private const string ORDERS_BY_FILTER_URL = "/v2/orders";

    public OrdersApi(IConfiguration configuration) : base(configuration)
    {
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
    {
        var request = new RestRequest(ORDERS_BY_FILTER_URL, Method.Get);

        var result = await base.ExecuteAsync<ApiResponse<IEnumerable<Order>>>(request);

        if (result.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception($"Unable to fetch data from '{ORDERS_BY_FILTER_URL}'. Error code: {result.StatusCode}. Error msg: {result.ErrorMessage}");
        }

        return result.Data.Content;
    }
}