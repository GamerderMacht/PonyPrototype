using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DayNightManagement : MonoBehaviour
{
    //Referenzen
   [SerializeField] private Light DirectionalLight; 
   [SerializeField] private LightningPreset Preset; 
   //Variablen
   [SerializeField, Range(0,24)] public float TimeOfDay;
   [SerializeField] float daySpeed; 
   [SerializeField] float nightSpeed;

    [Header("CameraEinstellungen")]
    //Camera Referenz. Solid Color nach Tageszeit ändern
   [SerializeField] public Camera[] cameras;
   public Color32 color1;
   public Color32 color2;

   [Header("SkyboxMaterialDayNight")]
   [SerializeField] Material dayMaterial;
   [SerializeField] Material nightMaterial;

   public static bool itsNight;
   
    void Start()
    {
        
    }
    void Update()
    {
        CameraSolidColorChanger();

        if (Preset == null)
        {
            
            return;
        }
        if (Application.isPlaying)
        {
            if(TimeOfDay > 18f || TimeOfDay < 6f)
            {TimeOfDay += Time.deltaTime * nightSpeed;
            RenderSettings.skybox = nightMaterial;
            itsNight = true;}
            else {TimeOfDay += Time.deltaTime * daySpeed;
            RenderSettings.skybox = dayMaterial;
            itsNight = false;}
            
            TimeOfDay %= 24; //Clamp between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) -90f, 170f, 0));
        }
    }
   private void OnValidate()
   {
       if (DirectionalLight != null)
       {
           return;
       }
       if (RenderSettings.sun != null)
       {
           DirectionalLight = RenderSettings.sun;
       }
       else
       {
           Light[] lights = GameObject.FindObjectsOfType<Light>();
           foreach(Light light in lights)
           {
               if(light.type == LightType.Directional)
               {
                   DirectionalLight = light;
                   return;
               }
           }
       }

   }
   private void CameraSolidColorChanger()
   {
       if(cameras[0].isActiveAndEnabled || cameras[1].isActiveAndEnabled)
       {    //Nachtcolor
           if(TimeOfDay < 6f || TimeOfDay > 18f)
           {
               //ändere Solidcolor Nachts
               cameras[0].backgroundColor = color1;

           }
           else
           {
               //Tagcolor
                cameras[0].backgroundColor = color2;
           }
       }
       else{return;}
   }
}
