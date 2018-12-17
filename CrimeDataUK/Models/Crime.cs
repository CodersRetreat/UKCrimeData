using System;
namespace CrimeDataUK.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Crime
    {
        [JsonProperty("category")]
        public CrimeCategory Category { get; set; }

        [JsonProperty("location_type")]
        public LocationType LocationType { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("outcome_status")]
        public OutcomeStatus OutcomeStatus { get; set; }

        [JsonProperty("persistent_id")]
        public string PersistentId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("location_subtype")]
        public LocationSubtype LocationSubtype { get; set; }

        [JsonProperty("month")]
        public Month Month { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("street")]
        public Street Street { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }

    public partial class Street
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class OutcomeStatus
    {
        [JsonProperty("category")]
        public OutcomeStatusCategory Category { get; set; }

        [JsonProperty("date")]
        public Month Date { get; set; }
    }

    public enum CrimeCategory { AntiSocialBehaviour, BicycleTheft, Burglary, CriminalDamageArson, Drugs, OtherCrime, OtherTheft, PossessionOfWeapons, PublicOrder, Robbery, Shoplifting, TheftFromThePerson, VehicleCrime, ViolentCrime };

    public enum LocationSubtype { Empty, Station };

    public enum LocationType { Btp, Force };

    public enum Month { The201810 };

    public enum OutcomeStatusCategory { ActionToBeTakenByAnotherOrganisation, AwaitingCourtOutcome, CourtCaseUnableToProceed, FormalActionIsNotInThePublicInterest, FurtherInvestigationIsNotInThePublicInterest, InvestigationCompleteNoSuspectIdentified, LocalResolution, OffenderFined, OffenderGivenACaution, OffenderGivenADrugsPossessionWarning, OffenderGivenCommunitySentence, OffenderGivenConditionalDischarge, OffenderGivenPenaltyNotice, OffenderSentToPrison, UnableToProsecuteSuspect, UnderInvestigation };

    public partial class Crime
    {
        public static List<Crime> FromJson(string json) => JsonConvert.DeserializeObject<List<Crime>>(json, CrimeDataUK.Models.CrimeConverter.Settings);
    }

    //public static class Serialize
    //{
    //    public static string ToJson(this List<Crime> self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    //}

    internal static class CrimeConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CrimeCategoryConverter.Singleton,
                LocationSubtypeConverter.Singleton,
                LocationTypeConverter.Singleton,
                MonthConverter.Singleton,
                OutcomeStatusCategoryConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CrimeCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CrimeCategory) || t == typeof(CrimeCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "anti-social-behaviour":
                    return CrimeCategory.AntiSocialBehaviour;
                case "bicycle-theft":
                    return CrimeCategory.BicycleTheft;
                case "burglary":
                    return CrimeCategory.Burglary;
                case "criminal-damage-arson":
                    return CrimeCategory.CriminalDamageArson;
                case "drugs":
                    return CrimeCategory.Drugs;
                case "other-crime":
                    return CrimeCategory.OtherCrime;
                case "other-theft":
                    return CrimeCategory.OtherTheft;
                case "possession-of-weapons":
                    return CrimeCategory.PossessionOfWeapons;
                case "public-order":
                    return CrimeCategory.PublicOrder;
                case "robbery":
                    return CrimeCategory.Robbery;
                case "shoplifting":
                    return CrimeCategory.Shoplifting;
                case "theft-from-the-person":
                    return CrimeCategory.TheftFromThePerson;
                case "vehicle-crime":
                    return CrimeCategory.VehicleCrime;
                case "violent-crime":
                    return CrimeCategory.ViolentCrime;
            }
            throw new Exception("Cannot unmarshal type CrimeCategory");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CrimeCategory)untypedValue;
            switch (value)
            {
                case CrimeCategory.AntiSocialBehaviour:
                    serializer.Serialize(writer, "anti-social-behaviour");
                    return;
                case CrimeCategory.BicycleTheft:
                    serializer.Serialize(writer, "bicycle-theft");
                    return;
                case CrimeCategory.Burglary:
                    serializer.Serialize(writer, "burglary");
                    return;
                case CrimeCategory.CriminalDamageArson:
                    serializer.Serialize(writer, "criminal-damage-arson");
                    return;
                case CrimeCategory.Drugs:
                    serializer.Serialize(writer, "drugs");
                    return;
                case CrimeCategory.OtherCrime:
                    serializer.Serialize(writer, "other-crime");
                    return;
                case CrimeCategory.OtherTheft:
                    serializer.Serialize(writer, "other-theft");
                    return;
                case CrimeCategory.PossessionOfWeapons:
                    serializer.Serialize(writer, "possession-of-weapons");
                    return;
                case CrimeCategory.PublicOrder:
                    serializer.Serialize(writer, "public-order");
                    return;
                case CrimeCategory.Robbery:
                    serializer.Serialize(writer, "robbery");
                    return;
                case CrimeCategory.Shoplifting:
                    serializer.Serialize(writer, "shoplifting");
                    return;
                case CrimeCategory.TheftFromThePerson:
                    serializer.Serialize(writer, "theft-from-the-person");
                    return;
                case CrimeCategory.VehicleCrime:
                    serializer.Serialize(writer, "vehicle-crime");
                    return;
                case CrimeCategory.ViolentCrime:
                    serializer.Serialize(writer, "violent-crime");
                    return;
            }
            throw new Exception("Cannot marshal type CrimeCategory");
        }

        public static readonly CrimeCategoryConverter Singleton = new CrimeCategoryConverter();
    }

    internal class LocationSubtypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LocationSubtype) || t == typeof(LocationSubtype?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return LocationSubtype.Empty;
                case "STATION":
                    return LocationSubtype.Station;
            }
            throw new Exception("Cannot unmarshal type LocationSubtype");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LocationSubtype)untypedValue;
            switch (value)
            {
                case LocationSubtype.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case LocationSubtype.Station:
                    serializer.Serialize(writer, "STATION");
                    return;
            }
            throw new Exception("Cannot marshal type LocationSubtype");
        }

        public static readonly LocationSubtypeConverter Singleton = new LocationSubtypeConverter();
    }

    internal class LocationTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LocationType) || t == typeof(LocationType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BTP":
                    return LocationType.Btp;
                case "Force":
                    return LocationType.Force;
            }
            throw new Exception("Cannot unmarshal type LocationType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LocationType)untypedValue;
            switch (value)
            {
                case LocationType.Btp:
                    serializer.Serialize(writer, "BTP");
                    return;
                case LocationType.Force:
                    serializer.Serialize(writer, "Force");
                    return;
            }
            throw new Exception("Cannot marshal type LocationType");
        }

        public static readonly LocationTypeConverter Singleton = new LocationTypeConverter();
    }

    internal class MonthConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Month) || t == typeof(Month?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "2018-10")
            {
                return Month.The201810;
            }
            throw new Exception("Cannot unmarshal type Month");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Month)untypedValue;
            if (value == Month.The201810)
            {
                serializer.Serialize(writer, "2018-10");
                return;
            }
            throw new Exception("Cannot marshal type Month");
        }

        public static readonly MonthConverter Singleton = new MonthConverter();
    }

    internal class OutcomeStatusCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OutcomeStatusCategory) || t == typeof(OutcomeStatusCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Action to be taken by another organisation":
                    return OutcomeStatusCategory.ActionToBeTakenByAnotherOrganisation;
                case "Awaiting court outcome":
                    return OutcomeStatusCategory.AwaitingCourtOutcome;
                case "Court case unable to proceed":
                    return OutcomeStatusCategory.CourtCaseUnableToProceed;
                case "Formal action is not in the public interest":
                    return OutcomeStatusCategory.FormalActionIsNotInThePublicInterest;
                case "Further investigation is not in the public interest":
                    return OutcomeStatusCategory.FurtherInvestigationIsNotInThePublicInterest;
                case "Investigation complete; no suspect identified":
                    return OutcomeStatusCategory.InvestigationCompleteNoSuspectIdentified;
                case "Local resolution":
                    return OutcomeStatusCategory.LocalResolution;
                case "Offender fined":
                    return OutcomeStatusCategory.OffenderFined;
                case "Offender given a caution":
                    return OutcomeStatusCategory.OffenderGivenACaution;
                case "Offender given a drugs possession warning":
                    return OutcomeStatusCategory.OffenderGivenADrugsPossessionWarning;
                case "Offender given community sentence":
                    return OutcomeStatusCategory.OffenderGivenCommunitySentence;
                case "Offender given conditional discharge":
                    return OutcomeStatusCategory.OffenderGivenConditionalDischarge;
                case "Offender given penalty notice":
                    return OutcomeStatusCategory.OffenderGivenPenaltyNotice;
                case "Offender sent to prison":
                    return OutcomeStatusCategory.OffenderSentToPrison;
                case "Unable to prosecute suspect":
                    return OutcomeStatusCategory.UnableToProsecuteSuspect;
                case "Under investigation":
                    return OutcomeStatusCategory.UnderInvestigation;
            }
            throw new Exception("Cannot unmarshal type OutcomeStatusCategory");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OutcomeStatusCategory)untypedValue;
            switch (value)
            {
                case OutcomeStatusCategory.ActionToBeTakenByAnotherOrganisation:
                    serializer.Serialize(writer, "Action to be taken by another organisation");
                    return;
                case OutcomeStatusCategory.AwaitingCourtOutcome:
                    serializer.Serialize(writer, "Awaiting court outcome");
                    return;
                case OutcomeStatusCategory.CourtCaseUnableToProceed:
                    serializer.Serialize(writer, "Court case unable to proceed");
                    return;
                case OutcomeStatusCategory.FormalActionIsNotInThePublicInterest:
                    serializer.Serialize(writer, "Formal action is not in the public interest");
                    return;
                case OutcomeStatusCategory.FurtherInvestigationIsNotInThePublicInterest:
                    serializer.Serialize(writer, "Further investigation is not in the public interest");
                    return;
                case OutcomeStatusCategory.InvestigationCompleteNoSuspectIdentified:
                    serializer.Serialize(writer, "Investigation complete; no suspect identified");
                    return;
                case OutcomeStatusCategory.LocalResolution:
                    serializer.Serialize(writer, "Local resolution");
                    return;
                case OutcomeStatusCategory.OffenderFined:
                    serializer.Serialize(writer, "Offender fined");
                    return;
                case OutcomeStatusCategory.OffenderGivenACaution:
                    serializer.Serialize(writer, "Offender given a caution");
                    return;
                case OutcomeStatusCategory.OffenderGivenADrugsPossessionWarning:
                    serializer.Serialize(writer, "Offender given a drugs possession warning");
                    return;
                case OutcomeStatusCategory.OffenderGivenCommunitySentence:
                    serializer.Serialize(writer, "Offender given community sentence");
                    return;
                case OutcomeStatusCategory.OffenderGivenConditionalDischarge:
                    serializer.Serialize(writer, "Offender given conditional discharge");
                    return;
                case OutcomeStatusCategory.OffenderGivenPenaltyNotice:
                    serializer.Serialize(writer, "Offender given penalty notice");
                    return;
                case OutcomeStatusCategory.OffenderSentToPrison:
                    serializer.Serialize(writer, "Offender sent to prison");
                    return;
                case OutcomeStatusCategory.UnableToProsecuteSuspect:
                    serializer.Serialize(writer, "Unable to prosecute suspect");
                    return;
                case OutcomeStatusCategory.UnderInvestigation:
                    serializer.Serialize(writer, "Under investigation");
                    return;
            }
            throw new Exception("Cannot marshal type OutcomeStatusCategory");
        }

        public static readonly OutcomeStatusCategoryConverter Singleton = new OutcomeStatusCategoryConverter();
    }
}