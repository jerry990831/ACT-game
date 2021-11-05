using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dummycontroller : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator act;
    public GameObject dummy;
    public GameObject player;
    public act_col controller;
    public Slider slider;
    private float dv;
    private float valuecurr;
    void Start()
    {
        act = dummy.GetComponent<Animator>();
        controller = player.GetComponent<act_col>();
        valuecurr = 100;
        slider.value = 100;
    } 

    // Update is called once per frame
    void Update()
    {
        if (controller.takedamage && controller.damageTarget.name=="training_dummy"){
            Debug.Log("hurt");
            act.SetTrigger("hurt");
            controller.takedamage =false;
            controller.damageTarget = null;
            valuecurr -= 30;
            
        }
        slider.value = Mathf.SmoothDamp(slider.value,valuecurr,ref dv,0.1f);
        if(slider.value == 0){
            act.SetTrigger("dead");
        }
        if (act.GetCurrentAnimatorStateInfo(0).IsName("died")){
            if(Time.frameCount % 3 == 0){
                valuecurr += 1;
            }
            if (valuecurr == 100){
                act.SetTrigger("awake");
                slider.value = 100;
            }

        }
    }
}
