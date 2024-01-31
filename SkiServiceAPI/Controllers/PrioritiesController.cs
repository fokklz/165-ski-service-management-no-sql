using SkiServiceAPI.Common;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.DTOs.Responses;
using SkiServiceModels.BSON.Models;

namespace SkiServiceAPI.Controllers
{
    public class PrioritiesController : GenericController<Priority, PriorityResponse, UpdatePriorityRequest, CreatePriorityRequest>
    {
        public PrioritiesController(GenericService<Priority, PriorityResponse, UpdatePriorityRequest, CreatePriorityRequest> service) : base(service)
        {
        }
    }
}
