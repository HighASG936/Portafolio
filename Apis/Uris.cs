namespace Portafolio.Apis
{
    public class Uris
    {
        public static string Books =>
            "https://apilibrary-production.up.railway.app/api/Book";

        public static string Devices =>
            "https://devicesinventory-production.up.railway.app/api/Device";

        public static string Users =>
            Environment.GetEnvironmentVariable("DATABASE_PUBLIC_URL") ?? string.Empty;

    }
}
