using Application.Configs;
namespace Application.Services.PersistenceFactoryService
{
    public interface IPersistenceFactory
    {
        IJWTConfig GetJWTConfig();
    }
}
