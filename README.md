## Commands

dotnet tool install --global dotnet-ef --version 3.0.0

dotnet-ef migrations add MigrationName

dotnet-ef database update

dotnet build

dotnet add package Microsoft.AspNetCore.Hosting.Abstractions --version 2.2.0

# Produ;áo

dotnet publish

zip -r dist.zip bin/Debug/netcoreapp3.0/publish

scp dist.zip pinyin:~

## References

https://code-maze.com/csharp-back-to-basics/

https://code-maze.com/net-core-series/

https://code-maze.com/entity-framework-core-series/

https://code-maze.com/async-generic-repository-pattern/

https://code-maze.com/getting-started-with-efcore

https://www.thereformedprogrammer.net/is-the-repository-pattern-useful-with-entity-framework-core/
