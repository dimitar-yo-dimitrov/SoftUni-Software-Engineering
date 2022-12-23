namespace Watchlist.Constants
{
    public static class ValidationConstants
    {
        public static class MovieConstants
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int DirectorMinLength = 5;
            public const int DirectorMaxLength = 50;

            public const string RatingMinLength = "0.00";
            public const string RatingMaxLength = "10.00";
        }

        public static class GenreConstants
        {
            public const int GenreMinLength = 5;
            public const int GenreMaxLength = 50;
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
