namespace ProgrammeerOpdracht.Models
{

    using System.Text.Json.Serialization;

    [JsonDerivedType(typeof(MedicationContent), "MedicationOverview")]
    [JsonDerivedType(typeof(AllergyContent), "AllergyOverview")]
    [JsonDerivedType(typeof(ReferralLetterContent), "ReferralLetter")]
    public abstract class DocumentContent
    {
    }

}
