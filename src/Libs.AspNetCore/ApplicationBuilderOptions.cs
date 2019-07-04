namespace Libs.AspNetCore
{
    public class ApplicationBuilderOptions
    {
        public bool UseCastleLoggerFactory { get; set; }

        public bool UseSecurityHeaders { get; set; }

        public ApplicationBuilderOptions()
        {
            UseCastleLoggerFactory = true;
            UseSecurityHeaders = true;
        }
    }
}
