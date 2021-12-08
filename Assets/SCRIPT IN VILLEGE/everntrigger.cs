using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class everntrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject trigger1;
    public GameObject trigger2;
    public bool ischating;
    public Text messagebar;
    public GameObject playerhandle;
    public Image chat;
    public Text chatmessage;
    void Start()
    {
        ischating = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Linecast(trigger1.transform.position, trigger2.transform.position,out hit)){
                if(hit.collider.gameObject.name == "Playerhandle"){
                    ischating = true;
                }
        }
        if(ischating){
             if(Time.timeScale!= 0){
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    chat.gameObject.SetActive(true);
                    messagebar.gameObject.SetActive(false);
                    chatmessage.text = "Here is the dungeon";
                }   
        }   
    }
}
