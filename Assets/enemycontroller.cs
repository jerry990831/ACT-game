using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemycontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject skeleton;
    public float gravity = 20.0F;
    public float walkspeed = 2.0f;
    public GameObject playerhandle;
    public float health; 
    public Slider slider;
    public GameObject enemyhandle;
    public bool needclean;
    public float damage = 30f;
    public bool damagefeature;
    public GameObject swordhead;
    public GameObject swordtair;
    public bool takedamage;
    public GameObject damageTarget;
    public GameObject healthbar;

    private Animator act;
    private Vector3 moveDirection = Vector3.zero;
    private bool walkenable; 
    private float speed = 0f;
    private bool attackenable;
    private float timer;
    private act_col playercontroller;
    private float dv;
    private float deathtimer;
    public bool wakeup;


    void Start()
    {
        act = skeleton.GetComponent<Animator>();
        walkenable = true;
        attackenable = true;
        timer = 0;
        health = 100f;
        playercontroller = playerhandle.GetComponent<act_col>();
        deathtimer=0;
        needclean = false;
        damagefeature = false;
        takedamage = false;
        act.speed = 0;
        wakeup = false;
        healthbar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(wakeup){
            healthbar.SetActive(true);
            if(health<0){
                health=0;
            }
            slider.value = Mathf.SmoothDamp(slider.value,health,ref dv,0.1f);
            
            if(health>0){
                this.transform.forward = this.transform.position-playerhandle.transform.position;
            }

            if( walkenable && Vector3.Distance(playerhandle.transform.position, this.transform.position)<20){
                if(timer != 0){
                    timer =0;
                }
                speed=2.0f;
                act.SetBool("walk",true);
            }
            else{
                speed =0.0f;
                act.SetBool("walk",false);

            }
            if(attackenable && Vector3.Distance(playerhandle.transform.position, this.transform.position) < 3f){
                act.SetTrigger("attack");
                if(timer != 0){
                    timer =0;
                }

            }
            if(act.GetCurrentAnimatorStateInfo(0).IsName("attack")){
                walkenable = false;
                attackenable = false;
                speed = 0f;
            }
            if( !walkenable && !attackenable){
                timer+=Time.deltaTime;
            }
            if(timer>=1.5f){
                walkenable = true;
                attackenable = true;
            }
            if (playercontroller.takedamage && playercontroller.damageTarget.name==this.gameObject.name){
                Debug.Log("hurt");
                playercontroller.takedamage =false;
                playercontroller.damageTarget = null;
                health -= damage;
                if(health<=0){
                    act.SetTrigger("die");
                    act.SetBool("die_able",false);
                    speed = 0;
                }
                act.SetTrigger("hit");

                walkenable = false;
                attackenable = false;
            }
            if(health == 0 && deathtimer < 6.0f){
                deathtimer += Time.deltaTime;
            }
            if(deathtimer>=6.0f){
                this.transform.gameObject.SetActive(false);
            }
            if(act.GetCurrentAnimatorStateInfo(0).IsName("gethit") || act.GetCurrentAnimatorStateInfo(0).IsName("die")){
                speed = 0.0f;
            }
            if(act.GetCurrentAnimatorStateInfo(0).IsName("sit")){
                speed=0;
            }
            RaycastHit hit;
            if (damagefeature){
                if(Physics.Linecast(swordhead.transform.position, swordtair.transform.position,out hit)){
                    damageTarget = hit.collider.gameObject;
                    damagefeature = false;
                    takedamage = true;
                }   
            }

            CharacterController controller = GetComponent<CharacterController>();
            if (controller.isGrounded) {
                moveDirection = this.transform.forward;
                moveDirection *= -speed;
            }
            
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            }
       
    }
    public void enemyattackenter(){
        damagefeature = true;
    }
    public void enemyattackexit(){
        damagefeature = false;
    }
}
