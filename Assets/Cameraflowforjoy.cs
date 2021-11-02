using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraflowforjoy : MonoBehaviour
{
public Transform followTarget = null;

    public Vector2 rotate;
 
    public float rotateSpeed = 2;

    
    public float moveSpeed = 10;

    public float maxY = 80;

    public float minY = -80;

    public float viewSize = 60;

    public float defaultAngle = -135;

    public float radius = 3;

    public float height = 1.5f;

    public bool visiable = false;

    public CursorLockMode lockMode = CursorLockMode.Confined;

    public float inputX;
    public float inputY;


    private Camera controlCamara;


    void Start()
    {
        controlCamara = this.GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        inputX = Input.GetAxis("Jright");
        inputY = Input.GetAxis("Jup");
        rotate.x += inputX * rotateSpeed;
        rotate.y += inputY * rotateSpeed;
        viewSize += -Input.mouseScrollDelta.y * 3;
    



 
        if (viewSize < 1)
        {
            viewSize = 1;
        }
        else if (viewSize > 60)
        {
            viewSize = 60;
        }

  
        if (rotate.x >= 360 || rotate.x <= -360)
        {
            rotate.x = 0;
        }

   
        if (rotate.y < minY)
        {
            rotate.y = minY;
        }
        else if (rotate.y > maxY)
        {
            rotate.y = maxY;
        }
        controlCamara.fieldOfView = viewSize;
        Cursor.visible = visiable;
        Cursor.lockState = lockMode;


    }

    void LateUpdate()
    {
        Transform self = controlCamara.transform;
        Vector3 startPosition = self.position;
        Vector3 endPosition;

        Vector3 targetPos = followTarget.position;
        targetPos.y += height;

        Vector2 v1 = CalcAbsolutePoint(rotate.x, radius);
        endPosition = targetPos + new Vector3(v1.x, 0, v1.y);


        Vector2 v2 = CalcAbsolutePoint(rotate.x + defaultAngle, 1);
        Vector3 viewPoint = new Vector3(v2.x, 0, v2.y) + targetPos;

        float dist = Vector3.Distance(endPosition, viewPoint);
        Vector2 v3 = CalcAbsolutePoint(rotate.y, dist);
        endPosition += new Vector3(0, v3.y, 0);


        RaycastHit hit;
        if (Physics.Linecast(targetPos, endPosition, out hit))
        {
            string name = hit.collider.gameObject.tag;
            if (name != "MainCamera" || name != "Player")
            {
                endPosition = hit.point - (endPosition - hit.point).normalized * 0.2f;
            }
        }
        //self.position = endPosition;
        self.position = Vector3.Lerp(startPosition, endPosition, Time.deltaTime * moveSpeed);

        Quaternion rotateQ = Quaternion.LookRotation(viewPoint - endPosition);
        self.rotation = Quaternion.Slerp(transform.rotation, rotateQ, Time.deltaTime * moveSpeed);
        //self.rotation = rotateQ;
    }

    public static Vector2 CalcAbsolutePoint(float angle, float dist)
    {
        
        float radian = -angle * (Mathf.PI / 180);
        float x = dist * Mathf.Cos(radian);
        float y = dist * Mathf.Sin(radian);
        return new Vector2(x, y);
    }
}
