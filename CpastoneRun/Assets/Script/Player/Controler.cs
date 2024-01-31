using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Controler : MonoBehaviour
{
    public  float runSpeed;
    public float jumpPower;
    public float gravityPower;
    int jumpCount = 0;
    public float forceGravity;

    Vector3 moveVec;

    public AudioClip audioRun;
    public AudioClip audioJump;
    public AudioClip audioItem;
    public AudioClip audioDie;
    public AudioClip audioFinish;
    public AudioClip audioLanding;

    Rigidbody myRigid;
    Animator anim;
    AudioSource audioSource;
    CapsuleCollider col;

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator> ();
    }

    void Update()
    {
        Physics.gravity = new Vector3(0, -forceGravity, 0);
        // Jump and Double Jump
        if(Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < 2){
            jumpCount++;
            anim.SetBool ("Jump", true);
            myRigid.velocity = Vector3.zero;
            myRigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            PlaySound("JUMP");
        }
    }

    void FixedUpdate(){
        // Control
        float h = Input.GetAxisRaw("Horizontal");

        anim.SetFloat ("Speed", h);
        
        moveVec = new Vector3(h,0,0).normalized;

        // 이동속도
        transform.position += moveVec * runSpeed * Time.deltaTime;

        // 방향키 입력 시 방향 변환, 기본 방향은 앞
        if(Input.GetButton("Horizontal")){
            transform.LookAt(transform.position + moveVec + Vector3.forward);
            //PlaySound("Run");
        }
        else {
            transform.LookAt(transform.position + Vector3.forward);
            //PlaySound("Run");
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){
            myRigid.AddForce(Vector3.down * gravityPower);
        }
    }

    void OnCollisionEnter(Collision collision){
        // 땅에 닿아 있는지(여기선 Plane)
        if(collision.contacts[0].normal.y > 0.7f){
            jumpCount = 0; 
            anim.SetBool("Jump", false);
            //PlaySound("LANDING");
        }
    }

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
        audioSource.Play();
    }
}
