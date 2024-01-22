using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float runSpeed;
    public float jumpPower;
    bool isJump;
    bool isDoubleJump;
    private Vector3 velocity;

    public AudioClip audioRun;
    public AudioClip audioJump;
    public AudioClip audioItem;
    public AudioClip audioDie;
    public AudioClip audioFinish;
    public AudioClip audioLanding;
    
    private Rigidbody myRigid;
    AudioSource audioSource;
    private Animator anim;
    private CapsuleCollider col;
    static int locoState = Animator.StringToHash ("Base Layer.Locomotion");
    private AnimatorStateInfo currentBaseState;

    void Start()
    {
        isJump = false;
        myRigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator> ();
        col = GetComponent<CapsuleCollider> ();
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
        anim.SetFloat ("Speed", v);						
		anim.SetFloat ("Direction", h);
        
        velocity = new Vector3 (h, 0, v);		
			
		velocity = transform.TransformDirection (velocity);
        if (v > 0.1) {
            velocity *= runSpeed;
        } else if (v < -0.1) {
            velocity *= runSpeed;
        }

        if (Input.GetButtonDown ("Jump")) {            
            if (currentBaseState.nameHash == locoState) {
                if (!anim.IsInTransition (0)) {
                    myRigid.AddForce (Vector3.up * jumpPower, ForceMode.VelocityChange);
                    anim.SetBool ("Jump", true);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision){
        // 땅에 닿아 있는지(여기선 Plane)
        if(collision.gameObject.name == "Plane"){
            Debug.Log("Coasclasclasc");
            isJump = false;
            isDoubleJump = false;
            PlaySound("LANDING");
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
