### CREATE NEW CONSOLE
```
dotnet new console
```

### RESTORE PROJECT (TO UPDATE WITH SOME NEW THINGS THAT YOU'VE MIGHT ADDED)
```
dotnet restore
```

### BUILD YOUR APP
```
dotnet build
```

### EXECUTE YOUR APP
```
dotnet run
```

### EXECUTE YOUR APP WITHOUT USING THE LAUGHTSETTINGS.JSON FILE (SO IT WILL CHECK ON YOUR ENVIRONMENT VARIABLE XD)
```
dotnet run --no-launch-profile
```

### EXECUTE AND WATCH NEW UPDATES ON YOUR APP TO UPDATE IT ON RUN TIME
```
dotnet watch run
```

### CREATE NEW MVC APP
```
dotnet new mvc
```

### CREATE NEW MVC APP WITH IDENTITY
```
dotnet new mvc --auth Individual --use-local-db true
```

### DOWNLOAD A NUGET PACKAGE
```
dotnet add package "Microsoft.AspNetCore"
```

### CREATE A NEW VERSION OF MIGRATIONS
```
dotnet ef migrations add "NomeDaVersao"
```

### EXECUTE THE MIGRATIONS ON YOUR DATABASE
```
dotnet ef database update
```

### DOWNGRADE YOUR DATABASE TO SOME OTHER VERSION
```
dotnet ef database update "novamigracao"
```

### DELETE THE MIGRATIONS FROM YOUR CODE ´´THAT WERE NOT UPDATE ON YOUR DATABASE``
```
dotnet ef migrations remove
```
