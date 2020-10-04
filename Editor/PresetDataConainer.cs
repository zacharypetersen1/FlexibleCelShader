using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlexibleCelShader
{

    [System.Serializable]
    public class PresetDataConainer : System.Object
    {
        public float _ColorR;
        public float _ColorG;
        public float _ColorB;
        public float _RampLevels;
        public float _LightScalar;
        public float _HighColorR;
        public float _HighColorG;
        public float _HighColorB;
        public float _HighIntensity;
        public float _LowColorR;
        public float _LowColorG;
        public float _LowColorB;
        public float _LowIntensity;
        public float _OutlineColorR;
        public float _OutlineColorG;
        public float _OutlineColorB;
        public float _OutlineSize;
        public float _RimColorR;
        public float _RimColorG;
        public float _RimColorB;
        public float _RimAlpha;
        public float _RimPower;
        public float _RimDropOff;
        public float _FresnelColorR;
        public float _FresnelColorG;
        public float _FresnelColorB;
        public float _FresnelBrightness;
        public float _FresnelPower;
        public float _FresnelShadowDropoff;
        public float _GradYCap;
        public float _GradIntensity;
    }

}