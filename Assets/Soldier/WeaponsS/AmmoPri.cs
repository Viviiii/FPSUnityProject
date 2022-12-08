using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class AmmoPri : MonoBehaviour
{
    public Text txt;
  
   // public Font police;
    
    M4A1_Shoot M4A1_mun;
   
    
    // Start is called before the first frame update
    void Start()
    {
        M4A1_mun = GameObject.Find("Eject_AR").GetComponent<M4A1_Shoot>();
        txt = GameObject.Find("TextPri").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.fontSize = 24;
        txt.text = M4A1_mun.magazine + "/" + M4A1_mun.ammo;

    }
}
