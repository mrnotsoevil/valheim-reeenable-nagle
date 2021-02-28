using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace valheim_reenable_nagle
{
    [BepInPlugin("de.mrnotsoevil.valheim.reenable-nagel", "Valheim Re-enable Nagel's Algorithm", "1.0.0.0")]
    public class ValheimReenableNaglePlugin : BaseUnityPlugin
    {
        public void Awake()
        {
            Debug.Log("[Valheim Re-enable Nagle] Applying patch ...");
            Harmony.CreateAndPatchAll(typeof(ReenableNaglePatch));
        }
    }
}