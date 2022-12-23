namespace SoftJail.Common
{
    public static class ValidationConstants
    {
        //Prisoner
        public const int PrisonerFullNameMinLength = 3;
        public const int PrisonerFullNameMaxLength = 20;
        public const string PrisonerNicknameRegex = "^(The\\s)([A-Z]{1}[a-z]*)$";
        public const int PrisonerMinAge = 18;
        public const int PrisonerMaxAge = 65;
        public const string PrisonerMinBail = "0";
        public const string PrisonerMaxBail = "79228162514264337593543950335";

        //Officer
        public const int OfficerFullNameMinLength = 3;
        public const int OfficerFullNameMaxLength = 30;
        public const string OfficerMinSalary = "0";
        public const string OfficerMaxSalary = "79228162514264337593543950335";

        //Department
        public const int DepartmentNameMinLength = 3;
        public const int DepartmentNameMaxLength = 25;

        //Cell
        public const int CellMinRange = 1;
        public const int CellMaxRange = 1000;

        //Mail
        public const string PrisonerMailAddressRegex = "^([A-Za-z0-9\\s]+?)(str.)$";

    }
}
