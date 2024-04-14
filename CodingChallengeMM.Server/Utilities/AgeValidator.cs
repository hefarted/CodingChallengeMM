namespace CodingChallengeMM.Server.Utilities
{
    public static class AgeValidator
    {
        public static bool IsEighteenYearsOld(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}
