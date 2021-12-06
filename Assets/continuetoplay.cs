using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class continuetoplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Image talking;
    public GameObject skeletonoutside;
    public Animator skeletonAct;
    public GameObject skeletonhandle;
    public Text text;
    public GameObject skeleton1;
    public GameObject skeleton2;
    public GameObject skeleton3;
    public GameObject skeleton4;
    public Animator skeleton1Act;
    public Animator skeleton2Act;
    public Animator skeleton3Act;
    public Animator skeleton4Act;
    public GameObject skeletonhandle1;
    public GameObject skeletonhandle2;
    public GameObject skeletonhandle3;
    public GameObject skeletonhandle4;

    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
        skeletonAct = skeletonoutside.GetComponent<Animator>();
        skeleton1Act = skeleton1.GetComponent<Animator>();
        skeleton2Act = skeleton2.GetComponent<Animator>();
        skeleton3Act = skeleton3.GetComponent<Animator>();
        skeleton4Act = skeleton4.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick(){
        if(text.text == "Here is a strange skeleton, you want to do some research. But it move now."){
            talking.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            skeletonAct.speed = 1;
            skeletonhandle.GetComponent<enemycontroller>().wakeup = true;
        }
        if(text.text =="there are more skeletons in the room. they are moving!" ){
            talking.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            skeleton1Act.speed = 1;
            skeletonhandle1.GetComponent<enemycontroller>().wakeup = true;
            skeleton2Act.speed = 1;
            skeletonhandle2.GetComponent<enemycontroller>().wakeup = true;
            skeleton3Act.speed = 1;
            skeletonhandle3.GetComponent<enemycontroller>().wakeup = true;
            skeleton4Act.speed = 1;
            skeletonhandle4.GetComponent<enemycontroller>().wakeup = true;
        }
    }
}
