using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class villegestart : MonoBehaviour
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
            chatmessage.text = "Village introduction: You are now at XX village. It’s located on the border of XXX empire. Because of its remoteness, there is no person here that can exert the magic. Many people have been killed by the magic creatures. Therefore, the villagers built huge walls to keep out the magic creatures around them.";
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
