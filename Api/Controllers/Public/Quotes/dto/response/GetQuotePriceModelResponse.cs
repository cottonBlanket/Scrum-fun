using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Api.Controllers.Public.Quotes.dto.response;

public class GetQuotePriceModelResponse
{
    [Required] 
    [JsonProperty("ListQuotes")] 
    public string quotesPiece { get; init; }

    public GetQuotePriceModelResponse(string quotesPiece)
    {
        this.quotesPiece = quotesPiece;
    }
}