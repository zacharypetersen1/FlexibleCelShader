![Title](../media/images/title.jpg?raw=true)

Repository for the asset on the Unity Asset store found [here](https://assetstore.unity.com/packages/vfx/shaders/flexible-cel-shader-112979). Pull requests are welcome.

You should clone this repo directly into your assets folder to use the assets. If you want to move the "FlexibleCelShader" folder somewhere else, make sure you open PresetHelper.cs and update the path to the "Presets" folder on line 13.

This asset does not work with Scriptable Render Pipelines, I will create a seperate repository for a version of this asset that works on SRPs soon.



Multiple effects, easy to use. Nine presets provided right out of the box. Customize using the material editor, then save your new styles as presets.

- No ramp textures needed
- Edit all properties directly in the Material Editor
- Individually adjust High/Low light color and intensity
- Save properties into presets then apply presets to other materials
- Customizable soft and hard edge light effects built in - Works with shadow casting and recieving
- Works using a single directional light
- Three shaders for different border types, Clean (No Outline), Outline, and Silhouette
