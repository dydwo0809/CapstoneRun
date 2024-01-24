using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public  float runSpeed;
    public float jumpPower;
    int jumpCount = 0;
    bool isDoubleJump;

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
        col = GetComponent<CapsuleCollider> ();
    }

    // Update is called once per frame
    void Update()
    {
        // Jump and Double Jump
        if(Input.GetButtonDown("Jump") && jumpCount < 2){
            jumpCount++;
            myRigid.velocity = Vector3.zero;
            myRigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            PlaySound("JUMP");
        }
    }

    void FixedUpdate(){
        // Control
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        anim.SetFloat ("Speed", h);
        
        moveVec = new Vector3(h,0,0).normalized;
        
        transform.position += moveVec * runSpeed * Time.deltaTime;

        transform.LookAt(transform.position + moveVec);
        
        if (Input.GetButtonDown ("Jump")) {
            if (!anim.IsInTransition (0)) {
                myRigid.AddForce (Vector3.up * jumpPower, ForceMode.VelocityChange);
                anim.SetBool ("Jump", true);
            }
        }
    }

    void OnCollisionEnter(Collision collision){
        // 땅에 닿아 있는지(여기선 Plane)
        if(collision.contacts[0].normal.y > 0.7f){
            Debug.Log("Coasclasclasc");
            jumpCount = 0; 
            anim.SetBool("Jump", false);
            PlaySound("LANDING");
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
