using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class precmrmove : MonoBehaviourPunCallbacks
{
    public PhotonView PV;
    public PhotonView PPV;
    public GameObject playbox;
    public GameObject pb;
    public GameObject precmr;
    public GameObject center;
    public float zoomspeed = 10f;
    private AudioListener al;

    float looksen = -2f;
    float cmry = 0;
    float yp = 1.65f;

    void Start()
    {
        Debug.Log(playbox.GetComponent<PhotonView>().ViewID/1000+"");
        precmr = playbox.transform.GetChild(0).gameObject;
        precmr.SetActive(true);
        al = precmr.GetComponent<AudioListener>();
        al.enabled = true;
    }

    void Update()    
    {
        pb = GameObject.FindWithTag(playbox.GetComponent<PhotonView>().ViewID/1000+"");
        PPV = pb.gameObject.GetComponent<PhotonView>();
        if ( PV.IsMine && PPV.IsMine )
        {
            if (Input.GetKey(KeyCode.N)) Debug.Log("ppv is mine");
            playbox.transform.position = new Vector3(pb.transform.position.x, pb.transform.position.y+yp, pb.transform.position.z);
            string name = "dogp(Clone)";
            if (pb.gameObject.name == name)
                mousemove();
            else
                mousemove2();
        }
        else
        {
            precmr.SetActive(false);
            al.enabled = false;
        }
        
        // zoom();
    }

    void mousemove()
    {
        float yrotation = Input.GetAxis("Mouse X") * looksen;
        cmry += yrotation;

        playbox.transform.localEulerAngles = new Vector3(0, -cmry, 0);
        pb.transform.localEulerAngles = new Vector3(0, -cmry +90, 0);
    }

    void mousemove2()
    {
        float yrotation = Input.GetAxis("Mouse X") * looksen;
        cmry += yrotation;

        playbox.transform.localEulerAngles = new Vector3(0, -cmry, 0);
        pb.transform.localEulerAngles = new Vector3(0, -cmry, 0);
    }

    // void zoom()
    // {
    //     float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomspeed;
    //     if (distance != 0){
    //         precmr.fieldOfView += distance;
    //     }
    // }

}