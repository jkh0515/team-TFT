using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class dogmove : MonoBehaviourPunCallbacks
{
    public PhotonView PV;
    public float speed = 20;
    public GameObject playbox;
    public GameObject center;
    bool bw = false;
    bool ba = false;
    bool bs = false;
    bool bd = false;
    bool bspace = false;
    private Rigidbody rb;
    private Animator ani;

    float looksen = -2f;
    float cmry = 0;

    void Awake()
    {

    }

    void Start()
    {
        rb = playbox.gameObject.GetComponent<Rigidbody>();  
        ani = playbox.GetComponent<Animator>();
    }

    void Update()
    {
        animationmove();
        //precmr.transform.position = new Vector3(playbox.transform.position.x, playbox.transform.position.y, playbox.transform.position.z);

        playbox.gameObject.tag = playbox.GetComponent<PhotonView>().ViewID/1000+"";
        // Actnum.text = PhotonNetwork.LocalPlayer.ActorNumber+"";

        if (Input.GetKey(KeyCode.W) && PV.IsMine) {
            rb.AddForce(center.gameObject.transform.forward * 3 * speed);
            bw = true;
        }
        else bw = false;
        if (Input.GetKey(KeyCode.A) && PV.IsMine) {
            rb.AddForce(center.gameObject.transform.right * -3 * speed);
            ba = true;
        }
        else ba = false;
        if (Input.GetKey(KeyCode.S) && PV.IsMine) {
            rb.AddForce(center.gameObject.transform.forward * -3 * speed);
            bs = true;
        }
        else bs = false;
        if (Input.GetKey(KeyCode.D) && PV.IsMine) {
            rb.AddForce(center.gameObject.transform.right * 3 * speed);
            bd = true;
        }
        else bd = false;

        if (ba == true && bs == true && PV.IsMine){
            playbox.transform.rotation = Quaternion.Slerp(playbox.transform.rotation,Quaternion.Euler(0, -135.0f, 0),0.1f);
            speed = 14f;}
        else if (bs == true && bd == true && PV.IsMine){
            playbox.transform.rotation = Quaternion.Slerp(playbox.transform.rotation,Quaternion.Euler(0, 135.0f, 0),0.1f);
            speed = 14f;}
        else if (bd == true && bw == true && PV.IsMine){
            playbox.transform.rotation = Quaternion.Slerp(playbox.transform.rotation,Quaternion.Euler(0, 45.0f, 0),0.1f);
            speed = 14f;}
        else if (bw == true && ba == true && PV.IsMine){
            playbox.transform.rotation = Quaternion.Slerp(playbox.transform.rotation,Quaternion.Euler(0, -45.0f, 0),0.1f);
            speed = 14f;}
        else {
            speed = 20f;
            if (bw == true && PV.IsMine) playbox.transform.rotation = Quaternion.Slerp(playbox.transform.rotation,Quaternion.Euler(0, 0, 0),0.1f);
            if (ba == true && PV.IsMine) playbox.transform.rotation = Quaternion.Slerp(playbox.transform.rotation,Quaternion.Euler(0, -90.0f, 0),0.1f);
            if (bs == true && PV.IsMine) playbox.transform.rotation = Quaternion.Slerp(playbox.transform.rotation,Quaternion.Euler(0, 180.0f, 0),0.1f);
            if (bd == true && PV.IsMine) playbox.transform.rotation = Quaternion.Slerp(playbox.transform.rotation,Quaternion.Euler(0, 90.0f, 0), 0.1f);
        }
    }

    void animationmove()
    {
        if(PV.IsMine){
            if (bw == true || ba == true || bs == true || bd == true)
                ani.SetBool("walk", true);
            else ani.SetBool("walk", false);
        }
    }

    // void mousemove()
    // {
    //     float yrotation = Input.GetAxis("Mouse X") * looksen;
    //     cmry += yrotation;

    //     precmr.transform.localEulerAngles = new Vector3(0, -cmry, 0);
    //     playbox.transform.localEulerAngles = new Vector3(0, -cmry, 0);
    // }

}