using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

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
    public string heal;
    public bool isheal;
    public bool isbackflip;
    public string backflip;
    public bool canheal;

    public float upordown;
    public float rightorleft;
    private float vu;
    private float vr;
    private float vrun;

    public float lerfparamter; 
    public bool ispaused = false;
    public Image chat;
    public Text chatmessage;
    public Text messagebar;

    void Start()
    {
        lerfparamter = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        float du;
        float dr;
        float drun;
        if(Input.GetAxis("upordown")!=0){
            du = Input.GetAxis("upordown");    
        }
        else
        {
            du = Convert.ToInt32(Input.GetKey(up))-Convert.ToInt32(Input.GetKey(down));
        }
        if( Input.GetAxis("rightorleft")!=0)
        {
            dr = Input.GetAxis("rightorleft");
        } 
        else
        {
            dr = Convert.ToInt32(Input.GetKey(right))-Convert.ToInt32(Input.GetKey(left));     
        }
        
        
        upordown = Mathf.SmoothDamp(upordown,du,ref vu,lerfparamter);
        rightorleft = Mathf.SmoothDamp(rightorleft,dr,ref vr,lerfparamter);
        if (Convert.ToInt32(Input.GetButton("R1"))!=0)
        {
            drun = Convert.ToInt32(Input.GetButton("R1"));
        }
        else
        {
            drun = Convert.ToInt32(Input.GetKey(isrun));
        }
        run =  Mathf.SmoothDamp(run,drun,ref vrun,0.2f);
        if(canheal){
            if(Input.GetButtonDown("buttonleft")){
                isheal = Input.GetButtonDown("buttonleft");
            }
            else
            {
                isheal = Input.GetKeyDown(heal);
            }
        }
        
        if(Input.GetButtonDown("buttonup")){
            isattack = Input.GetButtonDown("buttonup");
        }
        else
        {
            isattack = Input.GetKeyDown(attack);
        }
        if(Input.GetButtonDown("buttondown")){
            isroll = Input.GetButtonDown("buttondown");
        }
        else
        {
            isroll = Input.GetKeyDown(roll); 
        }
        if(Input.GetKeyDown("p")){
            ispaused = true;
        }
        if(ispaused){
            if(Time.timeScale!= 0){
                Time.timeScale = 0;
                Cursor.visible = true;
                chat.gameObject.SetActive(true);
                messagebar.gameObject.SetActive(false);
                chatmessage.text = "The game is stopped, you can press continue to play game!";
            }   
        }
        isbackflip = Input.GetKeyDown(backflip);
    }
}
