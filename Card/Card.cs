﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var card = Card.FromJson(jsonString);

namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Card
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("oracle_id")]
        public Guid OracleId { get; set; }

        [JsonProperty("multiverse_ids")]
        public long[] MultiverseIds { get; set; }

        [JsonProperty("tcgplayer_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? TcgplayerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("released_at")]
        public DateTimeOffset ReleasedAt { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("scryfall_uri")]
        public Uri ScryfallUri { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

        [JsonProperty("highres_image")]
        public bool HighresImage { get; set; }

        [JsonProperty("image_uris", NullValueHandling = NullValueHandling.Ignore)]
        public ImageUris ImageUris { get; set; }

        [JsonProperty("mana_cost", NullValueHandling = NullValueHandling.Ignore)]
        public string ManaCost { get; set; }

        [JsonProperty("cmc")]
        public double Cmc { get; set; }

        [JsonProperty("type_line")]
        public string TypeLine { get; set; }

        [JsonProperty("oracle_text", NullValueHandling = NullValueHandling.Ignore)]
        public string OracleText { get; set; }

        [JsonProperty("colors", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Colors { get; set; }

        [JsonProperty("color_identity")]
        public string[] ColorIdentity { get; set; }

        [JsonProperty("legalities")]
        public Legalities Legalities { get; set; }

        [JsonProperty("games")]
        public string[] Games { get; set; }

        [JsonProperty("reserved")]
        public bool Reserved { get; set; }

        [JsonProperty("foil")]
        public bool Foil { get; set; }

        [JsonProperty("nonfoil")]
        public bool Nonfoil { get; set; }

        [JsonProperty("oversized")]
        public bool Oversized { get; set; }

        [JsonProperty("promo")]
        public bool Promo { get; set; }

        [JsonProperty("reprint")]
        public bool Reprint { get; set; }

        [JsonProperty("set")]
        public string Set { get; set; }

        [JsonProperty("set_name")]
        public string SetName { get; set; }

        [JsonProperty("set_uri")]
        public Uri SetUri { get; set; }

        [JsonProperty("set_search_uri")]
        public Uri SetSearchUri { get; set; }

        [JsonProperty("scryfall_set_uri")]
        public Uri ScryfallSetUri { get; set; }

        [JsonProperty("rulings_uri")]
        public Uri RulingsUri { get; set; }

        [JsonProperty("prints_search_uri")]
        public Uri PrintsSearchUri { get; set; }

        [JsonProperty("collector_number")]
        public string CollectorNumber { get; set; }

        [JsonProperty("digital")]
        public bool Digital { get; set; }

        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("flavor_text", NullValueHandling = NullValueHandling.Ignore)]
        public string FlavorText { get; set; }

        [JsonProperty("illustration_id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? IllustrationId { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("border_color")]
        public string BorderColor { get; set; }

        [JsonProperty("frame")]
        public string Frame { get; set; }

        [JsonProperty("frame_effect", NullValueHandling = NullValueHandling.Ignore)]
        public string FrameEffect { get; set; }

        [JsonProperty("full_art")]
        public bool FullArt { get; set; }

        [JsonProperty("story_spotlight")]
        public bool StorySpotlight { get; set; }

        [JsonProperty("edhrec_rank", NullValueHandling = NullValueHandling.Ignore)]
        public long? EdhrecRank { get; set; }

        [JsonProperty("related_uris")]
        public RelatedUris RelatedUris { get; set; }

        [JsonProperty("loyalty", NullValueHandling = NullValueHandling.Ignore)]
        public string Loyalty { get; set; }

        [JsonProperty("power", NullValueHandling = NullValueHandling.Ignore)]
        public string Power { get; set; }

        [JsonProperty("toughness", NullValueHandling = NullValueHandling.Ignore)]
        public string Toughness { get; set; }

        [JsonProperty("all_parts", NullValueHandling = NullValueHandling.Ignore)]
        public AllPart[] AllParts { get; set; }

        [JsonProperty("mtgo_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? MtgoId { get; set; }

        [JsonProperty("arena_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ArenaId { get; set; }

        [JsonProperty("watermark", NullValueHandling = NullValueHandling.Ignore)]
        public string Watermark { get; set; }

        [JsonProperty("card_faces", NullValueHandling = NullValueHandling.Ignore)]
        public CardFace[] CardFaces { get; set; }

        [JsonProperty("mtgo_foil_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? MtgoFoilId { get; set; }

        [JsonProperty("color_indicator", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ColorIndicator { get; set; }

        [JsonProperty("printed_name", NullValueHandling = NullValueHandling.Ignore)]
        public string PrintedName { get; set; }

        [JsonProperty("printed_type_line", NullValueHandling = NullValueHandling.Ignore)]
        public string PrintedTypeLine { get; set; }

        [JsonProperty("printed_text", NullValueHandling = NullValueHandling.Ignore)]
        public string PrintedText { get; set; }

        [JsonProperty("life_modifier", NullValueHandling = NullValueHandling.Ignore)]
        public string LifeModifier { get; set; }

        [JsonProperty("hand_modifier", NullValueHandling = NullValueHandling.Ignore)]
        public string HandModifier { get; set; }
    }

    public partial class AllPart
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("component")]
        public string Component { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type_line")]
        public string TypeLine { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }
    }

    public partial class CardFace
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mana_cost")]
        public string ManaCost { get; set; }

        [JsonProperty("type_line")]
        public string TypeLine { get; set; }

        [JsonProperty("oracle_text")]
        public string OracleText { get; set; }

        [JsonProperty("watermark", NullValueHandling = NullValueHandling.Ignore)]
        public string Watermark { get; set; }

        [JsonProperty("artist", NullValueHandling = NullValueHandling.Ignore)]
        public string Artist { get; set; }

        [JsonProperty("illustration_id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? IllustrationId { get; set; }

        [JsonProperty("colors", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Colors { get; set; }

        [JsonProperty("power", NullValueHandling = NullValueHandling.Ignore)]
        public string Power { get; set; }

        [JsonProperty("toughness", NullValueHandling = NullValueHandling.Ignore)]
        public string Toughness { get; set; }

        [JsonProperty("image_uris", NullValueHandling = NullValueHandling.Ignore)]
        public ImageUris ImageUris { get; set; }

        [JsonProperty("color_indicator", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ColorIndicator { get; set; }

        [JsonProperty("loyalty", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Loyalty { get; set; }

        [JsonProperty("flavor_text", NullValueHandling = NullValueHandling.Ignore)]
        public string FlavorText { get; set; }

        [JsonProperty("printed_name", NullValueHandling = NullValueHandling.Ignore)]
        public string PrintedName { get; set; }
    }

    public partial class ImageUris
    {
        [JsonProperty("small")]
        public Uri Small { get; set; }

        [JsonProperty("normal")]
        public Uri Normal { get; set; }

        [JsonProperty("large")]
        public Uri Large { get; set; }

        [JsonProperty("png")]
        public Uri Png { get; set; }

        [JsonProperty("art_crop")]
        public Uri ArtCrop { get; set; }

        [JsonProperty("border_crop")]
        public Uri BorderCrop { get; set; }
    }

    public partial class Legalities
    {
        [JsonProperty("standard")]
        public string Standard { get; set; }

        [JsonProperty("future")]
        public string Future { get; set; }

        [JsonProperty("frontier")]
        public string Frontier { get; set; }

        [JsonProperty("modern")]
        public string Modern { get; set; }

        [JsonProperty("legacy")]
        public string Legacy { get; set; }

        [JsonProperty("pauper")]
        public string Pauper { get; set; }

        [JsonProperty("vintage")]
        public string Vintage { get; set; }

        [JsonProperty("penny")]
        public string Penny { get; set; }

        [JsonProperty("commander")]
        public string Commander { get; set; }

        [JsonProperty("duel")]
        public string Duel { get; set; }

        [JsonProperty("oldschool")]
        public string Oldschool { get; set; }
    }

    public partial class RelatedUris
    {
        [JsonProperty("tcgplayer_decks")]
        public Uri TcgplayerDecks { get; set; }

        [JsonProperty("edhrec")]
        public Uri Edhrec { get; set; }

        [JsonProperty("mtgtop8")]
        public Uri Mtgtop8 { get; set; }

        [JsonProperty("gatherer", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Gatherer { get; set; }
    }

    public partial class Card
    {
        public static Card[] FromJson(string json) => JsonConvert.DeserializeObject<Card[]>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Card[] self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
