using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;
using UnityEngine;

public class IA : MonoBehaviour
{
    [SerializeField]
    protected Transform Target;
    GamePlay gamePlay;
    //IAHealth health;
    WeaponController weapctrl;
    [SerializeField]
    protected GameObject zombie;
    public List<GameObject> zombiesGO;
    public int Damping = 6;
    PlayerStats joueur;
    protected float gravity = -9.81f;




    public struct zombieS
    {
        private float speed;
        public float HP;
        private float lookAtDistance;
        public bool isAttacking;
        private int chaseRange;
        public  int damage;
        public float attackRate;
        private float moveSpeed;
        private float chaseSpeed;
        private float distance;
        public Vector3 position;
        private Quaternion rotation;

        private zombieS(float HP, float lookAtDistance, int chaseRange, bool isAttacking, float attackRate, float moveSpeed, Vector3 position, int dmg, float speed
            , float chaseSpeed, Quaternion rot, float distance)
        {
            this.HP = 100;
            this.chaseRange = 10;
            //this.isRunning = false;
            this.attackRate = 1.5f;
            this.lookAtDistance = 160f;
            this.moveSpeed = 20f;
            this.isAttacking = false;
            this.damage = dmg;
            this.speed = speed;
            this.chaseSpeed = chaseSpeed;
            this.rotation = rot;
            //To modify
            this.distance = distance;
            this.position = position;
        }

        public Vector3 getPosition()
        {
            return position;
        }

        public float getPositionX()
        {
            return position.x;
        }
        public float getPositionZ()
        {
            return position.z;
        }
        public float getHP()
        {
            return HP;
        }
        public float getMoveSpeed()
        {
            return moveSpeed;
        }

        public Quaternion getRotation()
        {
            return rotation;
        }

        public void setRotation(Vector3 movementDirection)
        {
            Quaternion rot = Quaternion.LookRotation(movementDirection, Vector3.up);
            rotation = rot;
        }
        public bool getIsAttacking()
        {
            return isAttacking;
        }
        public float getLookAtDistance()
        {
            return lookAtDistance;
        }
        public float getDistance()
        {
            return distance;
        }
        
        public void setLookAtDistance(float dis)
        {
            lookAtDistance = dis;
        }
        public void setDistance(Vector3 pos)
        {
            distance = Vector3.Distance(pos,this.getPosition());
        }
        public void setPosition (float moveSpeed, float gravity)
        {
            Vector3 movementDirection;
            Vector3 movementPerSecond;
            movementDirection = new Vector3(Random.Range(-30.0f, 30.0f), 0, Random.Range(-30.0f, 30.0f));
            movementPerSecond = movementDirection * 5;
            position = new Vector3(position.x + (movementPerSecond.x * Time.deltaTime), 0,
            position.z + (movementPerSecond.z * Time.deltaTime));
            position.y -= gravity * Time.deltaTime;
        }

        public void setMoveSpeed(float speed)
        {
            moveSpeed = speed;
        }

        public void setHP(int health)
        {
            HP = health;
        }



    }
    //IA Stats
    // public int lookAtDistance = 20;
    // public bool isAttacking = false;
    // public int chaseRange = 10;
    //public float attackRange = 5;
    // public float moveSpeed = 100f;
    // public float chaseSpeed = 40f;
    // public float attackRate = 1.5f;
    //public int damage = 20;
    public float Distance;
    protected Vector3 movementDirection;
    protected Vector3 movementPerSecond;
    protected float latestDirectionChangeTime;
    protected readonly float directionChangeTime = 5f;

    public int nbrZombies = 5;
    public zombieS[] zombieArray = new zombieS[5];
    public float respawnRate = 3f;

    [SerializeField]
    protected float lookAtDistance;
    protected float chaseRange;


    private Animation zombieAnime;
    public Animator zomb;

    //private CharacterController controller;
    // Vector3 MoveDirection;

