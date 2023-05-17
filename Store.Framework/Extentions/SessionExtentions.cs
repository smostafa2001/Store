using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Store.Framework.Extentions;

public static class SessionExtentions
{
    public static void SetJson(this ISession session, string key, object value) => session.SetString(key, JsonConvert.SerializeObject(value));
    public static T GetJson<T>(this ISession session, string key)
    {
        var jsonObject = session.GetString(key);
        return JsonConvert.DeserializeObject<T>(jsonObject ?? "") ?? default;
    }
}
