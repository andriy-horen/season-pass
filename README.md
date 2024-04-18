# Season Pass
Track you ski/snb season progression

### Commands

```console
# create migration
dotnet ef migrations add <migration-name> --project .\src\Modules\SeasonPass.Module.Postgres\ --startup-project .\src\SeasonPass.Api\

# update the db
dotnet ef database update --project .\src\Modules\SeasonPass.Module.Postgres\ --startup-project .\src\SeasonPass.Api\
```
