using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonconrol : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator dragonact;
    public GameObject dragon;
    public float dragonspeed = 0.0F;
    private float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public bool active;
    public float timer;
    public Vector3 targetForward;
    public ParticleSystem flame;
    public ParticleSystem changeeffect;
    public GameObject dragonmodel;
    public Material blue;

    void Start()
    {
        dragonact = dragon.GetComponent<Animator>();
        active = false;
        timer = 0;
        changeeffect.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Playerhandle");
        if(Vector3.Distance(player.transform.position,this.transform.position) < 40f){
            dragonact.SetTrigger("wake");
        }
        if(active){
            if(Vector3.Distance(player.transform.position,this.transform.position) < 30f && Vector3.Distance(player.transform.position,this.transform.position) > 5f){
                dragonact.SetTrigger("close");
                
            }
            if(Vector3.Distance(player.transform.position,this.transform.position) < 18f){
                dragonspeed = 0;
                dragonact.SetTrigger("attack");
            }
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Take Off")){
            timer = 0;
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Run")){
            this.transform.forward = player.transform.position - this.transform.position;
            dragonspeed = 7.0f;
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Fly Forward")){
            dragonspeed = 10.0f;
            timer += Time.deltaTime;
            if(timer>=3.0f){
                timer = 0;
                dragonact.SetTrigger("flyflame");
                targetForward = player.transform.position - this.transform.position;
            }
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Fly Float")){
            transform.forward = Vector3.Slerp(transform.forward, targetForward ,  0.07f);
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Fly Flame Attack")){
            flame.gameObject.SetActive(true);
            flame.Play();
        }
        else{
            flame.gameObject.SetActive(false);
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("change")){
            if(dragonact.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f && dragonact.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.42f){
                dragonmodel.GetComponent<SkinnedMeshRenderer>().material = blue;
                changeeffect.gameObject.SetActive(true);
                changeeffect.Play();
            }
        }
       
        CharacterController controller = GetComponent<CharacterController>();
        
        if (controller.isGrounded) {
            moveDirection = this.transform.forward;
            moveDirection *= dragonspeed;
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        
    }
    void idleenter(){
        active = true;
    }
    void changeenter(){

    }
    void changeexit(){
        changeeffect.gameObject.SetActive(false);

    }
}
