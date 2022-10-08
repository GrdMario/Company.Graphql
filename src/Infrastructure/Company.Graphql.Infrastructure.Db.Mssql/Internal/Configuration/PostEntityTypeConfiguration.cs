namespace Company.Graphql.Infrastructure.Db.Mssql.Internal.Configuration
{
    using Company.Graphql.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal sealed class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .ToTable("Posts");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(p => p.Title)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .Property(p => p.Url)
                .IsRequired();

            builder
                .Property(p => p.Slug)
                .IsRequired();

            builder
                .Property(p => p.Content)
                .IsRequired();
        }
    }
}
