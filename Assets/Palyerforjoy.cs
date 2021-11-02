using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Palyerforjoy : MonoBehaviour
{
        public float du;
        public float dr;
        public float upordown;
        public float rightorleft;
        public bool isroll;
        public bool isattack;
        public bool isheal;
        public float run;
        public float drun;
        private float vrun;
        private float vu;
        private float vr;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
        du = Input.GetAxis("upordown");
        dr = Input.GetAxis("rightorleft");
        upordown = Mathf.SmoothDamp(upordown,du,ref vu,0.1f);
        rightorleft = Mathf.SmoothDamp(rightorleft,dr,ref vr,0.1f);
        isroll = Input.GetButtonDown("buttondown"); 
        isattack = Input.GetButtonDown("buttonup");
        isheal = Input.GetButtonDown("buttonleft");
        drun = Convert.ToInt32(Input.GetButton("R1"));
        run =  Mathf.SmoothDamp(run,drun,ref vrun,0.2f);

    }
}
