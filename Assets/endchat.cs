using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endchat : MonoBehaviour
{
    // Start is called before the first frame update
    public Image chat;
    public GameObject guardianhandle;
    public guardiancontroller guardiancont;
    public Text chatmessage;
    private string guardiantext1 = "Guardian: Hi. You want to find XXXXX（村长). What do you want to do with him?";
    private string guardiantext2 = "Oh! You are XXX(主角) that XXXXX(村长) mentioned days ago. I think you can find him in his house. XXXX(村长)’s house is in the center of the village.";

    void Start()
    {
        guardiancont = guardianhandle.GetComponent<guardiancontroller>();
         this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    void OnClick(){
        if(chatmessage.text == guardiantext2){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
            guardiancont.ischating = false;
        } 
        else if(chatmessage.text == guardiantext1){
            chatmessage.text = guardiantext2;
        }

    }
}
