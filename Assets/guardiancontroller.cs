using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class guardiancontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public Text messagebar;
    public GameObject playerhandle;
    public Image chat;
    public bool ischating; 
    public Text chatmessage;
    void Start()
    {
        ischating = false;
        chat.gameObject.SetActive(false);
        messagebar.gameObject.SetActive(false);

        
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
                    chatmessage.text = "Guardian: Hi. You want to find XXXXX（村长). What do you want to do with him?";
                }   
            }
            else{
                messagebar.gameObject.SetActive(true);
                messagebar.text = "Press E to talk with guardian.";
            }
            
            
        }
        else if (Vector3.Distance(playerhandle.transform.position, this.transform.position) > 7.0f &&
        Vector3.Distance(playerhandle.transform.position, this.transform.position) < 8.0f){
            messagebar.gameObject.SetActive(false);
        }
    }
}
