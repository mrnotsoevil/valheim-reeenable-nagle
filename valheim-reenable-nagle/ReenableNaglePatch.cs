using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HarmonyLib;
using Steamworks;

namespace valheim_reenable_nagle
{
    [HarmonyPatch(typeof(ZSteamSocket), "SendQueuedPackages")]
    public class ReenableNaglePatch
    {
        static bool Prefix(ZSteamSocket __instance, Queue<byte[]> ___m_sendQueue, ref int ___m_totalSent, HSteamNetConnection ___m_con)
        {
            if (!__instance.IsConnected())
                return false;
            while (___m_sendQueue.Count > 0)
            {
                byte[] source = ___m_sendQueue.Peek();
                IntPtr num = Marshal.AllocHGlobal(source.Length);
                Marshal.Copy(source, 0, num, source.Length);
                // This was k_nSteamNetworkingSend_ReliableNoNagle before
                EResult connection = SteamNetworkingSockets.SendMessageToConnection(___m_con, num, (uint) source.Length, Constants.k_nSteamNetworkingSend_Reliable, out long _);
                Marshal.FreeHGlobal(num);
                if (connection == EResult.k_EResultOK)
                {
                    ___m_totalSent += source.Length;
                    ___m_sendQueue.Dequeue();
                }
                else
                {
                    ZLog.Log((object) ("Failed to send data " + (object) connection));
                    break;
                }
            }
            return false;
        }
    }
}