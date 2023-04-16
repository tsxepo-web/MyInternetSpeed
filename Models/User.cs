using System;
using System.Threading.Tasks;
namespace Models;
public class User
{
    public int Id {get;set;}
    public string? IP {get;set;}
    public string? ISP {get;set;}
    public string? Location {get;set;}
    public double UploadSpeed {get;set;}
    public double DownloadSpeed {get;set;}
    public DateTime Date {get;set;}
}