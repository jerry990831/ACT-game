using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skeletonevent : MonoBehaviour
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
        if(Vector3.Distance(playerhandle.transform.position, this.transform.position) < 5.0f){
            if(Input.GetKeyDown("e")){
                ischating = true;
            }
            if(ischating){
                if(Time.timeScale!= 0){
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    chat.gameObject.SetActive(true);
                    messagebar.gameObject.SetActive(false);
                    chatmessage.text = "The skeleton is revived!";
                    this.gameObject.SetActive(false);
                }   
            }
            else{
                messagebar.gameObject.SetActive(true);
                messagebar.text = "Press E to check this skeleton";
            }
            
            
        }
        else if (Vector3.Distance(playerhandle.transform.position, this.transform.position) > 5.0f &&
        Vector3.Distance(playerhandle.transform.position, this.transform.position) < 6.0f){
            messagebar.gameObject.SetActive(false);
        }
    }
}
