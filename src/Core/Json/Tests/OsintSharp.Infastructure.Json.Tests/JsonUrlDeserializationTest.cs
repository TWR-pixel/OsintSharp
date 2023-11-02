namespace OsintSharp.Core.Json.Tests
{
    public class JsonUrlDeserializationTest
    {
        [Fact]
        public async void Test1()
        {
            var j = await JsonUrlDeserialization.DeserializeAync("jsonfile");

        }
    }
}