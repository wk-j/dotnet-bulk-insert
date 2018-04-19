#addin "wk.StartProcess"

using PS = StartProcess.Processor;

Task("Insert-1K").Does(() => {
    PS.StartProcess("dotnet build src/BulkInsert");
    PS.StartProcess("time dotnet run --project src/BulkInsert 1000");
});

Task("Insert-10K").Does(() => {
    PS.StartProcess("dotnet build src/BulkInsert");
    PS.StartProcess("time dotnet run --project src/BulkInsert 10000");
});

Task("Insert-100K").Does(() => {
    PS.StartProcess("dotnet build src/BulkInsert");
    PS.StartProcess("time dotnet run --project src/BulkInsert 100000");
});

var target = Argument("target", "Insert-1K");
RunTarget(target);
