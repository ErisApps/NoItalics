using HarmonyLib;
using TMPro;

namespace NoItalics.HarmonyPatches.Text
{
	[HarmonyPatch(typeof(TextMeshPro))]
	[HarmonyPatch("Awake", MethodType.Normal)]
	internal class TextMeshProAwakePatch
	{
		// ReSharper disable once InconsistentNaming
		internal static void Prefix(ref FontStyles ___m_fontStyle)
		{
			if (___m_fontStyle.HasFlag(FontStyles.Italic))
			{
#if DEBUG
				Plugin.LoggerInstance.Notice($"Removing {FontStyles.Italic:G} from possibly serialized m_fontStyle.");
#endif
				// ReSharper disable once BitwiseOperatorOnEnumWithoutFlags
				___m_fontStyle &= ~FontStyles.Italic;
			}
		}
	}
}