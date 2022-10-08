namespace Company.Graphql
{
    using Company.Graphql.Blocks.Bootstrap;

    public static class Program
    {
        public static async Task Main(string[] args) => await ApplicationLauncher.RunAsync<Startup>(args);
    }
}
