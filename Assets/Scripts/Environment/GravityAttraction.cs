using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttraction : MonoBehaviour
{
   public float gravity = -10f;

   public void Attract(Transform body)
   {
       Vector3 targetDirection = (body.position - transform.position).normalized;
       Vector3 bodyUp = body.transform.up;

       body.rotation = Quaternion.FromToRotation(bodyUp, targetDirection) * body.rotation;
       body.GetComponent<Rigidbody>().AddForce(targetDirection * gravity);
   }
}
