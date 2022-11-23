# Unity (Build 2021.3.7f1) Out-Of-Box results for OBS Game Capture with Post-Processing and Transparency
### What I did
- Added Colour Adjustments to attempt to boost the alpha values for OBS Game Capture. ![ColourAdjustment](https://user-images.githubusercontent.com/14833895/183529372-ceef1fd6-af32-4db1-9290-46e8f93256d4.png)
- Added a Blank Semi-Transparent texture over top of everything. (Colour Tint: #333333)
- Written and Graphed unlit sprite shaders for adjusting alpha values.

## Built-in Render Pipeline
- :heavy_check_mark: Post-Processing
- :heavy_check_mark: HDR
- :heavy_check_mark: Semi-Transparent Textures/Effects
- :heavy_check_mark: OBS capture for Semi-Transparent Textures/Effects
- :x: OBS capture for Built-in ShaderGraph // Transparent shaders requires a workaround but Opaque shaders work
### OBS Capture on Post-Processing (Removed from transparent areas)
- :heavy_check_mark: Bloom 
- :heavy_check_mark: Grain Post-Processing
- :heavy_check_mark: Chromatic Aberration // Functional and does not seem to be getting removed on OBS
- :heavy_check_mark: Lens Distortion
### Notes
- Most of the Post-processing can be retained by using a semi-transparent filter. (Chromatic Aberration, does not seem to require this).
- Adding a semi-transparent filter does solve Shader-Graph shaders to be shown, however, still at a lower Alpha value than same Written Shader.
### Screenshot
#### Semi-transparent filter applied to the right
Colour Adjusments. Semi-transparent Filter on the right. Bloom, Chromatic Aberration and Grain
![BRP](https://user-images.githubusercontent.com/14833895/183537158-e6fa76bb-9184-41ab-96bd-51ee7da52739.png)
#### A Closer look in OBS
![brpobs](https://user-images.githubusercontent.com/14833895/183537231-5db1d0ff-6d83-42ce-86c9-d25bb9bc7bf3.png)



## HD Render Pipeline
- :heavy_check_mark: Post-Processing
- :x: Lens Distortion // Creates shadow-like effect of object before distortion. I DONT KNOW WHY
- :heavy_check_mark: HDR
- :heavy_check_mark: Semi-Transparent Textures/Effects
- :heavy_check_mark: OBS capture for Semi-Transparent Textures/Effects
- :heavy_check_mark: OBS capture for materials using ShaderGraph (Surface Type: Transparent)
### OBS Capture on Post-Processing
- :heavy_check_mark: Bloom
- :heavy_check_mark: Grain Post-Processing
- :heavy_check_mark: Chromatic Aberration
- :x: Lens Distortion
### Notes
- Most of the Post-processing can be retained by using a semi-transparent filter.
- Adding a semi-transparent filter does not solve the Lens Distortion issue, where it creates a shadow-like copy of the object before distortion.
### Screenshot
Colour Adjusments. Semi-transparent Filter on the right. Bloom, Chromatic Aberration, Grain with Lens Distortion issues
![HDRP](https://user-images.githubusercontent.com/14833895/183537064-204ad450-c3e2-4e8f-b648-71edaec52d7c.png)


## Universal Render Pipeline (Without making changes to UberPost shader)
- :x: Post-Processing (Transparent Window doesn't work with this)
- :x: HDR (Transparent Window doesn't work with this)
- :heavy_check_mark: Semi-Transparent Textures/Effects
- :heavy_check_mark: OBS capture for Semi-Transparent Textures/Effects
- :heavy_check_mark: OBS capture for materials using ShaderGraph (Surface Type: Transparent)
### OBS Capture on Post-Processing (Cannot even test this)
- :x: Bloom 
- :x: Grain Post-Processing
- :x: Chromatic Aberration
- :x: Lens Distortion
### Notes
- Written Shaders seems to have lower alpha value in OBS Capture, the complete opposite of Built-In.
- Enabling Post-Processing and HDR completely disables Transparent Window.
### Screenshot
![URP](https://user-images.githubusercontent.com/14833895/183536958-8949959e-7252-47a8-82f2-a46e6d67d51f.png)
