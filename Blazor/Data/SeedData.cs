namespace BlazorPintxos;

public class SeedData
{
    public static void Initialize(PintxosContext db)
    {
        var contest = new Contest() {
            Name = "Test Contest",
            Date = DateTime.Now
        };
        db.Contests.Add(contest);

        var users = new User[]{
            new User() {
                Id = 1,
                Email = "user@user.com",
                Fullname = "Test User",
                Password = "test123"
            },
            new User() {
                Id = 2,
                Email = "user2@user.com",
                Fullname = "Another Test User",
                Password = "test456"
            }
        };
        db.Users.AddRange(users);

        var pintxos = new Pintxo[] {
            new Pintxo() {
                Id = 1,
                Name = "My Pintxo",
                Description = "A Winner pintxo to be tested",
                Owner = users[0].Id
            },
            new Pintxo() {
                Id = 2,
                Name = "Great Pintxo",
                Description = "Something edible",
                Owner = users[1].Id
            }
        };
        db.Pintxos.AddRange(pintxos);

        var votes = new Vote[]
        {
            new Vote() {
                Id = 1,
                PintxoId = pintxos[0].Id,
                UserId = users[0].Id,
                Score = 10
            },
            new Vote() {
                Id = 2,
                PintxoId = pintxos[1].Id,
                UserId = users[1].Id,
                Score = 5
            },
            new Vote() {
                Id = 3,
                PintxoId = pintxos[0].Id,
                UserId = users[0].Id,
                Score = 3
            },
            new Vote() {
                Id = 4,
                PintxoId = pintxos[1].Id,
                UserId = users[1].Id,
                Score = 9
            }
        };
        db.Votes.AddRange(votes);

        db.SaveChanges();
    }
}