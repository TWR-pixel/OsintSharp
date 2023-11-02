using Newtonsoft.Json;

namespace OsintSharp.Core.Json;

public static class JsonUrlDeserialization
{
    public async static Task<Dictionary<string, Urls>> DeserializeAync(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));

        await using (var stream = new FileStream(fileName, FileMode.Open))
        {
            using (var reader = new StreamReader(stream))
            {
                var res = JsonConvert.DeserializeObject<Dictionary<string, Urls>>(await reader.ReadToEndAsync());

                return res;
            }
        }

    }
}
