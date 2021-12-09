using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalstart : MonoBehaviour
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
            chatmessage.text = "Not a long time after you entered that building, the ground began to shake. A fireball hits the church. Then this dragon flies here and destroys everything.";
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
