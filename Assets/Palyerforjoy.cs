using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Palyerforjoy : MonoBehaviour
{
        public float upordown;
        public float rightorleft;
        public bool isroll;
        public bool isattack;
        public bool isheal;
        public float run;
        public float drun;
        private float vrun;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        upordown = Input.GetAxis("upordown");
        rightorleft = Input.GetAxis("rightorleft");
        isroll = Input.GetButtonDown("buttondown"); 
        isattack = Input.GetButtonDown("buttonup");
        isheal = Input.GetButtonDown("buttonleft");
        drun = Convert.ToInt32(Input.GetButton("R1"));
        run =  Mathf.SmoothDamp(run,drun,ref vrun,0.2f);

    }
}
