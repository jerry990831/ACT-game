using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class act_col : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject maria;
    public player input;
    private Animator act;
    public float speed = 0.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float walkspeed = 2.0f;
    private Vector3 moveDirection = Vector3.zero;
    private bool planlocker = false;
    private float attackspeed = 1 ;
    private float weighttarget;
    public float rollspeed=2.0f;
    private Rigidbody rigid;
    public GameObject swordhead;
    public GameObject swordtair;
    public bool takedamage = false;
    public GameObject damageTarget;
    public bool damagefeature = false;
    public GameObject enemyhandle;
    public enemycontroller enemyCont;
    public float playerhealth;
    public Slider slider;
    private float dv;
    public bool timestop;
    void Start()
    {
        input = GetComponent<player>();
        act = maria.GetComponent<Animator>();
        enemyCont = enemyhandle.GetComponent<enemycontroller>();
        playerhealth = 100f;
        timestop = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject camera1 = GameObject.Find("Main Camera");
        Vector3 Camera_r = camera1.transform.right;
        Camera_r.y=0;
        Vector3 Camera_f = camera1.transform.forward;
        Camera_f.y=0;
        slider.value = Mathf.SmoothDamp(slider.value,playerhealth,ref dv,0.1f);
        act.SetFloat("forwards",Mathf.Sqrt((input.upordown*input.upordown)+(input.rightorleft*input.rightorleft))*(input.run+1));
        
        if (input.isroll){
            act.SetTrigger("roll");
        }
        if (input.isheal){
            act.SetTrigger("heal");
        }
        if (input.isattack && act.GetCurrentAnimatorStateInfo(0).IsName("Ground")){
            act.SetTrigger("attack");
        }
        if(act.GetCurrentAnimatorStateInfo(0).IsName("roll")){
            speed = rollspeed;
        }
        if(act.GetCurrentAnimatorStateInfo(0).IsName("backflip")){
            if(act.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3 && act.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.6){
                speed = -1*walkspeed;
            }
            else{
                speed = 0;
            }
        }
        if(input.isbackflip){
            act.SetTrigger("backflip");
        }
        if(act.GetCurrentAnimatorStateInfo(0).IsName("Ground")){
            if((input.upordown*input.upordown)+(input.rightorleft*input.rightorleft)>0.1f && planlocker == false){
                Vector3 targetForward = Vector3.Slerp(maria.transform.forward,input.rightorleft*Camera_r+input.upordown*Camera_f,0.07f);
                maria.transform.forward = targetForward;
            }
            if((input.upordown*input.upordown)+input.rightorleft*input.rightorleft>0.10f)
            {
                speed =walkspeed*(input.run+1);
            }
            else{
                speed =0;
            }
        }
        if (enemyCont.takedamage && enemyCont.damageTarget.name=="Playerhandle"){
            Debug.Log("hurt");
            enemyCont.takedamage =false;
            enemyCont.damageTarget = null;
            if(act.GetCurrentAnimatorStateInfo(0).IsName("backflip") 
            && act.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5 &&
            timestop == false){
                Debug.Log("block");
                timestop = true;
            }
            else{
                playerhealth -= 10;
                act.SetTrigger("hit");
            }
            
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
            speed = speed * attackspeed;
            moveDirection = maria.transform.forward;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }


    public void Onattack1enter(){
        planlocker = true;
        attackspeed = 0;
        weighttarget = 1;
        damagefeature = true;
    }
    public void Onattack1exit(){
        damagefeature = false;
    }
    public void OnattackUpdate(){
        float weightnow = act.GetLayerWeight(act.GetLayerIndex("ATTACK"));
        weightnow = Mathf.Lerp(weightnow,weighttarget,0.05f);
        act.SetLayerWeight(act.GetLayerIndex("ATTACK"),weightnow);
    }
    public void Onattackidle(){
        attackspeed = 1;
        weighttarget = 0;
        planlocker = false;

    }
    public void Onattack2enter(){
        damagefeature = true;
    }
    public void Onattack2exit(){
        damagefeature = false;
    }
    public void Onattack3enter(){
        damagefeature = true;
    }
    public void Onattack3exit(){
        damagefeature = false;
    }
    public void OnattackidleUpdate(){
        float weightnow = act.GetLayerWeight(act.GetLayerIndex("ATTACK"));
        weightnow = Mathf.Lerp(weightnow,weighttarget,0.05f);
        act.SetLayerWeight(act.GetLayerIndex("ATTACK"),weightnow);
    }
    public void onhealenter(){
         planlocker = true;
        attackspeed = 0;
        weighttarget = 1;
    }
    public void onhealupdate(){
        float weightnow = act.GetLayerWeight(act.GetLayerIndex("ATTACK"));
        weightnow = Mathf.Lerp(weightnow,weighttarget,0.05f);
        act.SetLayerWeight(act.GetLayerIndex("ATTACK"),weightnow);
    }
    public void gethitenter(){
        planlocker=true;
        attackspeed = 0;
    }
    public void gethitexit(){
        planlocker=false;
        attackspeed = 1;
    }
}
