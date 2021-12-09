using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dungeonstart : MonoBehaviour
{
    // Start is called before the first frame update
    public Text messagebar;
    public Image chat;
    public Text chatmessage;
    void Start()
    {
        Time.timeScale = 1;
        if(Time.timeScale!= 0){
            Time.timeScale = 0;
            chatmessage.text = "Dungeon Introduction: It’s brighter than I think. But what is that weird smell? It’s actually pretty quiet, and there is no strange sound as the chief said. Let's walk around.\nYour goal is clear all enemy here and find out what happne here.";
            Cursor.visible = true;
            chat.gameObject.SetActive(true);
            messagebar.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
