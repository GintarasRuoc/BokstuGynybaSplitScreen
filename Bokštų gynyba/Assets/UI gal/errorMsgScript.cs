using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class errorMsgScript : MonoBehaviour
{
    public GameObject err1;
    public GameObject err2;
    float timeSpeed = 2f;
    float lastTimestamp;

    public void occupied(Player p)
    {
        err1.gameObject.SetActive(true);
        StartCoroutine(LateCall());
    }

    public void NotEnoughMoney()
    {
        err2.gameObject.SetActive(true);
        StartCoroutine(LateCall());
        Debug.Log("nEUZTENKA PiniGu");
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(4);
        err1.gameObject.SetActive(false);
        err2.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
