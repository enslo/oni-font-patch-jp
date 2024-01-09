
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

namespace enslo.OniFontPatchJp
{
    public record CustomFontAssets(TMP_FontAsset Title, TMP_FontAsset Head, TMP_FontAsset Description)
    {
        public static CustomFontAssets Load(string rootPath, FontConfig config)
        {
            var subdir = Application.platform switch
            {
                RuntimePlatform.WindowsPlayer => "win",
                RuntimePlatform.OSXPlayer => "mac",
                _ => "linux"
            };
            var bundlePath = Path.Combine(rootPath, "assets", subdir, "fonts.bundle");

            var bundle = AssetBundle.LoadFromFile(bundlePath);
            var fonts = bundle.LoadAllAssets().OfType<TMP_FontAsset>();
            bundle.Unload(false);

            var defaultFont = Resources.FindObjectsOfTypeAll<TMP_FontAsset>()
                .First(asset => asset.name == "NotoSansCJKjp-Regular");

            return new CustomFontAssets(
                fonts.FirstOrDefault(font => font.name == config.Title) ?? defaultFont,
                fonts.FirstOrDefault(font => font.name == config.Head) ?? defaultFont,
                fonts.FirstOrDefault(font => font.name == config.Description) ?? defaultFont
            );
        }
    }
}
