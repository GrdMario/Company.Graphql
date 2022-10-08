namespace Company.Graphql.Domain
{
    public class Blog
    {
        protected Blog() { }

        public Blog(
            Guid id,
            Guid userId,
            string title,
            string description,
            List<Post> posts)
        {
            this.Id = id;
            this.UserId = userId;
            this.Title = title;
            this.Description = description;
            this.Posts = posts;
        }

        public Guid Id { get; protected set; }

        public Guid UserId { get; protected set; }

        public string Title { get; protected set; } = default!;

        public string Description { get; protected set; } = default!;

        public List<Post> Posts { get; protected set; } = new List<Post>();
    }
}
