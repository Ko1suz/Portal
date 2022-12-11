using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(50,500)]
    public float sense;
    public Transform body;
    float xRot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    void Look()
    {
        float _xRot = Input.GetAxisRaw("Mouse X") * sense * Time.deltaTime;
        float _yRot = Input.GetAxisRaw("Mouse Y") * sense * Time.deltaTime;
        xRot -= _yRot;
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        xRot = Mathf.Clamp(xRot, -60f, 60f);
        body.Rotate(Vector3.up * _xRot);
    }
}
