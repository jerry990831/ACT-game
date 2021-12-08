using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class allclearevent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject skeleton1;
    public enemycontroller skeletonCont1;
    public GameObject skeleton2;
    public enemycontroller skeletonCont2;
    public GameObject skeleton3;
    public enemycontroller skeletonCont3;
    public GameObject skeleton4;
    public enemycontroller skeletonCont4;
    public Text messagebar;
    public GameObject playerhandle;
    public Image chat;
    public bool ischating; 
    public Text chatmessage;
    public float timer;
    void Start()
    {
        timer = 0;
        if(skeleton1 != null){
            skeletonCont1 = skeleton1.GetComponent<enemycontroller>();
        }
        if(skeleton2 != null){
            skeletonCont2 = skeleton2.GetComponent<enemycontroller>();
        }
        if(skeleton3 != null){
            skeletonCont3 = skeleton3.GetComponent<enemycontroller>();
        }
        if(skeleton4 != null){
            skeletonCont4 = skeleton4.GetComponent<enemycontroller>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( skeletonCont1.health == 0 && skeletonCont2.health == 0 &&
        skeletonCont3.health == 0 && skeletonCont4.health == 0 ){
            timer+=Time.deltaTime;
        }
        if(timer>=3.0f){
            ischating = true;
        }
        if(ischating){
            if(Time.timeScale!= 0){
                Time.timeScale = 0;
                Cursor.visible = true;
                chat.gameObject.SetActive(true);
                messagebar.gameObject.SetActive(false);
                chatmessage.text = "A room in the dungeon seems to have been opened. Have a look.";
                this.gameObject.SetActive(false);
            }   
        }
    }
}
