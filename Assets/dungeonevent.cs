using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dungeonevent : MonoBehaviour
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
        if(ischating){
            Time.timeScale = 0;
            Cursor.visible = true;
            chat.gameObject.SetActive(true);
            messagebar.gameObject.SetActive(false);
            chatmessage.text = "Suddenly there is a big noise coming from the other side of the hall! All the skeletons are awake!";
            this.gameObject.SetActive(false);
        }

    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Playerhandle"){
           ischating =true;
        }
    }
}
