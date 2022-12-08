using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    MeshRenderer m;
    [SerializeField]
    private GameObject Futuristic_soldier;
    private GameObject bone;
    private GameObject hand;
    public GameObject primary;
    public Sk_AR_Stats AR;
    public HandGun_Stats handGun;
    public int equipped=1;
    [SerializeField]
   public  GameObject secondary;
    public float x, y, z;
    public float alpha, beta, gamma;
    Transform perso;
    Transform pistol;
    Transform main;

    Vector3 rotationVector;
    
    // Start is called before the first frame update
    void Start()
    {
        //perso = GameObject.Find("Perso").GetComponent<Transform>();
        //pistol = GameObject.Find("Pistol").GetComponent<Transform>();
        primary = GameObject.Find("SK_AR_01");
        secondary = GameObject.Find("SK_Handgun_03");
        AR = GameObject.Find("SK_AR_01").GetComponent<Sk_AR_Stats>();
        handGun = GameObject.Find("SK_Handgun_03").GetComponent<HandGun_Stats>();
        bone = Futuristic_soldier.transform.Find("root/root.x/spine_01.x/spine_02.x/spine_03.x/shoulder.r/arm_stretch.r/forearm_stretch.r/hand.r").gameObject;
        //main = GameObject.Find("M4").GetComponent<Transform>();
        
        //rotationVector.x = pistol.rotation.eulerAngles.x; ;
        //rotationVector.y = pistol.rotation.eulerAngles.y; ;
        //rotationVector.z = pistol.rotation.eulerAngles.z; ;
        //rotationVector = transform.rotation.eulerAngles;

    }

    public int getEquipped()
    {
        return equipped;
    }
    // Update is called once per frame
    void Update()
    {
        //Vector3 ARPos = new Vector3(0.0357f, 0.1814f, -0.0194f);
        //Quaternion ARRot = new Quaternion(-10.014f, 118.981f, 135.639f, 0f);
        



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            equipped = 1;
            primary.transform.parent = bone.transform;
            primary.SetActive(true);
            primary.transform.localPosition = AR.PickUpPos;
            primary.transform.localRotation = AR.PickUpRot;
            secondary.SetActive(false);
            /*x = pistol.position.x;
            y = pistol.position.y;
            z = pistol.position.z;
            pistol.transform.position = new Vector3(main.position.x, main.position.y, main.position.z);
            main.transform.position = new Vector3(x,y,z);
            //pistol.transform.rotation = Quaternion.Euler(rotationVector);
            // main.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            pistol.transform.Rotate(rotationVector, Space.Self);
            main.transform.Rotate(-rotationVector,Space.Self);*/

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equipped = 2;
            secondary.transform.parent = bone.transform;
            secondary.transform.localPosition = handGun.PickUpPos;
           secondary.transform.localRotation = handGun.PickUpRot;
            // secondary.transform.localPosition = handgunPos;
            //secondary.transform.localRotation = handgunRot;
            primary.SetActive(false);
            secondary.SetActive(true);
            /*x = pistol.position.x;
            y = pistol.position.y;
            z = pistol.position.z;
            
            pistol.transform.position = new Vector3(main.position.x, main.position.y, main.position.z);
            main.transform.position = new Vector3(x, y, z);
            main.transform.Rotate(rotationVector, Space.Self);
            pistol.transform.Rotate(-rotationVector, Space.Self);*/

        }
    }
}
