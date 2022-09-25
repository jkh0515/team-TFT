using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class playermove : MonoBehaviourPunCallbacks
{
    public PhotonView PV;
    public float speed = 20;
    private int sppeed = 3;
    public GameObject playbox;
    public GameObject center;
    public GameObject cleaner;
    public GameObject mop;
    public GameObject soap;
    bool bw = false;
    bool ba = false;
    bool bs = false;
    bool bd = false;
    bool bspace = false;
    private Rigidbody rb;
    private Animator ani;
    private bool cleaneronoff = false;
    private bool moponoff = false;
    private bool soaponoff = false;
    private float cmry = 0;
    private float looksen = -2f;

    void Awake()
    {

    }

    private int discheck(GameObject one, GameObject two)
    {
        float dis = Vector3.Distance(one.transform.position,two.transform.position);
        return (int)dis;
    }

    void Start()
    {
        rb = playbox.gameObject.GetComponent<Rigidbody>();  
        ani = playbox.GetComponent<Animator>();
        cleaner = GameObject.Find("cleaner(Clone)");
        mop = GameObject.Find("mop(Clone)");
        soap = GameObject.Find("soap(Clone)");
    }

    void Update()
    {
        animationmove();
        //precmr.transform.position = new Vector3(playbox.transform.position.x, playbox.transform.position.y, playbox.transform.position.z);

        playbox.gameObject.tag = playbox.GetComponent<PhotonView>().ViewID/1000+"";
        // Actnum.text = PhotonNetwork.LocalPlayer.ActorNumber+"";

        if (Input.GetKeyDown(KeyCode.F) && PV.IsMine)
        {
            if(discheck(playbox,cleaner) < 2)
            {
                if(cleaneronoff == false){
                    cleaneronoff = true;}
                else{
                    cleaneronoff = false;}
            }
            if(discheck(playbox,mop) < 2)
            {
                if(moponoff == false){
                    moponoff = true;}
                else{
                    moponoff = false;}
            }
            if(discheck(playbox,soap) < 2)
            {
                if(soaponoff == false){
                    soaponoff = true;}
                else{
                    soaponoff = false;}
            }
        }

        if(cleaneronoff == true){
            cleaner.transform.SetParent(playbox.transform);
            // cleaner.transform.position = new Vector3(playbox.transform.position.x, playbox.transform.position.y, playbox.transform.position.z);
            // cleaner.transform.rotation = playbox.transform.rotation;
        }
        else{
            cleaner.transform.SetParent(null);
            // cleaner.transform.position = new Vector3(5,0,16);
        }
        if(moponoff == true){
            mop.transform.SetParent(playbox.transform);
        }
        else{
            mop.transform.SetParent(null);
        }
        if(soaponoff == true){
            soap.transform.SetParent(playbox.transform);
        }
        else{
            soap.transform.SetParent(null);
        }

        if (Input.GetKey(KeyCode.X)&& PV.IsMine) Debug.Log("ismine");

        if (Input.GetKey(KeyCode.W) && PV.IsMine) {
            rb.AddForce(center.gameObject.transform.forward * sppeed * speed);
            bw = true;
        }
        else bw = false;
        if (Input.GetKey(KeyCode.A) && PV.IsMine) {
            rb.AddForce(center.gameObject.transform.right * -1 * sppeed * speed);
            ba = true;
        }
        else ba = false;
        if (Input.GetKey(KeyCode.S) && PV.IsMine) {
            rb.AddForce(center.gameObject.transform.forward * -1 * sppeed * speed);
            bs = true;
        }
        else bs = false;
        if (Input.GetKey(KeyCode.D) && PV.IsMine) {
            rb.AddForce(center.gameObject.transform.right * sppeed * speed);
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

}