namespace Application.Configs
{
    public class JWTConfig : IJWTConfig
    {
        public string Isuser { get; set; }
        public string Audience { get; set; }
        public int AccessTokenTimeLife { get; set; } //for second
        public int RefreshTokenTimeLife { get; set; } //for second
        public int KeepSessionTimeLife { get; set; } //for second
        public string Secret { get; set; }
        public JWTConfig(string Issuer, string Audience, int AccessTokenTimeLife, int RefreshTokenTimeLife, int KeepSessionTimeLife, string Secret)
        {
            this.Isuser = Issuer;
            this.Audience = Audience;
            this.AccessTokenTimeLife = AccessTokenTimeLife;
            this.RefreshTokenTimeLife = RefreshTokenTimeLife;
            this.KeepSessionTimeLife = KeepSessionTimeLife;
            this.Secret = Secret;
        }
        public void Dispose()
        {
            //nothing
        }

        public JWTConfig GetJWTConfig()
        {
            return new JWTConfig(Isuser, Audience, AccessTokenTimeLife, RefreshTokenTimeLife, KeepSessionTimeLife, Secret);
        }
    }
}