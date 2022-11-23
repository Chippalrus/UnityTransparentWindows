# Unity Transparent Window with PostProcessing
Documenting OBS Game Capture using Unity as an Overlay with Post-Processing and Semi-Transparent textures. For Out of Box test results, I ramped up and exaggerated the Post-Processing for testing purposes. A possible solution for URP is to [change its UberPost PS shader](https://github.com/Chippalrus/UnityTransparentWindows/blob/master/Unity_UberPostAlpha.md) in the Renderer Data to allow alpha.

## What is known
- URP Writes 1 to Alpha when using Post-Processing and HDR (Disabling them retains the alpha)
- Alpha Beldning using OBS Game Capture is incorrect, causing darker/low alphas on objects.
- OBS seems to lower the Brightness of the entire capture when there are any transparency for the window.

## Required Project Setup
- Set Camera clearType to Solid Colour / Colour
- Set Camera backgroundColor to Color( 0,0,0,0 )
- Disable "Use DXGI flip model swapchain for D3D11" (Project Settings > Player > Resolution and Presentation)
- Disable HDR (URP Only)

# Testing Results
- [Out-Of-Box Notes](https://github.com/Chippalrus/UnityTransparentWindows/blob/master/Unity_OutOfBox_Notes.md) (Built-In has the best results without ShaderGraph)
- [Changing the URP UberPost Shader](https://github.com/Chippalrus/UnityTransparentWindows/blob/master/Unity_UberPostAlpha.md) (Possible Solution for URP)

# Project transparency used from
- [pheonise's](https://github.com/pheonise) [Unity3D-Desktop-Overlay](https://github.com/pheonise/Unity3D-Desktop-Overlay)

# Stuff I looked at
- [Transparent Window Discussion](https://forum.unity.com/threads/solved-windows-transparent-window-with-opaque-contents-lwa_colorkey.323057/)
- [Code Monkey's Video](https://www.youtube.com/watch?v=RqgsGaMPZTw)
- [URP Partial Transparency](https://forum.unity.com/threads/urp-full-window-partial-transparency.963743/)
- [OBS Capture Alpha Blending (No replies, but same issues)](https://forum.unity.com/threads/obs-game-capture-with-incorrect-alpha-blending.1218636/)
- [Unity Recorder Alpha HDRP, but there is mention of URP](https://forum.unity.com/threads/recorder-image-alpha-under-hdrp.1130353/)
- [Transparent RenderTexture with PostProcessing](https://forum.unity.com/threads/transparent-rendertexture-with-postprocessing.1265873/)
