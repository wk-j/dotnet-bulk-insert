module BulkInsert.Context

open Microsoft.EntityFrameworkCore
open BulkInsert.Model

type NbtcContext(connectionString) =
    inherit DbContext()

    [<DefaultValue>]
    val mutable private LocalFiles: DbSet<QFile>
    member this.Files
        with get() = this.LocalFiles
        and set v  = this.LocalFiles <- v

    override __.OnModelCreating(builder: ModelBuilder) =
        let entity = builder.Entity<QFile>()
        entity.HasIndex(fun x -> x.Status :> obj) |> ignore

    override __.OnConfiguring(builder: DbContextOptionsBuilder) =
        builder.UseNpgsql(connectionString: string) |> ignore

type ContextFactory() =
    static member Create(connectionString) =
        new NbtcContext(connectionString)

    static member Default() =
        let connectionString = "Server=localhost; Port=5432; Database=BulkInsert; Integrated Security=true; User Id=postgres; Password=1234;"
        new NbtcContext(connectionString)