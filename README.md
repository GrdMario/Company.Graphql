docker exec -it postgres-4k3J psql -U postgres

dotnet ef migrations add InitialMigration -- MssqlAdapterSettings:Url 2379b351-19bd-42fd-87be-806dfd300b60 C:\Users\Mario\source\tutorials\Company.Graphql\src\Company.Graphql

dotnet ef database update -- MssqlAdapterSettings:Url 2379b351-19bd-42fd-87be-806dfd300b60 C:\Users\Mario\source\tutorials\Company.Graphql\src\Company.Graphql

dotnet ef migrations add InitialMigration -- PostgresAdapterSettings:Url 2379b351-19bd-42fd-87be-806dfd300b60 C:\Users\Mario\source\tutorials\Company.Graphql\src\Company.Graphql

dotnet ef database update -- PostgresAdapterSettings:Url 2379b351-19bd-42fd-87be-806dfd300b60 C:\Users\Mario\source\tutorials\Company.Graphql\src\Company.Graphql





