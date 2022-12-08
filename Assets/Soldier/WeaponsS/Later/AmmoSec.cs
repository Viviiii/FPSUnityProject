using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AmmoSec : MonoBehaviour
{
 
    public Text txt;
    // public Font police;
    SwapWeapon weap;
   
    Pistol_Shoot Beretta_mun;
    private int ammo = 13;

    // Start is called before the first frame update
    void Start()
    {
       
        Beretta_mun = GameObject.Find("EjectP").GetComponent<Pistol_Shoot>();
       // weap = GameObject.Find("Perso").GetComponent<SwapWeapon>();
        //txt = GameObject.Find("Text").GetComponent<Text>();
        txt = GameObject.Find("TextSec").GetComponent<Text>();


        // text = GetComponent<Text>();
        //GameObject.Find("Text").GetComponent<GUIText>().text = "New text";
        // text1 = GetComponent<Text1>();
        // text.text = M4A1_mun.magazine + "/" + M4A1_mun.ammo;
        //text1.text = Beretta_mun.magazine + "/" + Beretta_mun.ammo;
    }

    // Update is called once per frame
    void Update()
    {
        txt.fontSize = 24;
        txt.text = Beretta_mun.magazine + "/" + Beretta_mun.ammo;

       /* if (weap.secondary.activeSelf == true)
        {
            

        }*/

    }
}
