using ChEngine.Assessment.Services.DTO;

namespace ChEngine.Assessment.Services.Contracts
{
    public interface IAssessmentService
    {
        Task<BusinessLogicResultDto> DoBusinessLogic();
    }
}
