using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Camera myCamera;
    public GameObject ObjectToFollow;

    private Vector3 CameraPos;

    void Start()
    {
        CameraPos = myCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraPos.z = ObjectToFollow.transform.position.z - 15f;
        myCamera.transform.position = CameraPos;
    }
}
