using ChEngine.Assessment.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ChEngine.Assessment.Console;

public class BusinessLogic
{
    private readonly IAssessmentService? _assessmentService;

    public BusinessLogic(IServiceProvider serviceProvider)
    {
        _assessmentService = serviceProvider.GetService<IAssessmentService>();
    }

    public async Task Run()
    {
        var result = await _assessmentService.DoBusinessLogic();

        if (result.IsGetSoldProductsSuccess)
        {
            foreach (var product in result.SoldProducts)
            {
                System.Console.WriteLine(product.ToString());
            }

            System.Console.WriteLine();

            if (result.IsSetStockSuccess)
            {
                System.Console.WriteLine(result.SetStockMessage);

                return;
            }
        }

        System.Console.WriteLine(result.ErrorMessage);
    }
}
