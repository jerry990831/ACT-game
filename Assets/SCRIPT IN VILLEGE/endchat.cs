using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endchat : MonoBehaviour
{
    // Start is called before the first frame update
    public Image chat;
    public GameObject guardianhandle;
    public guardiancontroller guardiancont;
    public Text chatmessage;
    public GameObject leaderhandle;
    public leadercontroller leaderCont;
    public GameObject warrior;
    public warriorcontroller WarriorCont;
    public GameObject skeleton;
    public enemycontroller skeletonCont;
    public GameObject skeleton1;
    public enemycontroller skeletonCont1;
    public GameObject skeleton2;
    public enemycontroller skeletonCont2;
    public GameObject skeleton3;
    public enemycontroller skeletonCont3;
    public GameObject skeleton4;
    public enemycontroller skeletonCont4;
    public GameObject door1;
    public GameObject door2;
    public GameObject book;
    public readbook Readbook;
    public player playerinput;
    public readanotherbook anotherbook;
    public bool endgame;
    private string guardiantext1 = "Guardian: Hi. You want to find Chief. What do you want to do with him?";
    private string guardiantext2 = "Oh! You are traveler that chief mentioned days ago. I think you can find him in his house. Chief’s house is in the center of the village.";
    private string chieftext1 = "Dear Sir, We are so appreciated that you can accept our request.  I believe you have seen the weird building at the entrance of the town. That is the source of the creaky noise. That building used to belong to a wizard which disappeared months ago. About two weeks ago, there was a sound coming from the underground of that building. Some bold youth went to check the situation, but none of them came back. Everyone in the village is in a panic right now. I really hope you can help us.";
    private string chieftext2 = "There is a training ground in this village, you can practice a little bit before your adventure.You can go to the wizard’s house whenever you are ready. ";
    private string warriortext1 = "Warriors: You want to practice your sword skill?";
    private string warriortext2 = "W: front\nS: back\nA: left\nD: right\nW/S/A/D + Q: run\nV: front row\nF: attack\n";
    private string dungeonenter = "Here is the dungeon";
    private string skeletonevent1 = "The skeleton is revived!";
    private string battlehit = "Try to use the back flip to trigger the perfect dodge. If you dodged at the time of the opponent’s attack, you will enter a bullet time that the time is slowed and your attack is not.";
    private string skeletonevent2 = "Suddenly there is a big noise coming from the other side of the hall! All the skeletons are awake!";
    private string allclear = "A room in the dungeon seems to have been opened. Have a look.";
    private string diary1 = "Research Diary:\nDay 1:\nThis is the perfect place for my research. So many people have died here. Tons of skeleton provided for me! I will start the research tomorrow.";
    private string diary2 = "Day 10:\nThe research went pretty well, because the people are killed by magic creatures, their skeletons are more suitable for this experiment.";
    private string diary3 = "Day 22:\nFinally, the skeleton can react to stand up when there are people around close. And a new finding today, the process seems attractive to the magic creatures. There are some blood eifs that try to snitch into this dungeon whenever I was doing my research.";
    private string diary4 = "Day 45:\nThey can now do the basic attack. The one last thing is to invest on how to control this creature.";
    private string healmagic = "Oh, it's healing magic!\neverything is done here. it is time to leave";
    private string battlehit1 = "Battle hint for dragon\n1,The dragon is very aggressive, you may have no chance to attack it without a perfect dodge.\n2,The dragon’s skin is very hard, but its head is weak.\n3,The backflip can trigger perfect dodge, but move just a little, And row cannot dodge the attack, but move longer. Using them carefully.\n4. You can press H to use the heal magic to increase the health.";

    void Start()
    {
        if(guardianhandle != null ){
            guardiancont = guardianhandle.GetComponent<guardiancontroller>();
        }
        if(leaderhandle != null){
            leaderCont = leaderhandle.GetComponent<leadercontroller>();
        }
        if(warrior != null){
            WarriorCont = warrior.GetComponent<warriorcontroller>();
        }
        if(skeleton != null){
            skeletonCont = skeleton.GetComponent<enemycontroller>();
        }
        if(skeleton1 != null){
            skeletonCont1 = skeleton1.GetComponent<enemycontroller>();
        }
        if(skeleton2 != null){
            skeletonCont2 = skeleton2.GetComponent<enemycontroller>();
        }
        if(skeleton3 != null){
            skeletonCont3 = skeleton3.GetComponent<enemycontroller>();
        }
        if(skeleton4 != null){
            skeletonCont4 = skeleton4.GetComponent<enemycontroller>();
        }
        if(book != null ){
            Readbook = book.GetComponent<readbook>();
        }

        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnClick(){
        if(chatmessage.text == guardiantext2){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
            guardiancont.ischating = false;
        } 
        else if(chatmessage.text == guardiantext1){
            chatmessage.text = guardiantext2;
        }
        else if(chatmessage.text == chieftext2){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
            leaderCont.ischating = false;
        }
        else if(chatmessage.text == chieftext1){
            chatmessage.text = chieftext2;
        }
        else if(chatmessage.text == warriortext2){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
            WarriorCont.ischating = false;
        }
        else if(chatmessage.text == warriortext1){
            chatmessage.text = warriortext2;
        }
        else if(chatmessage.text == dungeonenter){
            Time.timeScale = 1;
            SceneManager.LoadScene(2);
        }
        else if(chatmessage.text == battlehit){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
            skeletonCont.wakeup = true;
        }
        else if(chatmessage.text == skeletonevent1){
            chatmessage.text = battlehit;
        }
        else if(chatmessage.text == skeletonevent2){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
            skeletonCont1.wakeup = true;
            skeletonCont2.wakeup = true;
            skeletonCont3.wakeup = true;
            skeletonCont4.wakeup = true;
        }
        else if(chatmessage.text == allclear){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
            door1.transform.localEulerAngles=new Vector3(-90f,-90f,0);
            door2.transform.localEulerAngles=new Vector3(-90f,90f,0);
        }
        else if(chatmessage.text == diary4){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
            Readbook.ischating = false;
        }
        else if(chatmessage.text == diary3){
            chatmessage.text = diary4;
        }
        else if(chatmessage.text == diary2){
            chatmessage.text = diary3;
        }
        else if(chatmessage.text == diary1){
            chatmessage.text = diary2;
        }
        else if(chatmessage.text == healmagic){
            SceneManager.LoadScene(3);
        }
        else if(chatmessage.text == "you are died, please press the button to play again!"){
            if(SceneManager.GetActiveScene().buildIndex == 2){
                SceneManager.LoadScene(2);
            }
            else{
                SceneManager.LoadScene(3);
            }
        }
       
        else if(chatmessage.text =="Perfect Dodge:\nWhen you dodge from the enemy at the time of the attack, you will trigger the perfect dodge."){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
            anotherbook.ischating = false;
        }
        else if(chatmessage.text == "Skeleton Soldiers:Mix the spider potion with ________. Then pour the potion on the skeleton. __________ you will get the skeleton soldiers."){
            chatmessage.text = "Perfect Dodge:\nWhen you dodge from the enemy at the time of the attack, you will trigger the perfect dodge.";
        }
        else if(chatmessage.text == "The game is stopped, you can press continue to play game!"){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
            playerinput.ispaused = false;
        }
        else if( chatmessage.text == "Dungeon Introduction: It’s brighter than I think. But what is that weird smell? It’s actually pretty quiet, and there is no strange sound as the chief said. Let's walk around.\nYour goal is clear all enemy here and find out what happne here."){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
        }
        else if(chatmessage.text == "W: front\nS: back\nA: left\nD: right\nW/S/A/D + Q: run\nE: talk with npc"){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
        }
        else if( chatmessage.text == "Village introduction: You are now at XX village. It’s located on the border of XXX empire. Because of its remoteness, there is no person here that can exert the magic. Many people have been killed by the magic creatures. Therefore, the villagers built huge walls to keep out the magic creatures around them."){
            chatmessage.text = "W: front\nS: back\nA: left\nD: right\nW/S/A/D + Q: run\nE: talk with npc";
        }
        else if( chatmessage.text == battlehit1){
            Time.timeScale = 1;
            Cursor.visible = false;
            chat.gameObject.SetActive(false);
        }
        else if(chatmessage.text == "Not a long time after you entered that building, the ground began to shake. A fireball hits the church. Then this dragon flies here and destroys everything."){
            chatmessage.text = battlehit1;
        }
        else if(chatmessage.text == "Congratulations! You defeat the dragon. You say goodbye to the village, and start on a new journey. To be continued. Press continue to back to the menu"){
            SceneManager.LoadScene(0);

        }
    }
}
