namespace Company.Graphql.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Address { get; set; } = default!;

        public string ProfilePicture { get; set; } = default!;
    }
}
