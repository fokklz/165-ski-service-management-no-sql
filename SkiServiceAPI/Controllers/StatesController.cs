using SkiServiceAPI.Common;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.DTOs.Responses;
using SkiServiceModels.BSON.Models;

namespace SkiServiceAPI.Controllers
{
    public class StatesController : GenericController<State, StateResponse, UpdateStateRequest, CreateStateRequest>
    {
        public StatesController(GenericService<State, StateResponse, UpdateStateRequest, CreateStateRequest> service) : base(service)
        {
        }
    }
}
