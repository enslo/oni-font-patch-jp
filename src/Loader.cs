
using HarmonyLib;
using KMod;

namespace enslo.OniFontPatchJp
{
    public class Loader : UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            harmony.PatchAll();

            var rootPath = base.mod.file_source.GetRoot();

            var config = FontConfig.Load(rootPath);
            Patcher.Fonts = CustomFontAssets.Load(rootPath, config);
        }
    }
}

// Hack for using record.
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}
