using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FlexibleCelShader
{

    public static class PresetHelper
    {

        public readonly static string PresetDirectoryPath = Application.dataPath + "/FlexibleCelShader/Presets/";

        public static void SavePreset(string presetName, MaterialProperty[] properties)
        {
            PresetDataConainer container = new PresetDataConainer();
            foreach (var property in properties)
            {
                switch (property.name)
                {
                    case ("_Color"): container._ColorR = property.colorValue.r; container._ColorG = property.colorValue.g; container._ColorB = property.colorValue.b; break;
                    case ("_RampLevels"): container._RampLevels = property.floatValue; break;
                    case ("_LightScalar"): container._LightScalar = property.floatValue; break;
                    case ("_HighColor"): container._HighColorR = property.colorValue.r; container._HighColorG = property.colorValue.g; container._HighColorB = property.colorValue.b; break;
                    case ("_HighIntensity"): container._HighIntensity = property.floatValue; break;
                    case ("_LowColor"): container._LowColorR = property.colorValue.r; container._LowColorG = property.colorValue.g; container._LowColorB = property.colorValue.b; break;
                    case ("_LowIntensity"): container._LowIntensity = property.floatValue; break;
                    case ("_OutlineColor"): container._OutlineColorR = property.colorValue.r; container._OutlineColorG = property.colorValue.g; container._OutlineColorB = property.colorValue.b; break;
                    case ("_OutlineSize"): container._OutlineSize = property.floatValue; break;
                    case ("_RimColor"): container._RimColorR = property.colorValue.r; container._RimColorG = property.colorValue.g; container._RimColorB = property.colorValue.b; break;
                    case ("_RimAlpha"): container._RimAlpha = property.floatValue; break;
                    case ("_RimPower"): container._RimPower = property.floatValue; break;
                    case ("_RimDropOff"): container._RimDropOff = property.floatValue; break;
                    case ("_FresnelColor"): container._FresnelColorR = property.colorValue.r; container._FresnelColorG = property.colorValue.g; container._FresnelColorB = property.colorValue.b; break;
                    case ("_FresnelBrightness"): container._FresnelBrightness = property.floatValue; break;
                    case ("_FresnelPower"): container._FresnelPower = property.floatValue; break;
                    case ("_FresnelShadowDropoff"): container._FresnelShadowDropoff = property.floatValue; break;
                    case ("_GradYCap"): container._GradYCap = property.floatValue; break;
                    case ("_GradIntensity"): container._GradIntensity = property.floatValue; break;
                }
            }

            // Serialize container into Json
            string json = JsonUtility.ToJson(container, true);

            // Create the preset directory if it doesn't exist
            if (!Directory.Exists(PresetDirectoryPath))
            {
                Directory.CreateDirectory(PresetDirectoryPath);
            }

            // Write to file
            File.WriteAllText(PresetDirectoryPath + presetName + ".json", json);
        }

        public static MaterialProperty[] LoadPreset(string presetName, MaterialProperty[] properties)
        {
            // Check if the preset directory exists
            if (!Directory.Exists(PresetDirectoryPath))
            {
                throw new UnityException("Unable to find presets folder: " + PresetDirectoryPath);
            }

            // Try reading the file
            string json;
            try
            {
                json = File.ReadAllText(PresetDirectoryPath + presetName + ".json");
            }
            catch (FileNotFoundException e)
            {
                throw new UnityException("Unable to find preset file: " + e.FileName);
            }

            // Deserialize Json into container
            PresetDataConainer container = JsonUtility.FromJson<PresetDataConainer>(json);

            // Copy values from container into material properties
            foreach (var property in properties)
            {
                switch (property.name)
                {
                    case ("_Color"): property.colorValue = new Color(container._ColorR, container._ColorG, container._ColorB); break;
                    case ("_RampLevels"): property.floatValue = container._RampLevels; break;
                    case ("_LightScalar"): property.floatValue = container._LightScalar; break;
                    case ("_HighColor"): property.colorValue = new Color(container._HighColorR, container._HighColorG, container._HighColorB); break;
                    case ("_HighIntensity"): property.floatValue = container._HighIntensity; break;
                    case ("_LowColor"): property.colorValue = new Color(container._LowColorR, container._LowColorG, container._LowColorB); break;
                    case ("_LowIntensity"): property.floatValue = container._LowIntensity; break;
                    case ("_OutlineColor"): property.colorValue = new Color(container._OutlineColorR, container._OutlineColorG, container._OutlineColorB); break;
                    case ("_OutlineSize"): property.floatValue = container._OutlineSize; break;
                    case ("_RimColor"): property.colorValue = new Color(container._RimColorR, container._RimColorG, container._RimColorB); break;
                    case ("_RimAlpha"): property.floatValue = container._RimAlpha; break;
                    case ("_RimPower"): property.floatValue = container._RimPower; break;
                    case ("_RimDropOff"): property.floatValue = container._RimDropOff; break;
                    case ("_FresnelColor"): property.colorValue = new Color(container._FresnelColorR, container._FresnelColorG, container._FresnelColorB); break;
                    case ("_FresnelBrightness"): property.floatValue = container._FresnelBrightness; break;
                    case ("_FresnelPower"): property.floatValue = container._FresnelPower; break;
                    case ("_FresnelShadowDropoff"): property.floatValue = container._FresnelShadowDropoff; break;
                    case ("_GradYCap"): property.floatValue = container._GradYCap; break;
                    case ("_GradIntensity"): property.floatValue = container._GradIntensity; break;
                }
            }
            return properties;
        }

        public static void DeletePreset(string presetName)
        {
            if (File.Exists(PresetDirectoryPath + presetName + ".json"))
            {
                File.Delete(PresetDirectoryPath + presetName + ".json");
            }
            if (File.Exists(PresetDirectoryPath + presetName + ".json.meta"))
            {
                File.Delete(PresetDirectoryPath + presetName + ".json.meta");
            }
        }
    }

}
