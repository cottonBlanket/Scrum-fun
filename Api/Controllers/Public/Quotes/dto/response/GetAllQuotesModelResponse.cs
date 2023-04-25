using System.ComponentModel.DataAnnotations;
using Dal.Group;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Quotes.dto.response;

public class GetAllQuotesModelResponse
{
    [Required] 
    [JsonProperty("ListQuotes")] 
    public List<string> ListQuotes { get; init; }

    public GetAllQuotesModelResponse(List<string> listQuotes)
    {
        ListQuotes = listQuotes;
    }
}