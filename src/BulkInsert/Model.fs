module BulkInsert.Model

open System
open System.ComponentModel.DataAnnotations

type FileStatus =
    | Import = 0
    | FileNotExist = 100
    | UploadSuccess = 200
    | UploadFail = 300

[<CLIMutable>]
type QFile = {
    [<Key>]
    Id: int
    Status: FileStatus
    ImportDate: DateTime
    UploadDate: DateTime
    Message: string
    EcmPath: string
    EcmName: string
    EcmUuid: string

    GRequestNumber: string
    GTciNo: string
    GTciNoDateStamp: DateTime
    GRequestStatus: string
    GFileName: string
    GOriginalFileName: string
    GAttachedDate: DateTime
}