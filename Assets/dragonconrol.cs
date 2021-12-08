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
    public GameObject player;
    private Animator playeract;
    public bool takedamage = false;
    public GameObject damageTarget;
    public bool damagefeature = false;
    public AudioSource dragonaudio;
    public AudioClip scream;
    public float dragonlife;
    public GameObject Playerhandle;
    public act_col playerCont;
    public hitbox Hitbox;
    public GameObject hitboxhandle;
    public Vector3 targetVector;
    public bool changed;
    void Start()
    {
        dragonlife = 100f;
        dragonact = dragon.GetComponent<Animator>();
        playeract = player.GetComponent<Animator>();
        active = false;
        timer = 0;
        changeeffect.gameObject.SetActive(false);
        takedamage = false;
        flame.gameObject.SetActive(false);
        dragonaudio = this.GetComponent<AudioSource>();
        Hitbox = hitboxhandle.GetComponent<hitbox>();
        targetVector = this.transform.forward;
        changed = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Playerhandle");
        if(Vector3.Distance(player.transform.position,this.transform.position) < 50f){
            dragonact.SetTrigger("wake");
        }
        if(active){
            if(Vector3.Distance(player.transform.position,this.transform.position) < 40f && Vector3.Distance(player.transform.position,this.transform.position) > 17f && dragonact.GetCurrentAnimatorStateInfo(0).IsName("Idle01")){
                dragonact.SetTrigger("close");
            }
            if(Vector3.Distance(player.transform.position,this.transform.position) > 40f && dragonact.GetCurrentAnimatorStateInfo(0).IsName("Idle01")){
                dragonact.SetTrigger("far");
            }
            if(Vector3.Distance(player.transform.position,this.transform.position) < 17f && dragonact.GetCurrentAnimatorStateInfo(0).IsName("Run")){
                dragonact.SetTrigger("attack");
            }
            if(Vector3.Distance(player.transform.position,this.transform.position) < 17f && dragonact.GetCurrentAnimatorStateInfo(0).IsName("Idle01")){
                dragonact.SetTrigger("tooclose");
            }
            if(Vector3.Distance(player.transform.position,this.transform.position) < 12f && dragonact.GetCurrentAnimatorStateInfo(0).IsName("Walk")){
                dragonact.SetTrigger("basicattack");
            }
            this.transform.forward = Vector3.Slerp(this.transform.forward, targetVector, 0.07f);
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Take Off")){
            timer = 0;
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Fly Forward 0")){
           targetVector = player.transform.position - this.transform.position;
            dragonspeed = 7.0f;
            if(Vector3.Distance(player.transform.position,this.transform.position) < 20f){
                dragonact.SetTrigger("farattack");
            }
        }
        
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Run")){
            targetVector = player.transform.position - this.transform.position;
            dragonspeed = 7.0f;
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Walk")){
            targetVector = player.transform.position - this.transform.position;
            dragonspeed = 4.0f;
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Basic Attack")){
            dragonspeed = 0.0f;
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Claw Attack")){
            dragonspeed = 0.0f;
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
           targetVector = player.transform.position - this.transform.position;
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Fly Flame Attack")){
            dragonspeed = 0.0f;
            flame.transform.localRotation = Quaternion.Euler(-30.0f, -90f, 0);
            flame.gameObject.SetActive(true);
            flame.Play();
        }
        else if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Flame Attack")){
            dragonspeed = 0.0f;
            flame.transform.localRotation = Quaternion.Euler(15f, -90f, 0);
            flame.gameObject.SetActive(true);
            flame.Play();
        }
        else if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Fly Flame Attack 0")){
            dragonspeed = 0.0f;
            flame.transform.localRotation = Quaternion.Euler(-30.0f, -90f, 0);
            flame.gameObject.SetActive(true);
            flame.Play();
        }
        
        else{
            flame.gameObject.SetActive(false);
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Claw Attack")){
            if(dragonact.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9){
                if(!takedamage){
                    dragonact.SetBool("failattack",true);
                }
            }
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("change") ){
            if(dragonact.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4f && dragonact.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.42f){
                dragonmodel.GetComponent<SkinnedMeshRenderer>().material = blue;
                changeeffect.gameObject.SetActive(true);
                changeeffect.Play();
            }
        }
        
        if (damagefeature){
            if(Hitbox.damageTarget!=null){
                damageTarget = Hitbox.damageTarget;
                damagefeature = false;
                takedamage = true;
            }
        }
        if(dragonlife <= 50 && !changed){
            dragonact.SetTrigger("change");
            changed = true;
        }
        if (playerCont.takedamage && playerCont.damageTarget.name=="UpperMouth02"){
                playerCont.takedamage =false;
                playerCont.damageTarget = null;
                dragonlife -= 100;
            }
        if(dragonlife <= 0.0f){
            dragonact.SetTrigger("death");
        }
        if(dragonact.GetCurrentAnimatorStateInfo(0).IsName("Die")){
            dragonact.SetBool("isdeath",true);
            dragonspeed = 0;

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
        playeract.SetTrigger("scream");

    }
    void changeexit(){
        changeeffect.gameObject.SetActive(false);
    }
    void dragonsreamenter(){
        dragonaudio.PlayOneShot(scream);
        playeract.SetTrigger("scream");
    }
    void dragonattackenter(){
        damagefeature = true;
    }
    void dragonattackexit(){
        damagefeature = false;

    }
    void takeoffenter(){
        takedamage = false;
        dragonact.SetBool("failattack",false);
    }
    void dragonsreamexit(){
        if(!playerCont.playersourse.isPlaying)
            playerCont.playersourse.Play();
    }
}
