using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrIntro : MonoBehaviour
{
    public float tempo;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("cena", tempo);
    }

    void cena()
    {
        SceneManager.LoadScene(1);
    }
}
