using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{

    public void SelectM(int sk)
    {
        SceneManager.LoadScene(sk);
    }
}
