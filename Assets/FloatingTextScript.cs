using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextScript : MonoBehaviour
{
    
    public float DestroyTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

}
