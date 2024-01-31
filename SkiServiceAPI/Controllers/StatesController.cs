using SkiServiceAPI.Common;
using SkiServiceModels.DTOs.Requests;
using SkiServiceModels.DTOs.Responses;
using SkiServiceModels.Models.BSON;

namespace SkiServiceAPI.Controllers
{
    public class StatesController : GenericController<State, StateResponse, StateResponseAdmin, UpdateStateRequest, CreateStateRequest>
    {
        public StatesController(GenericService<State, StateResponse, StateResponseAdmin, UpdateStateRequest, CreateStateRequest> service) : base(service)
        {
        }
    }
}
