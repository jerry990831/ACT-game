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
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClick);
        skeletonAct = skeletonoutside.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick(){
        talking.gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        skeletonAct.speed = 1;
        skeletonhandle.GetComponent<enemycontroller>().wakeup = true;
    }
}
