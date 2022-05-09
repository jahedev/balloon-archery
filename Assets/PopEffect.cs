using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopEffect : MonoBehaviour   
{
    public float lifeTime = .5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
