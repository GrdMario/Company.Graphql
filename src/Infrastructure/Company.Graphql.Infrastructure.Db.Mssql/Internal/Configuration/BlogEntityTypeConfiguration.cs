namespace Company.Graphql.Infrastructure.Db.Mssql.Internal.Configuration
{
    using Company.Graphql.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal sealed class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder
                .ToTable("Blogs");

            builder
                .HasKey(key => key.Id);

            builder
                .Property(p => p.UserId)
                .IsRequired();

            builder
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);
            
            builder
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder
                .HasMany(p => p.Posts)
                .WithOne()
                .HasForeignKey(fk => fk.BlogId);
        }
    }
}
