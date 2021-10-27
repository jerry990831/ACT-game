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
        act.SetFloat("forwards",Mathf.Sqrt((input.upordown*input.upordown)+(input.rightorleft*input.rightorleft))*(input.run+1));
        
        if (input.isroll){
            act.SetTrigger("roll");
        }
        if (input.isattack && !act.GetCurrentAnimatorStateInfo(0).IsName("roll") && speed<=0.1f){
            act.SetTrigger("attack");
        }
        if(act.GetCurrentAnimatorStateInfo(0).IsName("roll")){
            speed = walkspeed;
            if(act.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.85f){
                speed=0;
            }
        } 
        if(act.GetCurrentAnimatorStateInfo(0).IsName("Ground")){
            if((input.upordown*input.upordown)+(input.rightorleft*input.rightorleft)>0.1f){
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
            moveDirection = maria.transform.forward;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    
    
}
