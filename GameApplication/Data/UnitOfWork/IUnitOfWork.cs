using GameApplication.Repositories;

public interface IUnitOfWork : IDisposable
{
    IDevelopersRepository DevelopersRepository { get; }
    IGameDevelopersRepository GameDevelopersRepository { get; }
    IGamesRepository GamesRepository { get; }
    IReviewsRepository ReviewsRepository { get; }
    ISystemRequirementsRepository SystemRequirementsRepository { get; }
    IUsersRepository UsersRepository { get; }

    Task CompleteAsync();
}