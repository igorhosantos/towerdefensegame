using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarView : MonoBehaviour
{
    private Transform cam;

    void Awake()
    {
        cam = Camera.main.transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
