using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffects : MonoBehaviour
{
    Animator animator;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void OnHoverEnter()
    {
        animator = GetComponent<Animator>();
        
        animator.SetBool("isHovering", true);

        audioSource.PlayOneShot(audioClip);
    }
    public void OnHoverExit()
    {
        animator.SetBool("isHovering", false);
    }
}
