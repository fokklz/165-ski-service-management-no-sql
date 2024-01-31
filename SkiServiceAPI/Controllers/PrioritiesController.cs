using SkiServiceAPI.Common;
using SkiServiceModels.DTOs.Requests;
using SkiServiceModels.DTOs.Responses;
using SkiServiceModels.Models.BSON;

namespace SkiServiceAPI.Controllers
{
    public class PrioritiesController : GenericController<Priority, PriorityResponse, PriorityResponseAdmin, UpdatePriorityRequest, CreatePriorityRequest>
    {
        public PrioritiesController(GenericService<Priority, PriorityResponse, PriorityResponseAdmin, UpdatePriorityRequest, CreatePriorityRequest> service) : base(service)
        {
        }
    }
}
