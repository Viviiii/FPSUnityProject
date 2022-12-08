using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class AmmoGre : MonoBehaviour
{
    public Text txt;
    M4A1_Shoot mun_gre;

    // public Font police;

    M4A1_Shoot M4A1_mun;


    // Start is called before the first frame update
    void Start()
    {
        
        txt = GameObject.Find("TextGre").GetComponent<Text>();
        mun_gre = GameObject.Find("SK_AR_02").GetComponent<M4A1_Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.fontSize = 24;
        txt.text = mun_gre.grenades + "/2";

    }
}
