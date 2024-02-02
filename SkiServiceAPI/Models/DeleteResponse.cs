using MongoDB.Bson;
using System.Diagnostics.CodeAnalysis;

namespace SkiServiceAPI.Models
{
    public class DeleteResponse
    {
        [AllowNull, NotNull]
        public string Id { get; set; }
    }
}
