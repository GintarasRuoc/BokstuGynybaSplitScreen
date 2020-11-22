using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUIScript : MonoBehaviour
{
    public Text waveNr;
    public Text timeLeft;

    public WaveSpawner ws;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        waveNr.text = string.Format("{0}", ws.waveNumber-1);
        timeLeft.text = string.Format("{0}", ws.countDown);
    }
}
