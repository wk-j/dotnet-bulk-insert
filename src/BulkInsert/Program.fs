open System
open BulkInsert.Model
open BulkInsert.Context
// open EFCore.BulkExtensions
open System.Collections.Generic

let generateModel count =
    seq {
        for _ in 1 .. count do
            yield
                { QFile.Id = 0
                  EcmName = "2345678923456789.pdf"
                  EcmPath = "/A1/A2/A3/A4/A5/A6"
                  Status = FileStatus.Import
                  ImportDate = DateTime.Now
                  Message = ""
                  EcmUuid = "2345678902345678945678904567"
                  GRequestNumber = "34567895678906789"
                  GTciNo = "789678967890"
                  GTciNoDateStamp = DateTime.Now
                  GRequestStatus = "D"
                  GFileName = "789678906789056789.pdf"
                  GOriginalFileName = "6789678906789.pdf"
                  GAttachedDate = DateTime.Now
                  UploadDate = DateTime.MinValue}
    }

[<EntryPoint>]
let main argv =
    if argv.Length = 1 then
        let count = argv.[0] |> Int32.Parse
        use context = ContextFactory.Default()
        context.Database.EnsureDeleted() |> ignore
        context.Database.EnsureCreated() |> ignore
        let data = generateModel count |> List
        // context.BulkInsert data |> ignore
        context.Files.AddRange(data)
        context.SaveChanges() |> ignore
    0
