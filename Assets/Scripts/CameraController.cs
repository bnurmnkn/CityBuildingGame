using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public float moveSpeed;

    public float minXRot;
    public float maxXRot;

    private float curXRot;

    public float minZoom;
    public float maxZoom;

    public float zoomSpeed;
    public float rotationSpeed;

    private float curZoom;

    private Camera cam;
   

    private void Start()
    {
        cam=Camera.main;
        curZoom=cam.transform.localPosition.y;
        curXRot=-50;
    }
    private void Update()
    {
        curZoom +=Input.GetAxis("Mouse ScrollWheel")*-zoomSpeed;
        curZoom=Mathf.Clamp(curZoom,minZoom,maxZoom);

        cam.transform.localPosition=UnityEngine.Vector3.up*curZoom;
        if(Input.GetMouseButton(1))
        {
            float x=Input.GetAxis("Mouse X");
            float y=Input.GetAxis("Mouse Y");

            curXRot+=-y * rotationSpeed;
            curXRot= Mathf.Clamp(curXRot,minXRot,maxXRot);

            transform.eulerAngles=new UnityEngine.Vector3(curXRot,transform.eulerAngles.y+(x*rotationSpeed),0.0f);
            
        }
        //Movement

        UnityEngine.Vector3 forward = cam.transform.forward;

        forward.y=0.0f;
        forward.Normalize();

        UnityEngine.Vector3 right=cam.transform.right;

        float moveX=Input.GetAxisRaw("Horizontal");
        float moveZ=Input.GetAxisRaw("Vertical");

        UnityEngine.Vector3 dir=forward* moveZ+right*moveX;

        dir.Normalize();
        dir *= moveSpeed*Time.deltaTime;
        transform.position+=dir;
        

        
    }
   
   

}
