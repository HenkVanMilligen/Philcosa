namespace Philcosa.Client.Infrastructure.Routes
{
    public static class CoversEndpoints
    {
        public static string GetAllPaged(int pageNumber, int pageSize, string searchString)
        {
            return $"api/v1/covers?pageNumber={pageNumber}&pageSize={pageSize}&searchString={searchString}";
        }

        public static string GetCount = "api/v1/covers/count";

        public static string GetCoverImage(int coverId)
        {
            return $"api/v1/covers/image/{coverId}";
        }

        public static string Save = "api/v1/covers";
        public static string Delete = "api/v1/covers";
        public static string Export = "api/v1/covers/export";
        public static string ChangePassword = "api/identity/account/changepassword";
        public static string UpdateProfile = "api/identity/account/updateprofile";
    }
}