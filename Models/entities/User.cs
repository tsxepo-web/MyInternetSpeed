using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Models;
public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get;set;}
    public string UserId {get;set;} = null!;
    public string? IP {get;set;}
    public string? ISP {get;set;}
    public string? Location {get;set;}
    public double UploadSpeed {get;set;}
    public double DownloadSpeed {get;set;}
    public DateTime Date {get;set;}
}