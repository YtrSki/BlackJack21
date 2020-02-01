using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float idy = 0, idz = 0, ody = 0, odz = 0;
    bool isZoom = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        idy *= 0.9f;
        idz *= 0.9f;
        ody *= 0.9f;
        odz *= 0.9f;

        if(isZoom) transform.position = new Vector3(3, 4.0f + idy, -0.5f - idz);
        else transform.position = new Vector3(3, 4.5f - ody, -1 + odz);
    }

    public void ZoomIn()
    {
        isZoom = true;
        this.idy = 0.5f;
        this.idz = 0.5f; 
    }

    public void ZoomOut()
    {
        isZoom = false;
        this.ody = 0.5f;
        this.odz = 0.5f;
    }
}
