namespace BlazorPintxos;

public class DBService
{
    public string Test { get; set; } = "my Test";
    private readonly PintxosContext _db;

    public DBService(PintxosContext db)
    {
        _db = db;
    }

    public List<User> GetUsers()
    {
        return _db.Users.OrderBy(o => o.Id).ToList();
    }

    public List<Contest> GetContests()
    {
        return _db.Contests.OrderByDescending(o => o.Date).ToList();
    }

    public List<Pintxo> GetPintxos()
    {
        return _db.Pintxos.OrderBy(o => o.Id).ToList();
    }
}