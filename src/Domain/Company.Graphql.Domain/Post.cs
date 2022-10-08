namespace Company.Graphql.Domain
{
    public class Post
    {
        public Post() { }

        public Post(
            Guid id,
            Guid blogId,
            string title,
            string slug,
            string url,
            string description,
            string content)
        {
            this.Id = id;
            this.BlogId = blogId;
            this.Title = title;
            this.Slug = slug;
            this.Url = url;
            this.Description = description;
            this.Content = content;
        }

        public Guid Id { get; protected set; }

        public Guid BlogId { get; protected set; }

        public string Title { get; protected set; } = default!;

        public string Slug { get; protected set; } = default!;

        public string Url { get; protected set; } = default!;

        public string Description { get; protected set; } = default!;

        public string Content { get; protected set; } = default!;
    }
}
