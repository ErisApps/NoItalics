using HarmonyLib;
using TMPro;

namespace NoItalics.HarmonyPatches.Text
{
	[HarmonyPatch(typeof(TMP_Text))]
	[HarmonyPatch("fontStyle", MethodType.Setter)]
	internal class TmpFontStylePatch
	{
		internal static void Prefix(ref FontStyles value)
		{
#if DEBUG
			Plugin.LoggerInstance.Notice($"Setter prefix was called. {nameof(value)} has value {value:G}");
#endif
			if (value.HasFlag(FontStyles.Italic))
			{
#if DEBUG
				Plugin.LoggerInstance.Notice($"Removing {FontStyles.Italic:G} from new fontStyle value.");
#endif
				// ReSharper disable once BitwiseOperatorOnEnumWithoutFlags
				value &= ~FontStyles.Italic;
			}
		}
	}
}