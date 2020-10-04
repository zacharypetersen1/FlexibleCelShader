using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;


public class CelCustomEditor : MaterialEditor
{
    float spacing = 20;
    string saveName = "Preset Name";
    string celOutlinePath = "Custom/CelOutline";
    string celNoOutlinePath = "Custom/Cel";

    void showProperty(string propertyName)
    {
        MaterialProperty property = GetMaterialProperty(targets, propertyName);
        ShaderProperty(property, property.displayName);
    }

    void showPropertyAsInt(string propertyName)
    {
        MaterialProperty property = GetMaterialProperty(targets, propertyName);
        ShaderProperty(property, property.displayName);
        property.floatValue = Mathf.Round(property.floatValue);
    }

    void showPropertyGreaterZero(string propertyName)
    {
        MaterialProperty property = GetMaterialProperty(targets, propertyName);
        ShaderProperty(property, property.displayName);
        if (property.floatValue < 0)
        {
            property.floatValue = 0;
        }
    }

    void drawPresets()
    {

        //GUILayout.Space(spacing);
        EditorGUILayout.LabelField("Load Existing Preset", EditorStyles.boldLabel);
        foreach (var path in Directory.GetFiles(FlexibleCelShader.PresetHelper.PresetDirectoryPath))
        {
            string fileName = Path.GetFileName(path);
            if (Path.GetExtension(fileName) == ".json")
            {
                string presetName = Path.GetFileNameWithoutExtension(fileName);
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button(presetName))
                {
                    MaterialProperty[] properties = GetMaterialProperties(targets);
                    properties = FlexibleCelShader.PresetHelper.LoadPreset(presetName, properties);
                }
                Color c = GUI.backgroundColor;
                GUIStyle style = new GUIStyle(EditorStyles.miniButton);
                style.normal.textColor = Color.red;
                if (GUILayout.Button("Delete", style, GUILayout.Width(60)))
                {
                    if (EditorUtility.DisplayDialog("Delete " + presetName, "Are you sure you want to delete " + presetName + "? This cannot be undone.", "Delete", "Cancel"))
                    {
                        FlexibleCelShader.PresetHelper.DeletePreset(presetName);
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
        }

        GUILayout.Space(8);
        EditorGUILayout.LabelField("Save Current As New Preset", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        saveName = GUILayout.TextField(saveName, GUILayout.ExpandWidth(true));
        if (GUILayout.Button("Save", EditorStyles.miniButton, GUILayout.Width(60)))
        {
            FlexibleCelShader.PresetHelper.SavePreset(saveName, GetMaterialProperties(targets));
            saveName = "Preset Name";
        }
        EditorGUILayout.EndHorizontal();
    }

    public override void OnInspectorGUI()
    {

        drawPresets();

        GUILayout.Space(spacing);
        EditorGUILayout.LabelField("Base Color and Textures", EditorStyles.boldLabel);
        showProperty("_MainTex");
        showProperty("_NormalTex");
        showProperty("_EmmisTex");
        showProperty("_Color");

        GUILayout.Space(spacing);
        EditorGUILayout.LabelField("Lighting Ramp", EditorStyles.boldLabel);
        showPropertyAsInt("_RampLevels");
        showProperty("_LightScalar");

        GUILayout.Space(spacing);
        EditorGUILayout.LabelField("High Light", EditorStyles.boldLabel);
        showProperty("_HighColor");
        showProperty("_HighIntensity");

        GUILayout.Space(spacing);
        EditorGUILayout.LabelField("Low Light", EditorStyles.boldLabel);
        showProperty("_LowColor");
        showProperty("_LowIntensity");

        GUILayout.Space(spacing);
        EditorGUILayout.LabelField("Outline", EditorStyles.boldLabel);
        showProperty("_OutlineColor");
        showPropertyGreaterZero("_OutlineSize");

        GUILayout.Space(spacing);
        EditorGUILayout.LabelField("Hard Edge Light", EditorStyles.boldLabel);
        showProperty("_RimColor");
        showProperty("_RimAlpha");
        showProperty("_RimPower");
        showProperty("_RimDropOff");

        GUILayout.Space(spacing);
        EditorGUILayout.LabelField("Soft Edge Light", EditorStyles.boldLabel);
        showProperty("_FresnelColor");
        showProperty("_FresnelBrightness");
        showProperty("_FresnelPower");
        showProperty("_FresnelShadowDropoff");

        /*GUILayout.Space(spacing);
        EditorGUILayout.LabelField("Vertical Gradient", EditorStyles.boldLabel);
        showProperty("_GradIntensity");
        showProperty("_GradYCap");*/

    }
}

