using System.Runtime.Serialization;

namespace OsintSharp.Core.Models.Json;

public class Url
{
    [DataMember(Name = "errorType")]
    public string ErrorType { get; set; }
    [DataMember(Name = "url")]
    public string UrlJ { get; set; }
    [DataMember(Name = "urlMain")]
    public string UrlMain { get; set; }
    [DataMember(Name = "username_claimed")]
    public string UserNameClaimed { get; set; }
}
