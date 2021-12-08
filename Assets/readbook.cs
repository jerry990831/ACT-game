using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readbook : MonoBehaviour
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
                    chatmessage.text = "Research Diary:\nDay 1:\nThis is the perfect place for my research. So many people have died here. Tons of skeleton provided for me! I will start the research tomorrow.";
                }   
            }
            else{
                messagebar.gameObject.SetActive(true);
                messagebar.text = "Press E to read diary";
            }
        }
        else if (Vector3.Distance(playerhandle.transform.position, this.transform.position) > 3.0f &&
        Vector3.Distance(playerhandle.transform.position, this.transform.position) < 4.0f){
            messagebar.gameObject.SetActive(false);
        }
    }
}
