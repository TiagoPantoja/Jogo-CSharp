using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    SpriteRenderer spriteColor;

    [SerializeField] Color32 hasPackageColor = new Color32(255, 78, 161, 255);
    [SerializeField] Color32 hasNoPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] float delayDestroy = 0.5f;

    void Start()
    {
        spriteColor = GetComponent<SpriteRenderer>();
        spriteColor.color = hasNoPackageColor;
    }

   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "Package" && !hasPackage)
       {
           Destroy(other.gameObject, delayDestroy);
           hasPackage = true;
           spriteColor.color = hasPackageColor;
       }

       if(other.tag == "Customer" && hasPackage)
       {
           hasPackage = false;
           spriteColor.color = hasNoPackageColor;
       }
   }
}
