using GameApplication.Data;
using GameApplication.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    public IDevelopersRepository DevelopersRepository { get; private set; }
    public IGameDevelopersRepository GameDevelopersRepository { get; private set; }
    public IGamesRepository GamesRepository { get; private set; }
    public IReviewsRepository ReviewsRepository {  get; private set; }
    public ISystemRequirementsRepository SystemRequirementsRepository { get; private set; }
    public IUsersRepository UsersRepository { get; private set; }

    public UnitOfWork(DataContext context)
    {
        _context = context;
        DevelopersRepository = new DevelopersRepository(_context);

        GameDevelopersRepository = new GameDevelopersRepository(_context);

        GamesRepository = new GamesRepository(_context);

        ReviewsRepository = new ReviewsRepository(_context);

        SystemRequirementsRepository = new SystemRequirementsRepository(_context);

        UsersRepository = new UsersRepository(_context);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}