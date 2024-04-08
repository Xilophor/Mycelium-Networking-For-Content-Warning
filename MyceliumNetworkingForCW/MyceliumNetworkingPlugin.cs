using BepInEx;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace MyceliumNetworking
{
	[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class MyceliumNetworkingPlugin : BaseUnityPlugin
    {
	    public const string Guid = MyPluginInfo.PLUGIN_GUID;

	    private static bool _initialized;

	    private void Awake()
		{
			if(_initialized)
				return;

			_initialized = true;

			RugLogger.Initialize(MyPluginInfo.PLUGIN_GUID);

			Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

			RugLogger.Log($"MyceliumNetworking v{MyPluginInfo.PLUGIN_VERSION} is initializing...");

			MyceliumNetwork.Initialize();

			// Initialize mod on persistent GameObject
			var go = new GameObject("MyceliumNetworking Persistent");
			go.AddComponent<PersistentGameObject>();
			go.hideFlags = HideFlags.HideAndDontSave;
			DontDestroyOnLoad(go);
		}
	}
}
