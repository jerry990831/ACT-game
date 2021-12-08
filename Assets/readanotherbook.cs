using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readanotherbook : MonoBehaviour
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
                    chatmessage.text = "Skeleton Soldiers:Mix the spider potion with ________. Then pour the potion on the skeleton. __________ you will get the skeleton soldiers.";

                    Cursor.visible = true;
                    chat.gameObject.SetActive(true);
                    messagebar.gameObject.SetActive(false);
                }   
            }
            else{
                messagebar.gameObject.SetActive(true);
                messagebar.text = "Press E to read book";
            }
        }
        else if (Vector3.Distance(playerhandle.transform.position, this.transform.position) > 3.0f &&
        Vector3.Distance(playerhandle.transform.position, this.transform.position) < 4.0f){
            messagebar.gameObject.SetActive(false);
        }
    }

}
