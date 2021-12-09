using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endevent : MonoBehaviour
{
    // Start is called before the first frame update
    public dragonconrol dragonCont;
    public Text messagebar;
    public Image chat;
    public Text chatmessage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dragonCont.end){
            Time.timeScale = 0;
            Cursor.visible = true;
            chat.gameObject.SetActive(true);
            messagebar.gameObject.SetActive(false);
            chatmessage.text = "Congratulations! You defeat the dragon. You say goodbye to the village, and start on a new journey. To be continued. Press continue to back to the menu";
        }
    }
}
