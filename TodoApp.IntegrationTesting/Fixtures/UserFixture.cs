

using MongoDB.Driver;

namespace TodoApp.IntegrationTesting.Fixtures
{
    public static class UserFixture
    {
        public static User GetUser() =>
            new()
            {
                CreatedDateTime = DateTime.Now,
                FirstName = "FirstName",
                LastName = "LastName",
                Role = "User"

            };
        public static User UserWithBadRequest() =>
            new()
            {
                CreatedDateTime = DateTime.Now,
                FirstName = "",
                LastName = "LastName",
                Role = "User"

            };
        public static String UserInvalidId() => "fghjhbj";
        public static String UservalidId() => "5ebd7246d2b0d6003887a8f4";
            
    }
}
