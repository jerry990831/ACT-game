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

    void Start()
    {
        act = dummy.GetComponent<Animator>();
        controller = player.GetComponent<act_col>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.takedamage && controller.damageTarget.name=="training_dummy"){
            Debug.Log("hurt");
            act.SetTrigger("hurt");
            controller.takedamage =false;
            controller.damageTarget = null;
            slider.value+=30;
        }
        if(slider.value == 100){
            act.SetTrigger("dead");
        }
    }

}
