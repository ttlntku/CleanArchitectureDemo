using Application.Configs;

namespace Application.Services.PersistenceFactoryService
{
    public class PersistenceFactory : IPersistenceFactory
    {
        public JWTConfig JWTConfig { get; set; }

        public PersistenceFactory(JWTConfig jwtConfig)
        {
            JWTConfig = jwtConfig;
        }

        public IJWTConfig GetJWTConfig()
        {
            return JWTConfig;
        }
    }
}
