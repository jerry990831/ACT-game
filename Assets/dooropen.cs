using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerhandle;
    public GameObject doorR;
    public GameObject doorL;
    public GameObject door1;

    public Vector3 doorrotation;
    public Vector3 currentEulerAnglesfordoorR;
    public Vector3 currentEulerAnglesfordoorL;
    
    void Start()
    {
        doorL.transform.eulerAngles = new Vector3(0,359.9f,0);

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(doorR.transform.position , playerhandle.transform.position) < 20){

            currentEulerAnglesfordoorR =  doorR.transform.eulerAngles;
            doorR.transform.eulerAngles = Vector3.Slerp(doorR.transform.eulerAngles,new Vector3(0,90.0f,0),0.01f);
            currentEulerAnglesfordoorL = doorL.transform.eulerAngles;
            doorL.transform.eulerAngles = Vector3.Slerp(doorL.transform.eulerAngles,new Vector3(0,270.0f,0),0.01f);

        }
        if(Vector3.Distance(doorR.transform.position , playerhandle.transform.position) > 25){
            currentEulerAnglesfordoorR =  doorR.transform.eulerAngles;
            doorR.transform.eulerAngles = Vector3.Slerp(doorR.transform.eulerAngles,new Vector3(0,0.0f,0),0.01f);
            currentEulerAnglesfordoorL = doorL.transform.eulerAngles;
            doorL.transform.eulerAngles = Vector3.Slerp(doorL.transform.eulerAngles,new Vector3(0,359.9f,0),0.01f);
        }
        
    }
}
