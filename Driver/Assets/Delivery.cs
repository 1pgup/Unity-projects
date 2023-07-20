using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 HasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 NoPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] float DestroyDelay = 0.5f;
    bool HasPackage = false;

    SpriteRenderer SpriteRenderer;
    void Start() 
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Driver collided with smth");
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && (HasPackage == false))
        {
            Debug.Log("Package picked up");
            HasPackage = true;
            SpriteRenderer.color = HasPackageColor;
            Destroy(other.gameObject, DestroyDelay);
        }
        if (other.tag == "Customer" && HasPackage)
        {
            Debug.Log("Package delivered");
            HasPackage = false;
            SpriteRenderer.color = NoPackageColor;
        }
    }
}
