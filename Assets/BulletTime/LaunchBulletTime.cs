using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBulletTime : MonoBehaviour
{
    public float theTimeScale;
    public RadiaBlur radiaBlue;
    public ColorAdjustEffect cae;


    public AudioSource ass;
    public AudioClip clipIn;
    public AudioClip clipOut;

    public GameObject player;
    public GameObject player_handle;
    public player input;
    public float t;
    public bool inital;
    public GameObject dragon;
    public Animator dragonACT;
    private Vector3 shakePos = Vector3.zero;

    void Start(){
        inital = true;
        if( dragon != null ){
            dragonACT = dragon.GetComponent<Animator>();
        }
    }
    void Update()
    {
        Animator anim = player.GetComponent<Animator>();
        act_col controller = player_handle.GetComponent<act_col>();
        input = player_handle.GetComponent<player>();
        

        if(controller.timestop){
            if(inital){
                t=0;
                ass.PlayOneShot(clipIn);
                inital = false;
            }
            t += Time.deltaTime;

            Time.timeScale = Mathf.Lerp(Time.timeScale, 0.2f, t);
            
            anim.speed = Mathf.Lerp(anim.speed, 5.0f, t);

            radiaBlue.Level = Mathf.Lerp(radiaBlue.Level, 15, t);

            cae.saturation = Mathf.Lerp(cae.saturation, 0.5f, t);

            controller.walkspeed = Mathf.Lerp(controller.walkspeed, 10f, t);

            controller.rollspeed = Mathf.Lerp(controller.rollspeed, 10f, t);

            input.lerfparamter = Mathf.Lerp(input.lerfparamter , 0.02f, t);
        }

        if (t >1.0)
        {
            t = 1f;
            if(inital){
                ass.PlayOneShot(clipOut);
            }
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, t);
            radiaBlue.Level = Mathf.Lerp(radiaBlue.Level, 1, t);
            cae.saturation = Mathf.Lerp(cae.saturation, 1f, t);
            anim.speed = 1.0f;
            controller.walkspeed = 2.0f;
            controller.rollspeed = 2.0f;
            input.lerfparamter = 0.1f;
            controller.timestop = false;
            inital = true;
        }
        if(dragon!=null){
            if(dragonACT.GetCurrentAnimatorStateInfo(0).IsName("Scream") || dragonACT.GetCurrentAnimatorStateInfo(0).IsName("change")){
                transform.localPosition -= shakePos;
                shakePos = Random.insideUnitSphere / 5.0f;
                transform.localPosition += shakePos;
            }
        }


    }
}
