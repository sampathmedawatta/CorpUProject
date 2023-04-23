namespace EnergyShifter.Common
{
    public class JwtTokenSettings
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
        public string TokenLifeTime { get; set; }
        public string Issuer { get; set; }
    }
}