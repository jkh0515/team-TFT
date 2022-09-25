using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject intro;
    public GameObject mainsc;
    public GameObject loading;
    public GameObject bt;
    public GameObject fordog;
    
    private int endtimer = 100000;

    void Awake()
    {
        Screen.SetResolution(960, 540, false);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
        bt.SetActive(false);
        intro.SetActive(true);
        mainsc.SetActive(false);
        loading.SetActive(false);
        fordog.SetActive(false);
    }

    public void Connect() {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("connect room");

        Invoke("bton",0.5f);
    }  

    void bton() => bt.SetActive(true);


    public void humanroom()
    {
        intro.SetActive(false);
        mainsc.SetActive(false);
        fordog.SetActive(false);
        loading.SetActive(true);
        PhotonNetwork.CreateRoom("tft", new RoomOptions { MaxPlayers = 2 });
        // PhotonNetwork.JoinRoom("tft");
        Invoke("createhuman",3f);

    }

    void createhuman()
    {
        intro.SetActive(false);
        loading.SetActive(false);
        mainsc.SetActive(true);
        fordog.SetActive(false);
        PhotonNetwork.Instantiate("humanp", new Vector3(9,0,-18), Quaternion.identity);
        PhotonNetwork.Instantiate("cleaner", new Vector3(5,0,16), Quaternion.identity);
        PhotonNetwork.Instantiate("mop",new Vector3(5.832f,-0.1f,-5.75f), Quaternion.identity);
        PhotonNetwork.Instantiate("soap",new Vector3(4.8f ,1, 13), Quaternion.identity);
        PhotonNetwork.Instantiate("cmrp", new Vector3(0,0,0), Quaternion.identity);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void dogroom()
    {
        intro.SetActive(false);
        mainsc.SetActive(false);
        loading.SetActive(true);
        fordog.SetActive(false);
        PhotonNetwork.JoinRoom("tft");
        // PhotonNetwork.CreateRoom("tft", new RoomOptions { MaxPlayers = 2 });
        Invoke("createdog",3f);
    }

    void createdog() 
    {
        intro.SetActive(false);
        loading.SetActive(false);
        mainsc.SetActive(true);
        fordog.SetActive(true);
        PhotonNetwork.Instantiate("dogp", new Vector3(-15,0,15), Quaternion.identity);
        PhotonNetwork.Instantiate("cmrp", new Vector3(0,0,0), Quaternion.identity);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        intro.SetActive(true);
        mainsc.SetActive(false);
        fordog.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PhotonNetwork.IsConnected) PhotonNetwork.Disconnect();
        // if (PhotonNetwork.IsConnected) playercheck(); else online.text = "offline";
        endtimer --;
        if(endtimer < 0)
            endtimer = 0;
        if(endtimer == 0)
        {
            intro.SetActive(true);
            mainsc.SetActive(false);
            fordog.SetActive(false);

        }
    }

}
