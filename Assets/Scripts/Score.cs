using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    PlayerStats joueur;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.Find("SK_AR_02").GetComponent<PlayerStats>();
        txt = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = joueur.score +" " ;
    }
}
