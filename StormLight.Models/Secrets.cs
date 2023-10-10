namespace StormLight.Models;

public class Secrets {
    public Database_ Database { get; set; } = default!;
    public Storage_  Storage  { get; set; } = default!;
}

public class Database_ {
    public string Host     { get; set; } = "";
    public string DbName   { get; set; } = "";
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
}

public class Storage_ {
    public string Endpoint  { get; set; } = "";
    public string AccessKey { get; set; } = "";
    public string SecretKey { get; set; } = "";
}