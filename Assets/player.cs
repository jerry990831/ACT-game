using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public string up;
    public string down;
    public string right;
    public string left;
    public string isrun;
    public float run;
    public string roll;
    public bool isroll;
    public string attack;
    public bool isattack;

    public float upordown;
    public float rightorleft;
    private float vu;
    private float vr;
    private float vrun;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float du;
        float dr;
        float drun;
        du = Convert.ToInt32(Input.GetKey(up))-Convert.ToInt32(Input.GetKey(down));
        dr = Convert.ToInt32(Input.GetKey(right))-Convert.ToInt32(Input.GetKey(left));
        
        upordown = Mathf.SmoothDamp(upordown,du,ref vu,0.1f);
        rightorleft = Mathf.SmoothDamp(rightorleft,dr,ref vr,0.1f);

        drun = Convert.ToInt32(Input.GetKey(isrun));
        run =  Mathf.SmoothDamp(run,drun,ref vrun,0.2f);
        isroll = Input.GetKeyDown(roll); 
        isattack = Input.GetKeyDown(attack);
    }
}
