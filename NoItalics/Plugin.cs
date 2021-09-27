using System.Reflection;
using HarmonyLib;
using IPA;

namespace NoItalics
{
	[Plugin(RuntimeOptions.DynamicInit)]
	public class Plugin
	{
		private const string HARMONY_ID = "be.erisapps.NoItalics";

		private static Harmony? _harmonyInstance;

#if DEBUG
		internal static IPA.Logging.Logger LoggerInstance { get; private set; } = null!;

		[Init]
		public void Init(IPA.Logging.Logger log)
		{
			LoggerInstance = log;
		}
#endif

		[OnEnable]
		// ReSharper disable once UnusedMember.Global
		public void OnEnable() => _harmonyInstance = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), HARMONY_ID);

		[OnDisable]
		// ReSharper disable once UnusedMember.Global
		public void OnDisable()
		{
			_harmonyInstance?.UnpatchSelf();
			_harmonyInstance = null;
		}
	}
}