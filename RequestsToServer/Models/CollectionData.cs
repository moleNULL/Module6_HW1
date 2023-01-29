namespace RequestsToServer.Models
{
    // array of particular models
    public class CollectionData<T> : Validation
    {
        public IReadOnlyCollection<T>? Data { get; init; }
    }
}