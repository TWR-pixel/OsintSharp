using System.Runtime.Serialization;

namespace OsintSharp.Core.Json;

public class Urls
{
    [DataMember(Name = "errorType")]
    public string ErrorType { get; set; }
    [DataMember(Name = "url")]
    public string Url { get; set; }
    [DataMember(Name = "urlMain")]
    public string UrlMain { get; set; }
    [DataMember(Name = "username_claimed")]
    public string UserNameClaimed { get; set; }
}
