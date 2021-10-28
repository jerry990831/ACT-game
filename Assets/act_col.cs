using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float rollspeed=2.0f;

    void Start()
    {
        input = GetComponent<player>();
        act = maria.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject camera1 = GameObject.Find("Main Camera");
        Vector3 Camera_r = camera1.transform.right;
        Camera_r.y=0;
        Vector3 Camera_f = camera1.transform.forward;
        Camera_f.y=0;
        Debug.Log(speed);
        act.SetFloat("forwards",Mathf.Sqrt((input.upordown*input.upordown)+(input.rightorleft*input.rightorleft))*(input.run+1));
        
        if (input.isroll){
            act.SetTrigger("roll");
        }
        if (input.isattack && act.GetCurrentAnimatorStateInfo(0).IsName("Ground")){
            act.SetTrigger("attack");
        }
        if(act.GetCurrentAnimatorStateInfo(0).IsName("roll")){
            speed = rollspeed;
            if(act.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.85f){
                speed=0;
            }
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
    }

    public void OnattackUpdate(){
        float weightnow = act.GetLayerWeight(act.GetLayerIndex("ATTACK"));
        weightnow = Mathf.Lerp(weightnow,weighttarget,0.01f);
        act.SetLayerWeight(act.GetLayerIndex("ATTACK"),weightnow);

    }
    public void Onattackidle(){
        attackspeed = 1;
        weighttarget = 0;
        planlocker = false;

    }
    public void OnattackidleUpdate(){
        float weightnow = act.GetLayerWeight(act.GetLayerIndex("ATTACK"));
        weightnow = Mathf.Lerp(weightnow,weighttarget,0.01f);
        act.SetLayerWeight(act.GetLayerIndex("ATTACK"),weightnow);
    }
}
