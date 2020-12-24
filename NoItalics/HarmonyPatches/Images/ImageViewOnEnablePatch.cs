using HarmonyLib;
using HMUI;

namespace NoItalics.HarmonyPatches.Images
{
	[HarmonyPatch(typeof(ImageView))]
	[HarmonyPatch("OnEnable", MethodType.Normal)]
	internal class ImageViewOnEnablePatch
	{
		// ReSharper disable once InconsistentNaming
		// ReSharper disable once RedundantAssignment
		internal static void Prefix(ref float ____skew)
		{
#if DEBUG
			Plugin.LoggerInstance.Notice("Attempting to unslant imageView");
#endif
			____skew = 0f;
		}
	}
}