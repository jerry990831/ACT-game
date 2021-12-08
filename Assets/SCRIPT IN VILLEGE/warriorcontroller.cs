using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warriorcontroller : MonoBehaviour
{
    public Text messagebar;
    public GameObject playerhandle;
    public Image chat;
    public bool ischating; 
    public Text chatmessage;
    void Start()
    {
        ischating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerhandle.transform.position, this.transform.position) < 7.0f){
            if(Input.GetKeyDown("e")){
                ischating = true;
            }
            if(ischating){
                if(Time.timeScale!= 0){
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    chat.gameObject.SetActive(true);
                    messagebar.gameObject.SetActive(false);
                    chatmessage.text = "Warriors: You want to practice your sword skill?";
                }   
            }
            else{
                messagebar.gameObject.SetActive(true);
                messagebar.text = "Press E to talk with warrior.";
            }
            
            
        }
        else if (Vector3.Distance(playerhandle.transform.position, this.transform.position) > 7.0f &&
        Vector3.Distance(playerhandle.transform.position, this.transform.position) < 8.0f){
            messagebar.gameObject.SetActive(false);
        }
    }
}