    // Start is called before the first frame update
    void Start()
    {

        zombie = GameObject.Find("Zombie");
        zombiesGO = new List<GameObject>();
        for (int i = 0; i < nbrZombies; i++)
        {
             
            respawn(i);
        }

        //zombie = new zombieS();
        /*  zombiesGO.Add(zombie);
        gameObject.AddComponent<IA>();
        zombiesGO.Add(zombie);
        gameObject.AddComponent<IA>();
        zombiesGO.Add(zombie);
        gameObject.AddComponent<IA>();
        zombiesGO.Add(zombie);
        gameObject.AddComponent<IA>();*/
        //attackRate = Time.time;
        //joueur = GameObject.Find("Perso").GetComponent<PlayerStats>();
        //rbz = GameObject.Find("Zombie").GetComponent<Rigidbody>();
        zomb = GetComponent<Animator>();
        latestDirectionChangeTime = 0f;
        weapctrl = GameObject.Find("SK_AR_02").GetComponent<WeaponController>();
        lookAtDistance = 160;
        chaseRange = 50;
        // controller = GameObject.Find("Zombie").GetComponent<CharacterController>();
        //// zombie = gameObject.GetComponent<Animation>();
        FindHealth();
       // calculateNewMovementVector();
        
    }

    protected void calculateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        for(int i=0; i< zombieArray.Length; i++)
        {
            //
            //zombieArray[i].setPosition(zombieArray[i].getMoveSpeed(), gravity);
            
        }
        movementDirection = new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f)).normalized;
        movementPerSecond = movementDirection * 5;
        transform.position = new Vector3(transform.position.x + (movementPerSecond.x * Time.deltaTime), 0,
        transform.position.z + (movementPerSecond.z * Time.deltaTime));
        Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        transform.rotation = rotation;
        //stransform.position.y -= gravity * Time.deltaTime;

    }
    protected void FindHealth()
    {

        Target = GameObject.Find("SK_AR_02").GetComponent<PlayerStats>().transform;
    }

    protected void respawn(int i)
    {
        Vector3 spawnPos = new Vector3(57.5f, 0.2f, 100f);
        zombiesGO.Add(zombie);
        zombie = Instantiate(zombiesGO[i], spawnPos, zombie.transform.rotation);
        //Make them respawn to a diferent place
        zombieArray[i].setPosition(zombieArray[i].getMoveSpeed(), gravity);

        zombiesGO[i].transform.position = zombieArray[i].getPosition();

        //zombies.Add((GameObject)Instantiate(gameObject, transform.position, transform.rotation));
        //zombie.gameObject.AddComponent<IA>();
        //  Instantiate(gameObject, transform.position + new Vector3(4.0F, 0.0F, -1), transform.rotation);

        //respawnRate = Time.time + respawnRate;


    }



    // Update is called once per frame
    void Update()
    {
        if(zombieArray.Length< 5)
        {

            for(int i=0; i< nbrZombies; i++)
            {
                if (zombieArray[i].getHP() <= 0)
                {
                    for(int j = i+1; j < nbrZombies; j++)
                    {
                        zombiesGO[i] = zombiesGO[j];
                        zombieArray[i] = zombieArray[j];
                    }
                }
            }
            respawn(4);
        }
        /*if(nbrZombies < 3)
        {

          respawn();
        }
        if (Distance < lookAtDistance)
        {
            lookAt();

        }
        //For every zombie
        /*for (int i = 0; i < nbrZombies; i++)
        {
            //Distance between player and zombie
            //zombieArray[i].getDistance() = Vector3.Distance(Target.position, zombieArray[i].getMoveSpeed());
            zombieArray[i].setDistance(Target.position);
            //if (zombieS[i].distance > zombieS[i].lookAtDistance)
            //{

            if (Time.time - latestDirectionChangeTime > directionChangeTime && zombieArray[i].getDistance() > zombieArray[i].getLookAtDistance())
            {
                latestDirectionChangeTime = Time.time;
                calculateNewMovementVector();
            }

            else if (zombieArray[i].getDistance() < zombieArray[i].getLookAtDistance())
            {

                movementDirection = new Vector3(Target.position.x - zombieArray[i].position.x, 0, Target.position.z - zombieArray[i].position.z).normalized;
                movementPerSecond = movementDirection * zombieArray[i].getMoveSpeed();
                Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);

                //zombieS[i]..transform.rotation = rotation;
            }

            //}
            if (Distance < chaseRange)
            {
                //chase();
            }
            if (zombieArray[i].getIsAttacking() || zombieArray[i].getHP() < 0)
            {
                zombieArray[i].setMoveSpeed(0f);
                movementPerSecond = movementDirection * zombieArray[i].getMoveSpeed();

            }
            zombieArray[i].setMoveSpeed(20f);
            //zombieArray[i].position = new Vector3(zombieArray[i].position.x + (movementPerSecond.x * Time.deltaTime), 0,
            //zombieArray[i].position.z + (movementPerSecond.z * Time.deltaTime));

            //zombieS[i].transform.position = new Vector3(zombieS[i].transform.position.x + (movementPerSecond.x * Time.deltaTime), 0,
            //zombieS[i].transform.position.z + (movementPerSecond.z * Time.deltaTime));
            //zombiesGO[i].transform.position = zombieArray[i].getPosition();
            //zombiesGO[i].transform.rotation = zombieArray[i].getRotation();


        }*/
        
        void lookAt()
        {
            //Fais tourner l'IA dans la direction du joueur
            /*foreach (GameObject item in zombies)
            {
                Quaternion rotation = Quaternion.LookRotation(Target.position - item.transform.position, Vector3.up);
                //  transform.position = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
                //transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, Time.deltaTime * Damping);
                item.transform.rotation = rotation;
            }*/

        }

        /*void chase()
        {
            foreach (GameObject item in zombies)
            {

                //rbz.velocity = transform.forward * chaseSpeed;
                //item.transform.position = item.transform.position + rbz.velocity * Time.deltaTime;
                //rbz.MovePosition(rbz.position + rbz.velocity * Time.fixedDeltaTime);
                if (!zomb.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack") && !zomb.GetCurrentAnimatorStateInfo(0).IsName("Z_FallingBack") && !zomb.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack"))
                {
                    zomb.Play("Z_Run");
                }
                if (Distance < attackRange)
                {

                    //attack();
                }
            }
            movementDirection = new Vector3(Target.position.x - transform.position.x, 0, Target.position.z - transform.position.z).normalized;
            movementPerSecond = movementDirection * chaseSpeed;
            Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = rotation;
            //Fais bouge le zombie
            // controller.Move(MoveDirection * Time.deltaTime);

        }*/

 
    }
}




    //if the changeTime was reached, calculate a new movement vector
    /* if (Distance > lookAtDistance)
 {
     if (Time.time - latestDirectionChangeTime > directionChangeTime)
     {
         latestDirectionChangeTime = Time.time;
         calculateNewMovementVector();
     }

 }
 else if (Distance < lookAtDistance)
 {
     foreach (GameObject item in zombies)
     {
         movementDirection = new Vector3(Target.position.x - item.transform.position.x, 0, Target.position.z - item.transform.position.z).normalized;
         movementPerSecond = movementDirection * moveSpeed;
         Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);

         item.transform.rotation = rotation;
     }

 }*/


    /*if (isAttacking || health.HP < 0)
    {
        moveSpeed = 0f;
        movementPerSecond = movementDirection * moveSpeed;

    }
    moveSpeed = 20f;
    foreach (GameObject item in zombies)
    {
        item.transform.position = new Vector3(item.transform.position.x + (movementPerSecond.x * Time.deltaTime), 0,
        item.transform.position.z + (movementPerSecond.z * Time.deltaTime));
    }*/


    /*Distance = Vector3.Distance(Target.position, transform.position);
    if (!zomb.GetCurrentAnimatorStateInfo(0).IsName("Z_FallingBack") && !zomb.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack") && (!zomb.GetCurrentAnimatorStateInfo(0).IsName("Z_Run") || Distance >= chaseRange))
    {

        isAttacking = false;
        // IA.transform.position(zombie.position + moveSpeed);
        rbz.velocity = transform.forward * moveSpeed;
        rbz.velocity -= Physics.gravity * Time.deltaTime;

        transform.position +=  rbz.velocity * Time.fixedDeltaTime ;
    //rbz.AddForce(Physics.gravity, ForceMode.Acceleration);
    print(rbz.velocity);


    // rbz.MovePosition(rbz.position + rbz.velocity * Time.fixedDeltaTime);



    zomb.Play("Z_Walk");

    }*/
    /*if (health.HP <= 0 && Time.time > health.time + 2)
    {
        //Destroy(gameObject);
        // respawn();
        nbrz++;
        print(nbrz);

    }*/




    /*void attack()
    {
        foreach (GameObject item in zombies)
        {

            Vector3 velocity = transform.forward * 0;
        rbz.MovePosition(rbz.position + velocity * Time.fixedDeltaTime);

        isAttacking = true;
    

            if (Time.time > attackRate)
            {

            
            zomb.Play("Z_Attack");
               
                //Fais des dégâts au joueur
                //Target.SendMessage("ApplyDamage", DamageEnemy);
                 joueur.TakeDamage(25);
                attackRate = Time.time + attackRate;

            }
        }
    }*/


