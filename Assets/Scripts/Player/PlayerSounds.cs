using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] walkSounds;
    [SerializeField] AudioClip[] runSounds;
    FPSController fPSController;
    AudioSource audioSource;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        fPSController = GetComponent<FPSController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fPSController.inputY > 0 || fPSController.inputX > 0 || fPSController.inputY < 0 || fPSController.inputX < 0)
        {
            if(!audioSource.isPlaying && fPSController.grounded == true)
            {
                if(!fPSController.isRunning)
                {
                    if(i== 2){i =0;}
                    
                    audioSource.clip = walkSounds[i];
                    audioSource.Play();
                    i++;
                }
                else
                {
                    if(i== 2){i =0;}
                    
                    audioSource.clip = runSounds[i];
                    audioSource.Play();
                    i++;
                }
            }
            else if (audioSource.isPlaying)
            {

            }
            
        }
            
        
    }
}
