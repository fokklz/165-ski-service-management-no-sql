using SkiServiceAPI.Common;
using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.DTOs.Responses;
using SkiServiceModels.BSON.Models;

namespace SkiServiceAPI.Controllers
{
    public class ServicesController : GenericController<Service, ServiceResponse, UpdateServiceRequest, CreateServiceRequest>
    {
        public ServicesController(GenericService<Service, ServiceResponse, UpdateServiceRequest, CreateServiceRequest> service) : base(service)
        {
        }
    }
}
