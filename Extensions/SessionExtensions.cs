using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace TalabatSmartVillage.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            return string.IsNullOrWhiteSpace(data) ? default : JsonSerializer.Deserialize<T>(data);
        }
    }
}
