using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class foodtest : MonoBehaviourPunCallbacks
{

    public PhotonView PV;
    private GameObject food1;
    private GameObject food2;
    private GameObject food3;
    private GameObject food4;
    private GameObject food5;
    private GameObject food6;
    private GameObject food7;
    private GameObject food8;
    private GameObject food9;
    private GameObject food10;
    public GameObject dog;
    private GameObject fordogui;
    private Text foodt;
    private Text foodoutt;
    private Text drinkt;
    private Text drinkoutt;
    // private GameObject pee;

    private int food = 0;
    private int foodout  = 0;
    private int drink = 0;
    private int drinkout = 0;
    private int peetimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(PV.IsMine)
        {
            food1 = GameObject.Find("Donut");
            food2 = GameObject.Find("Bread");
            food3 = GameObject.Find("Banana");
            food4 = GameObject.Find("Tomato");
            food5 = GameObject.Find("Pizza");
            food6 = GameObject.Find("HotDog");
            food7 = GameObject.Find("Burger");
            food8 = GameObject.Find("Drink_01");
            food9 = GameObject.Find("Drink_02");
            food10 = GameObject.Find("Drink_03");
            foodt = GameObject.Find("food").GetComponent<Text>();
            foodoutt = GameObject.Find("foodout").GetComponent<Text>();
            drinkt = GameObject.Find("drink").GetComponent<Text>();
            drinkoutt = GameObject.Find("drinkout").GetComponent<Text>();
        }
    }

    private int discheck(GameObject one, GameObject two)
    {
        float dis = Vector3.Distance(one.transform.position,two.transform.position);
        return (int)dis;
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (discheck(dog,food1) < 2)
                {
                    food1.SetActive(false);
                    food = food + 1;
                }
                if (discheck(dog,food2) < 2)
                {
                food2.SetActive(false);
                food = food + 1;
                }
                if (discheck(dog,food3) < 2)
                {
                food3.SetActive(false);
                food = food + 1;
                }
                if (discheck(dog,food4) < 2)
                {
                food4.SetActive(false);
                food = food + 1;
                }
                if (discheck(dog,food5) < 2)
                {
                food5.SetActive(false);
                food = food + 1;
                }
                if (discheck(dog,food6) < 2)
                {
                food6.SetActive(false);
                food = food + 1;
                }
                if (discheck(dog,food7) < 2)
                {
                food7.SetActive(false);
                food = food + 1;
                }
                if (discheck(dog,food8) < 2)
                {
                food8.SetActive(false);
                drink = drink + 1;
                }
                if (discheck(dog,food9) < 2)
                {
                food9.SetActive(false);
                drink = drink + 1;
                }
                if (discheck(dog,food10) < 2)
                {
                food10.SetActive(false);
                drink = drink + 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.C) && food > foodout)
            {
                GameObject poo = PhotonNetwork.Instantiate("poo",new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                foodout = foodout + 1;
            }
            if (Input.GetKeyDown(KeyCode.V) && drink > drinkout)
            {
                peetimer = 100;
                drinkout = drinkout + 1;
            }
            foodt.text = "먹은 음식 : " + food;
            drinkt.text = "마신 음료 : " + drink;
            foodoutt.text = "배출한 음식 : " + foodout;
            drinkoutt.text = "배출한 음료 : " + drinkout;  
        }
        else
        {
            // food1.SetActive(false);
            // food2.SetActive(false);
            // food3.SetActive(false);
            // food4.SetActive(false);
            // food5.SetActive(false);
            // food6.SetActive(false);
            // food7.SetActive(false);
            // food8.SetActive(false);
            // food9.SetActive(false);
            // food10.SetActive(false);
        }
        if (peetimer > 0)
        {
            peetimer = peetimer -1;
            GameObject pee = PhotonNetwork.Instantiate("pee",new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        if (peetimer < 0)
            peetimer = 0;
    }

    // private void OnCollisionEnter(Collision col)
    // {
    //     if(col.gameObject.tag == "mop")
    //     {
    //         Debug.Log("mop");
    //         Destroy(pee);
    //     }
    // }
}
