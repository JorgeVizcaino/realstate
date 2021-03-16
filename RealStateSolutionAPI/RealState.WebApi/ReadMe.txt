//Ejecutar migarciones 
dotnet ef database update --project RealState.Infrastructure --context ApplicationDbContext -s RealState.WebApi

//Remove migrations

dotnet ef migrations remove --project RealState.Infrastructure --context ApplicationDbContext -s RealState.WebApi

//Add Migrations

dotnet ef migrations add PopulateData --project RealState.Infrastructure --context ApplicationDbContext -s RealState.WebApi
