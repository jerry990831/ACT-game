using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leadercontroller : MonoBehaviour
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
                    chatmessage.text = "Dear Sir, We are so appreciated that you can accept our request.  I believe you have seen the weird building at the entrance of the town. That is the source of the creaky noise. That building used to belong to a wizard which disappeared months ago. About two weeks ago, there was a sound coming from the underground of that building. Some bold youth went to check the situation, but none of them came back. Everyone in the village is in a panic right now. I really hope you can help us.";
                }   
            }
            else{
                messagebar.gameObject.SetActive(true);
                messagebar.text = "Press E to talk with Chief.";
            }
            
            
        }
        else if (Vector3.Distance(playerhandle.transform.position, this.transform.position) > 7.0f &&
        Vector3.Distance(playerhandle.transform.position, this.transform.position) < 8.0f){
            messagebar.gameObject.SetActive(false);
        }
    }
}
