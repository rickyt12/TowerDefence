namespace Template
{
    /// <summary>
    /// interface for game modes so gameloop as a consitent way of displaying mode information
    /// when debugging
    /// </summary>
    public interface IGameMode
    {
        string Description { get; }
    }
}