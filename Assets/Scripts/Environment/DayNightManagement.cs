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
   SkyboxBlender skyboxBlender;
   bool CR_Running;
   bool newWave;
   
    void Start()
    {
        skyboxBlender = GetComponent<SkyboxBlender>();
    }
    void Update()
    {

        CameraSolidColorChanger();

        if (Preset == null)
        {
            return;
        }
        SkyBoxAndTime();

        //New Wave at new Day
        if (TimeOfDay < 1 && TimeOfDay > 0 && !newWave)
        {
            newWave = true;
            ObjectPool.Wave++;
            Debug.Log("Current wave" + ObjectPool.Wave);
        }
    }

    private void SkyBoxAndTime()
    {
        if (Application.isPlaying)
        {
            //Wenn es Nachts ist
            if (TimeOfDay > 17f)
            {
                newWave = false;
                TimeOfDay += Time.deltaTime * nightSpeed;
                //RenderSettings.skybox = nightMaterial;
                itsNight = true;
                if (!CR_Running && skyboxBlender.blend != 1)
                {
                    CR_Running = true;
                    StartCoroutine(BlendSkyNight());
                }
            }
            //Wenn es Tags ist
            else
            {
                TimeOfDay += Time.deltaTime * daySpeed;
                //RenderSettings.skybox = dayMaterial;
                itsNight = false;
                StartCoroutine(BlendSkyDay()); 
            }

            TimeOfDay %= 24; //Clamp between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
            skyboxBlender.blend = 0;
        }
    }

    IEnumerator BlendSkyNight()
    {
        if(skyboxBlender.blend <=1) skyboxBlender.blend += 0.005f;
        yield return new WaitForSeconds(0.05f);
        CR_Running = false;
    }
    IEnumerator BlendSkyDay()
    {
        if(skyboxBlender.blend >= 0) skyboxBlender.blend -= 0.005f;
        yield return new WaitForSeconds(0.05f);
        CR_Running = false;
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
