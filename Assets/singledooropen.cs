using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class singledooropen : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject playerhandle;
    private Vector3 startangle;
    
    void Start()
    {
        playerhandle = GameObject.Find("Playerhandle");
        startangle = this.transform.eulerAngles;
        Debug.Log(startangle);
    }

    // Update is called once per frame
    void Update()
    {
        if(startangle == new Vector3(0f,180f,0f)){
            if(Vector3.Distance(this.transform.position , playerhandle.transform.position) < 5){
                this.transform.eulerAngles = Vector3.Slerp(this.transform.eulerAngles,new Vector3(0f,90.0f,0f),0.01f);
            }
            if(Vector3.Distance(this.transform.position , playerhandle.transform.position) > 10){
                this.transform.eulerAngles = Vector3.Slerp(this.transform.eulerAngles,new Vector3(0f,180f,0f),0.01f);
            }
        }
        if(startangle == new Vector3(0f,0f,0f)){
            if(Vector3.Distance(this.transform.position , playerhandle.transform.position) < 5){
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,-90f, 0),  0.01f);
            }
            if(Vector3.Distance(this.transform.position , playerhandle.transform.position) > 10){
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0, 0),  0.01f);
            }
        }

        if(startangle == new Vector3(0f,270f,0f)){
            if(Vector3.Distance(this.transform.position , playerhandle.transform.position) < 5){
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,180f, 0),  0.01f);
            }
            if(Vector3.Distance(this.transform.position , playerhandle.transform.position) > 10){
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,270f, 0),  0.01f);
            }
        }
    }
}
