
using System.IO;
using Newtonsoft.Json;

namespace enslo.OniFontPatchJp
{
    public record FontConfig(string Title, string Head, string Description)
    {
        public static FontConfig Load(string rootPath)
        {
            string filePath = Path.Combine(rootPath, "font_info.json");
            string json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<FontConfig>(json);
        }
    }
}
