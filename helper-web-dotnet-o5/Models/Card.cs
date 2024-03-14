using Newtonsoft.Json;

namespace helper_web_dotnet_o5.Models
{

    public class ListCard
    {
        [JsonProperty("data")]
        public List<Card>? Data { get; set; }
    }

    public class Card
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("frameType")]
        public string FrameType { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("atk")]
        public long Atk { get; set; }

        [JsonProperty("def")]
        public long Def { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("race")]
        public string Race { get; set; }

        [JsonProperty("attribute")]
        public string Attribute { get; set; }

        [JsonProperty("archetype")]
        public string Archetype { get; set; }

        [JsonProperty("ygoprodeckUrl")]
        public Uri YgoprodeckUrl { get; set; }

        [JsonProperty("cardSets")]
        public List<CardSet> CardSets { get; set; }

        [JsonProperty("cardImages")]
        public List<CardImage> CardImages { get; set; }

        [JsonProperty("cardPrices")]
        public List<CardPrice> CardPrices { get; set; }
    }

    public partial class CardImage
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("imageUrlSmall")]
        public Uri ImageUrlSmall { get; set; }

        [JsonProperty("imageUrlCropped")]
        public Uri ImageUrlCropped { get; set; }
    }

    public partial class CardPrice
    {
        [JsonProperty("cardmarketPrice")]
        public string CardmarketPrice { get; set; }

        [JsonProperty("tcgplayerPrice")]
        public string TcgplayerPrice { get; set; }

        [JsonProperty("ebayPrice")]
        public string EbayPrice { get; set; }

        [JsonProperty("amazonPrice")]
        public string AmazonPrice { get; set; }

        [JsonProperty("coolstuffincprice")]
        public string CoolstuffincPrice { get; set; }
    }

    public partial class CardSet
    {
        [JsonProperty("set_name")]
        public string SetName { get; set; }

        [JsonProperty("set_code")]
        public string SetCode { get; set; }

        [JsonProperty("set_rarity")]
        public string SetRarity { get; set; }

        [JsonProperty("set_rarity_code")]
        public string SetRarityCode { get; set; }

        [JsonProperty("set_price")]
        public string SetPrice { get; set; }
    }
}
