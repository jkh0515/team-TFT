using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class dogdirt : MonoBehaviourPunCallbacks
{
    public PhotonView DPV;
    public GameObject dog;
    public GameObject dogleg;
    public GameObject dogleg2;
    public GameObject dogleg3;
    public GameObject dogleg4;
    public GameObject dogleg5;

    private Renderer capsule;
    private Renderer capsule2;
    private Renderer capsule3;
    private Renderer capsule4;
    private Renderer capsule5;

    // public GameObject lamp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dog = GameObject.Find("dogp(Clone)");
        DPV = dog.gameObject.GetComponent<PhotonView>();
        dogleg = dog.transform.GetChild(1).gameObject;
        dogleg2 = dog.transform.GetChild(2).gameObject;
        dogleg3 = dog.transform.GetChild(3).gameObject;
        dogleg4 = dog.transform.GetChild(4).gameObject;
        dogleg5 = dog.transform.GetChild(5).gameObject;
        capsule = dogleg.GetComponent<Renderer>();
        capsule2 = dogleg2.GetComponent<Renderer>();
        capsule3 = dogleg3.GetComponent<Renderer>();
        capsule4 = dogleg4.GetComponent<Renderer>();
        capsule5 = dogleg5.GetComponent<Renderer>();
        // if(Input.GetKeyDown(KeyCode.I) && DPV.IsMine);
        //     lamp.transform.Translate(new Vector3(0,-1f,0));
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "dirt")
        {
            // Debug.Log("2");
            capsule.material.color = new Color(99/255f , 65/255f, 21/255f);
            capsule2.material.color = new Color(99/255f , 65/255f, 21/255f);
            capsule3.material.color = new Color(99/255f , 65/255f, 21/255f);
            capsule4.material.color = new Color(99/255f , 65/255f, 21/255f);
            capsule5.material.color = new Color(99/255f , 65/255f, 21/255f);
        }
        if(col.gameObject.tag == "soap")
        {
            capsule.material.color = new Color(251/255f , 174/255f, 90/255f);
            capsule2.material.color = new Color(251/255f , 174/255f, 90/255f);
            capsule3.material.color = new Color(251/255f , 174/255f, 90/255f);
            capsule4.material.color = new Color(251/255f , 174/255f, 90/255f);
            capsule5.material.color = new Color(251/255f , 174/255f, 90/255f);
        }
    }
}
