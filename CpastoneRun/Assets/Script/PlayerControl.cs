using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float jumpPower;
    bool isJump;
    bool isDoubleJump;

    public AudioClip audioRun;
    public AudioClip audioJump;
    public AudioClip audioItem;
    public AudioClip audioDie;
    public AudioClip audioFinish;
    public AudioClip audioLanding;

    private Rigidbody myRigid;
    AudioSource audioSource;


    void Start()
    {
        isJump = false;
        myRigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Jump
        if(Input.GetButtonDown("Jump") && !isJump){
            isJump = true;
            myRigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            PlaySound("JUMP");
        }
        // DoubleJump
        if(Input.GetButtonDown("Jump") && isJump && !isDoubleJump){
            isDoubleJump = true;
            myRigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            PlaySound("JUMP");
        }
    }

    void FixedUpdate(){
        // Control
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        myRigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision){
        // 땅에 닿아 있는지(여기선 Plane)
        if(collision.gameObject.name == "Plane"){
            isJump = false;
            isDoubleJump = false;
        }
    }

    // PlayerBoard
    void PlaySound(string action){
        switch(action){
            case "JUMP":
                audioSource.clip = audioJump;
                break;
            case "RUN":
                audioSource.clip = audioRun;
                break;
            case "ITEM":
                audioSource.clip = audioItem;
                break;
            case "DIE":
                audioSource.clip = audioDie;
                break;
            case "FINISH":
                audioSource.clip = audioFinish;
                break;
            case "LANDING":
                audioSource.clip = audioLanding;
                break;
        }
    }
}
