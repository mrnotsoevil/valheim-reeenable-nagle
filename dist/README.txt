# Re-enable Nagle's Algorithm in Valheim

The recent version of Valheim (0.146.11) reworked the networking, 
but disabled an important method that prevents clogging your network with packets, 
leading to massive lags and disconnects, as well as breaking other services like YouTube or Discord.

This mod attempts to fix this issue and reverts to the old networking method.
Please not that rubber banding and desyncs can still occur - this patch is only for removing the massive lags.

## Installation

1. Install [Valheim BepInEx](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/)
2. Copy `valheim_reenable_nagel.dll` (in the ZIP file) into `Valheim/BepInEx/plugins`