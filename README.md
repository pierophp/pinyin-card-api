## Commands

dotnet new tool-manifest

dotnet tool install --local dotnet-ef --version 7.0.0

dotnet dotnet-ef migrations add MigrationName

dotnet dotnet-ef database update

dotnet build

dotnet add package Microsoft.AspNetCore.Hosting.Abstractions --version 2.2.0

# Produção

dotnet publish
rm bin/Debug/net/publish/appsettings.json
cp appsettings.Production.json bin/Debug/net/publish/appsettings.json
zip -r dist.zip bin/Debug/net/publish
scp dist.zip pinyin:~

```
ssh pinyin
rm -Rf bin
unzip dist.zip
rm -Rf /var/www/pinyin-card-api/*
cp -R bin/Debug/net/publish/* /var/www/pinyin-card-api/
sudo supervisorctl restart pinyin-card-api
```

## References

https://code-maze.com/csharp-back-to-basics/

https://code-maze.com/net-core-series/

https://code-maze.com/entity-framework-core-series/

https://code-maze.com/async-generic-repository-pattern/

https://code-maze.com/getting-started-with-efcore

https://www.thereformedprogrammer.net/is-the-repository-pattern-useful-with-entity-framework-core/


JSON field nativo
https://devblogs.microsoft.com/dotnet/announcing-ef7-release-candidate-2/