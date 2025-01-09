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

    #region Contests
    public List<Contest> GetContests()
    {
        return _db.Contests.OrderByDescending(o => o.Date).ToList();
    }

    public void NewContest(Contest newContest)
    {
        _db.Contests.Add(newContest);
        _db.SaveChangesAsync();
    }

    public void EditContest(int id, Contest newData)
    {
        var entity = _db.Contests.Find(id);
        if (entity != null)
        {
            _db.Contests.Entry(entity).CurrentValues.SetValues(newData);
        }
    }

    #endregion

    public List<Pintxo> GetPintxos()
    {
        return _db.Pintxos.OrderBy(o => o.Id).ToList();
    }
}