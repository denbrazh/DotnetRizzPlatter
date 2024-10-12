namespace RedisConnector.Models;

public class RedisConfig
{
    public List<RedisHost>? RedisHosts { get; set; }
    public string? RedisPassword { get; set; }
}