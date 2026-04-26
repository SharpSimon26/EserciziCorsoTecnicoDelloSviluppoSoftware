namespace ConsAppMediaVoti;

internal class ElasticArrayIytem<T>
{
    public T Value { get; set; }
    public ElasticArrayIytem<T> Next { get; set; }
}