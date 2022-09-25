using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class furniture : MonoBehaviourPunCallbacks
{
    public int checkdis = 3;
    public GameObject human;
    public GameObject dog;
    public GameObject refri;
    public GameObject refridu;
    public GameObject refridd;
    public GameObject drawer;
    public GameObject drawerone;
    public GameObject drawertwo;
    public GameObject drawerthree;
    public GameObject drawer2;
    public GameObject drawerone2;
    public GameObject drawertwo2;
    public GameObject drawerthree2;
    public GameObject drawer3;
    public GameObject drawerdo;
    public GameObject drawerdt;
    public GameObject drawer4;
    public GameObject drawerdo2;
    public GameObject drawerdt2;
    public GameObject closet;
    public GameObject closetd;
    public GameObject closet2;
    public GameObject closetd2;
    public PhotonView HPV;
    public PhotonView DPV;

    private bool refrionoff = false;
    private bool draweronoff = false;
    private bool draweronoff2 = false;
    private bool draweronoff3 = false;
    private bool draweronoff4 = false;
    private bool closetonoff = false;
    private bool closetonoff2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private int discheck(GameObject one, GameObject two)
    {
        float dis = Vector3.Distance(one.transform.position,two.transform.position);
        return (int)dis;
    }

    private void optf(bool tf) { tf = !tf; }
    
    // Update is called once per frame
    void Update()
    {
        human = GameObject.Find("humanp(Clone)");
        dog = GameObject.Find("dogp(Clone)");
        HPV = human.gameObject.GetComponent<PhotonView>();
        DPV = dog.gameObject.GetComponent<PhotonView>();
        if (Input.GetKeyDown("e"))
        {
            if ((discheck(dog,refri) < checkdis && DPV.IsMine) || (discheck(human,refri) < checkdis && HPV.IsMine)) 
            {
                if(refrionoff == false) 
                {
                    refridu.transform.rotation = Quaternion.Slerp(refridu.transform.rotation,Quaternion.Euler(0, 0f, 0),1f);
                    refridd.transform.rotation = Quaternion.Slerp(refridd.transform.rotation,Quaternion.Euler(0, 0f, 0),0.9f);
                    refrionoff = true;
                }
                else
                {
                    refridu.transform.rotation = Quaternion.Slerp(refridu.transform.rotation,Quaternion.Euler(0, 90f, 0),1f);
                    refridd.transform.rotation = Quaternion.Slerp(refridd.transform.rotation,Quaternion.Euler(0, 90f, 0),1f);
                    refrionoff = false; 
                }
            }
            if ((discheck(dog,drawer) < checkdis && DPV.IsMine) || (discheck(human,drawer) < checkdis && HPV.IsMine))
            {
                if(draweronoff == false)
                {
                    drawerone.transform.Translate(new Vector3(-0.76f,0,0));
                    drawertwo.transform.Translate(new Vector3(-0.27f,0,0));
                    drawerthree.transform.Translate(new Vector3(-0.41f,0,0));
                    draweronoff = true;      
                }
                else
                {
                    drawerone.transform.Translate(new Vector3(0.76f,0,0));
                    drawertwo.transform.Translate(new Vector3(0.27f,0,0));
                    drawerthree.transform.Translate(new Vector3(0.41f,0,0));
                    draweronoff = false;
                }
            }
            if ((discheck(dog,drawer2) < checkdis && DPV.IsMine) || (discheck(human,drawer2) < checkdis && HPV.IsMine))
            {
                if(draweronoff2 == false)
                {
                    drawerone2.transform.Translate(new Vector3(-0.76f,0,0));
                    drawertwo2.transform.Translate(new Vector3(-0.27f,0,0));
                    drawerthree2.transform.Translate(new Vector3(-0.41f,0,0));
                    draweronoff2 = true;      
                }
                else
                {
                    drawerone2.transform.Translate(new Vector3(0.76f,0,0));
                    drawertwo2.transform.Translate(new Vector3(0.27f,0,0));
                    drawerthree2.transform.Translate(new Vector3(0.41f,0,0));
                    draweronoff2 = false;
                }
            }
            if ((discheck(dog,drawer3) < checkdis && DPV.IsMine) || (discheck(human,drawer3) < checkdis && HPV.IsMine))
            {
                if(draweronoff3 == false)
                {
                    drawerdo.transform.rotation = Quaternion.Slerp(drawerdo.transform.rotation,Quaternion.Euler(0, 120f, 0),1f);
                    drawerdt.transform.rotation = Quaternion.Slerp(drawerdt.transform.rotation,Quaternion.Euler(0, -110f, 0),1f);
                    draweronoff3 = true;
                }
                else
                {
                    drawerdo.transform.rotation = Quaternion.Slerp(drawerdo.transform.rotation,Quaternion.Euler(0, 0, 0),1f);
                    drawerdt.transform.rotation = Quaternion.Slerp(drawerdt.transform.rotation,Quaternion.Euler(0, 0, 0),1f);
                    draweronoff3 = false;
                }
            }
            if ((discheck(dog,drawer4) < checkdis && DPV.IsMine) || (discheck(human,drawer4) < checkdis && HPV.IsMine))
            {
                if(draweronoff4 == false)
                {
                    drawerdo2.transform.rotation = Quaternion.Slerp(drawerdo2.transform.rotation,Quaternion.Euler(0, 120f, 0),1f);
                    drawerdt2.transform.rotation = Quaternion.Slerp(drawerdt2.transform.rotation,Quaternion.Euler(0, -110f, 0),1f);
                    draweronoff4 = true;
                }
                else
                {
                    drawerdo2.transform.rotation = Quaternion.Slerp(drawerdo2.transform.rotation,Quaternion.Euler(0, 0, 0),1f);
                    drawerdt2.transform.rotation = Quaternion.Slerp(drawerdt2.transform.rotation,Quaternion.Euler(0, 0, 0),1f);
                    draweronoff4 = false;
                }
            }
            if ((discheck(dog,closet) < checkdis && DPV.IsMine) || (discheck(human,closet) < checkdis && HPV.IsMine))
            {
                if(closetonoff == false)
                {
                    closetd.transform.Translate(new Vector3(0,0,-1f));
                    closetonoff = true;
                }
                else
                {
                    closetd.transform.Translate(new Vector3(0,0,1f));
                    closetonoff = false;
                }
            }
            if ((discheck(dog,closet2) < checkdis && DPV.IsMine) || (discheck(human,closet2) < checkdis && HPV.IsMine))
            {
                if(closetonoff2 == false)
                {
                    closetd2.transform.Translate(new Vector3(0,0,-1f));
                    closetonoff2 = true;
                }
                else
                {
                    closetd2.transform.Translate(new Vector3(0,0,1f));
                    closetonoff2 = false;
                }
            }
        }
    }
}
