namespace OsintSharp.Core.Tests
{
    public class JsonDeserializationTest
    {
        [Fact]
        public void Test1()
        {
            var json = JsonUrlDeserialization().Deserialize("jsonFile");
        }
    }
}