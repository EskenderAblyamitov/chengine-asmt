using System.Net;
using RestSharp;
using ChEngine.Assessment.Services.Contracts;
using ChEngine.Assessment.Services.Models;

namespace ChEngine.Assessment.Services.API;

public class OrdersApi : BaseApi, IOrdersApi
{
    private const string ORDERS_BY_FILTER_URL = "/v2/orders";

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