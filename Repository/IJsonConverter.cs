namespace Repository
{
    internal interface IJsonConverter
    {
        T DeserializeObject<T>(string value);
        string SerializeObject(object value);
    }
}