using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healmagic : MonoBehaviour
{
    // Start is called before the first frame update
    public Text messagebar;
    public GameObject playerhandle;
    public Image chat;
    public bool ischating; 
    public Text chatmessage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerhandle.transform.position, this.transform.position) < 3.0f){
            if(Input.GetKeyDown("e")){
                ischating = true;
            }
            if(ischating){
                if(Time.timeScale!= 0){
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    chat.gameObject.SetActive(true);
                    messagebar.gameObject.SetActive(false);
                    chatmessage.text = "Oh, it's healing magic!\neverything is done here. it is time to leave";
                }   
            }
            else{
                messagebar.gameObject.SetActive(true);
                messagebar.text = "Press E to touch it.";
            }
            
            
        }
          else if (Vector3.Distance(playerhandle.transform.position, this.transform.position) > 3.0f &&
        Vector3.Distance(playerhandle.transform.position, this.transform.position) < 4.0f){
            messagebar.gameObject.SetActive(false);
        }

    }
}
