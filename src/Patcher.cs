
using HarmonyLib;
using System;
using System.Linq;
using TMPro;
using UnityEngine;

namespace enslo.OniFontPatchJp
{
    [HarmonyPatch]
    public static class Patcher
    {
        public static CustomFontAssets Fonts;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Localization), nameof(Localization.SwapToLocalizedFont), new Type[] { typeof(string) })]
        public static bool SwapLocalizedFontGracefully(string fontname)
        {
            if (Localization.GetLocale()?.Lang != Localization.Language.Japanese)
            {
                return true; // Just proceed the original method, when the lauguage is not intended one.
            }

            Resources.FindObjectsOfTypeAll<TextStyleSetting>()
                .Where(style => style?.sdfFont is not null)
                .Do(style => style.sdfFont = SelectFont(style.sdfFont?.name));

            Resources.FindObjectsOfTypeAll<LocText>()
                .Where(text => text?.font is not null)
                .Do(text => text.font = SelectFont(text.font?.name));

            return false; // Skip the original method.
        }

        private static TMP_FontAsset SelectFont(string fontname)
        {
            return fontname switch
            {
                _ when fontname.StartsWith("GRAYSTROKE") || Fonts.Title.name == fontname => Fonts.Title,
                _ when fontname.StartsWith("Economica") || Fonts.Head.name == fontname => Fonts.Head,
                _ => Fonts.Description
            };
        }
    }
}
