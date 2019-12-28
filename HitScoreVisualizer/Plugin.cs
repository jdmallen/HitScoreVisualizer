using Harmony;
using System;
using System.Reflection;
using IPA;
using UnityEngine.SceneManagement;

namespace HitScoreVisualizer
{
    public class Plugin : IBeatSaberPlugin
    {
        public string Name => "HitScoreVisualizer";
        public string Version => $"{majorVersion}.{minorVersion}.{patchVersion}";

        internal const int majorVersion = 2;
        internal const int minorVersion = 4;
        internal const int patchVersion = 1;

        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
            SceneManager.sceneLoaded += OnSceneLoaded;
            try
            {
                var harmony = HarmonyInstance.Create("com.arti.BeatSaber.HitScoreVisualizer");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception e)
            {
                Console.WriteLine("[HitScoreVisualizer] This plugin requires Harmony. Make sure you " +
                    "installed the plugin properly, as the Harmony DLL should have been installed with it.");
                Console.WriteLine(e);
            }
            Config.load();
        }

        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }

        /// <summary>Gets invoked whenever a scene is loaded.</summary>
        /// <param name="scene">The scene currently loaded</param>
        /// <param name="sceneMode">The type of loading</param>
        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
        }

        /// <summary>Gets invoked whenever a scene is unloaded</summary>
        /// <param name="scene">The unloaded scene</param>
        public void OnSceneUnloaded(Scene scene)
        {
        }

        /// <summary>Gets invoked whenever a scene is changed</summary>
        /// <param name="prevScene">The Scene that was previously loaded</param>
        /// <param name="nextScene">The Scene being loaded</param>
        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
        }

        internal static void log(object message)
        {
#if DEBUG
            Console.WriteLine("[HitScoreVisualizer] " + message);
#endif
        }
    }
}
