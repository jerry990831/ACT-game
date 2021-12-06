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

    void Start()
    {
        guardiancont = guardianhandle.GetComponent<guardiancontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);

    }
        void OnClick(){
        if(chatmessage.text == "Guardian: you can find him in that house!"){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
            guardiancont.ischating = false;
        }
    }
}
