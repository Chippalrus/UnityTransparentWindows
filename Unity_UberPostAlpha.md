# Unity (Build 2021.3.7f1) Changing Universal Render Pipeline UberPost shader
Since URP writes 1 to the alpha in the UberPost shader we can modify this to fix it. Though, I am not aware of occuring bugs that may happen.

# URP with Alpha enabled UberPost
- :heavy_check_mark: Post-Processing
- :x: HDR (Untested)
- :heavy_check_mark: Semi-Transparent Textures/Effects
- :heavy_check_mark: OBS capture for Semi-Transparent Textures/Effects
- :heavy_check_mark: OBS capture for materials using ShaderGraph (Surface Type: Transparent)
### OBS Capture on Post-Processing
- :heavy_check_mark: Bloom**
- :heavy_check_mark: Grain Post-Processing**
- :heavy_check_mark: Chromatic Aberration**
- :heavy_check_mark: Lens Distortion
**Works but requires a  semi-transparent (0.25f ~ 0.4f) Black Texture to capture Post-Processing on Alpha areas

### Notes
The results are promising, however on OBS it is cutting out post-processing around existing objects. A solution, that seems to work, is to add a semi-transparent texture under or above everything; The results allow OBS Game Capture post-processing effects in full alpha areas.


# What I did
### Create URP Renderer Asset
This will create new Asset to customise
![CreateURPRenderAsset](https://user-images.githubusercontent.com/14833895/187855923-0da2dce0-4da1-4270-9fa3-f506d9e1e633.png)

## Change the Project "Renderer Pipeline Asset"
![ChangeRenderPipelineAsset](https://user-images.githubusercontent.com/14833895/187855965-db67110e-3a4f-4caa-a2b9-65098c2c36d5.png)

## Create/Copy the UberPost shader
By making changes to the [UberPost shader with minor tweaks](https://github.com/Chippalrus/Unity3D-Overlay-Testing/blob/master/Universal%20Render%20Pipeline%20UberPost/Assets/_HoloTest/Shaders/AlphaUberPost.shader) so that it allows alpha
Credits to [robrab2000-aa on the Unity forums](https://forum.unity.com/threads/transparent-rendertexture-with-postprocessing.1265873/)
```
half alpha = SAMPLE_TEXTURE2D_X(_SourceTex, sampler_LinearClamp, uvDistorted).w;
        return half4(color, alpha);
```

## Expose Shader List in Inespector
Add [tomkail's ExtendedScriptableObjectDrawer Script](https://gist.github.com/tomkail/ba4136e6aa990f4dc94e0d39ec6a058c) to the project. This will expose the shader list in the Renderer
![RenderDataUberPost](https://user-images.githubusercontent.com/14833895/187855988-5d036163-67be-477e-9df0-d9a41a3f5984.png)

## Change the "UberPost PS" 
Drag and drop the newly created Alpha enabled UberPost shader into the Renderer Data in the section of shaders for "UberPost PS"
![ChangeUberPost](https://user-images.githubusercontent.com/14833895/187892545-a8e07748-341e-42f2-a6ff-21348f6a2044.png)


## Screenshots of the results
### Its working, but its cutting off the post-processing outside of objects
![URPPostProcessAlpha](https://user-images.githubusercontent.com/14833895/187857905-ea3bfbc7-6ef4-4601-87db-f5d557c0c701.png)

### OBS Game Capture Transparency toggle for a better look at the issue
![OBSAllowTransparnt](https://user-images.githubusercontent.com/14833895/187857861-dd679bb0-6a7b-4931-9a2e-19fb4338729a.png)


## Semi-Transparent Black Texture Solution on the Right
![BlackTextureSolution](https://user-images.githubusercontent.com/14833895/187908663-40e90091-2cdc-4288-abd5-5fd72d71aef4.png)

### Closer look of the solution
![BlackTextureSolutionInOBS](https://user-images.githubusercontent.com/14833895/187908670-526ea29c-abad-42be-a9f1-e2dc75698465.png)
