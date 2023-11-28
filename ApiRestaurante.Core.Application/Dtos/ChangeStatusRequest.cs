
using System.Text.Json.Serialization;

namespace ApiRestaurante.Core.Application.Dtos
{
    public class ChangeStatusRequest
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int StatusId { get; set; }

    }
}
