namespace Library.Constants
{
    public class ValidationConstants
    {
        public static class BookConstants
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AuthorMinLength = 5;
            public const int AuthorMaxLength = 50;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 5000;

            public const string RatingMinLength = "0.00";
            public const string RatingMaxLength = "10.00";
        }

        public static class CategoryConstants
        {
            public const int CategoryMinLength = 5;
            public const int CategoryMaxLength = 50;
        }

        public static class PersonUser
        {
            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 20;

            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PasswordMaxLength = 5;
            public const int PasswordMinLength = 20;
        }
    }
}
