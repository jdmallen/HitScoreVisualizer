using Harmony;

namespace HitScoreVisualizer.Harmony_Patches
{
    [HarmonyPatch(
        // Type to patch in MainAssembly of Beat Saber:
        typeof(FlyingScoreEffect),
        // The name of method to patch in that type:
        "HandleSaberSwingRatingCounterDidChangeEvent",
        // That method's parameter types:
        typeof(SaberSwingRatingCounter),
        typeof(float))]
    class FlyingScoreEffectHandleSaberAfterCutSwingRatingCounterDidChangeEvent
    {
        static bool Prefix(SaberSwingRatingCounter saberSwingRatingCounter, FlyingScoreEffect __instance, ref NoteCutInfo ____noteCutInfo)
        {
            if (Config.instance.doIntermediateUpdates)
            {
                ScoreController.RawScoreWithoutMultiplier(____noteCutInfo, out int before, out int after, out int accuracy);
                int total = before + after + accuracy;
                Config.judge(__instance, ____noteCutInfo, saberSwingRatingCounter, total, before, after, accuracy);
            }
            return false;
        }
    }
}
