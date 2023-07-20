using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustEffect;
    // Start is called before the first frame update
   void OnCollisionEnter2D(Collision2D other)
   {
       if(other.gameObject.tag == "Ground")
       {
        dustEffect.Play();
       }
   }
   void OnCollisionExit2D(Collision2D other)
   {
       if(other.gameObject.tag == "Ground")
       {
           dustEffect.Stop();
       }
   }
}
