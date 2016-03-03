using UnityEngine;
using System.Collections;

public class Controler : MonoBehaviour
{

    public GameObject[] possibleModules;
    public GameObject player;
    public GameObject Zombie;
    public GameObject Ghost;
    
 

    /////// HEAD
    public static float fixFaktor = 0f;
    public static float distance = 10f + fixFaktor;
    public float rangeToDestroy = 2;
    //public float cooldown = -1; 
    /// <summary>
    /// ///
    /// </summary>

    ////// refs/remotes/origin/plattforms

    // 5 Gameobjects 
    public GameObject middle;//0
    public GameObject left;  //3
    public GameObject bottom;//2
    public GameObject right; //1
    public GameObject top;   //4

    private Vector3 positionMiddle = new Vector3(0, 0, 0);
    private Vector3 positionLeft = new Vector3(-distance, 0, 0);
    private Vector3 positionBottom = new Vector3(0, 0, -distance);
    private Vector3 positionRight = new Vector3(distance, 0, 0);
    private Vector3 positionTop = new Vector3(0, 0, distance);



    private GameObject remainingMiddle;
    private GameObject remainingSide;


    // change bool recieve and seperate value
    public bool change = false;
    public bool timeOut=false;
    public bool destructionTime = false;


    // knows which platform has the player

    public int destination = 0; // platform player is at changed bz module
    public int zombieScore;
    public int ghostScore;

    // platform array random choose method
    GameObject[] ManyModules;

    void Update()
    {
        if (change)
        {
            Debug.Log("Destination:" + destination);
            Remove();
            MovePlayer();
            moveMonsters();
            ChangeNumbers();//change remaining two numbers
            MoveTwo();//move those two to their positions, change Verbindung
            SpawnPlatforms();
            SpawnZombies();
            change = false;
            destination = 0;
        }
        if (timeOut)
        {
            SpawnGhosts();
            timeOut = false;
            //cooldown--;
        }
        
        if (destructionTime)
        {
            DestroyGhosts();
            destructionTime = false;
            
        }
    }

    void Remove()
    {
        for (int i = 1; i <= 4; i++)
        {
            if (i != destination)
            {
                if (i == 1)
                {
                    Destroy(right);
                    right = null;
                }
                if (i == 2)
                {
                    Destroy(bottom);
                    bottom = null;
                }
                if (i == 3)
                {
                    Destroy(left);
                    left = null;
                }
                if (i == 4)
                {
                    Destroy(top);
                    top = null;
                }
            }
        }
    }
    void ChangeNumbers()
    {
        //changes ID in middle module script to side

        Module moduleMiddle = null;
        if (destination == 1) { remainingMiddle = middle; moduleMiddle = middle.GetComponent<Module>(); moduleMiddle.ID = 3; }
        else
            if (destination == 2) { remainingMiddle = middle; moduleMiddle = middle.GetComponent<Module>(); moduleMiddle.ID = 4; }
        else
            if (destination == 3) { remainingMiddle = middle; moduleMiddle = middle.GetComponent<Module>(); moduleMiddle.ID = 1; }
        else
            if (destination == 4) { remainingMiddle = middle; moduleMiddle = middle.GetComponent<Module>(); moduleMiddle.ID = 2; }


        //changes ID in side module script to 0
        Module moduleSide = null;
        if (destination == 1) { remainingSide = right; moduleSide = right.GetComponent<Module>(); }
        else
            if (destination == 2) { remainingSide = bottom; moduleSide = bottom.GetComponent<Module>(); }
        else
            if (destination == 3) { remainingSide = left; moduleSide = left.GetComponent<Module>(); }
        else
            if (destination == 4) { remainingSide = top; moduleSide = top.GetComponent<Module>(); }
        moduleSide.ID = 0;

    }
    void MoveTwo()
    {
        middle = remainingSide;
        //move it
        middle.transform.position = positionMiddle;

        if (remainingSide == right)
        {
            left = remainingMiddle;
            left.transform.position = positionLeft;
            right = null;
        }
        if (remainingSide == bottom)
        {
            top = remainingMiddle;
            top.transform.position = positionTop;
            bottom = null;
        }
        if (remainingSide == left)
        {
            right = remainingMiddle;
            right.transform.position = positionRight;
            left = null;
        }
        if (remainingSide == top)
        {
            bottom = remainingMiddle;
            bottom.transform.position = positionBottom;
            top = null;
        }

    }
    void MovePlayer()
    {
        Vector3 placeholder = player.transform.position;

        if (destination == 1) { placeholder.x -= distance; placeholder.y = 1; placeholder.z = player.transform.position.z; }//y hangt von grosse der player ab
        else
            if (destination == 2) { placeholder.z += distance; placeholder.y = 1; placeholder.x = player.transform.position.x; }
        else
            if (destination == 3) { placeholder.x += distance; placeholder.y = 1; placeholder.z = player.transform.position.z; }
        else
            if (destination == 4) { placeholder.z -= distance; placeholder.y = 1; placeholder.x = player.transform.position.x; }
        player.transform.position = placeholder;
    }
    void moveMonsters()
    {
        //Debug.Log("MoveGhost");
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        for (int i = 0; i < ghosts.Length; i++)
        {
            Vector3 placeholder = ghosts[i].transform.position;

            if (destination == 1) { placeholder.x -= distance; placeholder.y = 1; }//y hangt von grosse der player ab
            else
                if (destination == 2) { placeholder.z += distance; placeholder.y = 1; }
            else
                if (destination == 3) { placeholder.x += distance; placeholder.y = 1; }
            else
                if (destination == 4) { placeholder.z -= distance; placeholder.y = 1; }

            ghosts[i].transform.position = placeholder;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        


        for (int i = 0; i < enemies.Length; i++)
        {
            Debug.Log("Enemies: " + enemies[i]);
            Debug.Log("Position: " + enemies[i].transform.position);
            Vector3 placeholder = enemies[i].transform.position;
            if (destination == 1)
            {
                if (enemies[i].transform.position.x <= 15f && enemies[i].transform.position.x >= -5f &&
                    enemies[i].transform.position.z <= 5f && enemies[i].transform.position.z >= -5f)
                {
                    placeholder.x -= distance; placeholder.y = 1;
                    enemies[i].transform.position = placeholder;
                }
                else
                {
                    Destroy(enemies[i]);
                    GameData.Instance.points +=zombieScore;

                }
            }
            else
            if (destination == 2)
            {
                if (enemies[i].transform.position.x <= 5f && enemies[i].transform.position.x >= -5f &&
                    enemies[i].transform.position.z <= 5f && enemies[i].transform.position.z >= -15f)
                {
                    placeholder.z += distance; placeholder.y = 1;
                    enemies[i].transform.position = placeholder;
                }
                else
                {
                    Destroy(enemies[i]);
                    GameData.Instance.points += zombieScore;
                }
            }
            else
            if (destination == 3)
            {
                if (enemies[i].transform.position.x <= 5f && enemies[i].transform.position.x >= -5f &&
                    enemies[i].transform.position.z <= 15f && enemies[i].transform.position.z >= -5f)
                {
                    placeholder.x += distance; placeholder.y = 1;
                    enemies[i].transform.position = placeholder;
                }
                else
                {
                    Destroy(enemies[i]);
                    GameData.Instance.points += zombieScore;
                }
            }
            else
            if (destination == 4)
            {
                if (enemies[i].transform.position.x <= 15f && enemies[i].transform.position.x >= -5f &&
                    enemies[i].transform.position.z <= 5f && enemies[i].transform.position.z >= -5f)
                {
                    placeholder.z -= distance; placeholder.y = 1;
                    enemies[i].transform.position = placeholder;
                }
                else
                {
                    Destroy(enemies[i]);
                    GameData.Instance.points += zombieScore;
                }
            }

        }

    }
    void SpawnPlatforms()
    {
        int anti = 0;
        if (destination == 1) { anti = destination + 2; }
        else if (destination == 2) { anti = destination + 2; }
        else
        if (destination == 3) { anti = destination - 2; }
        else if (destination == 4) { anti = destination - 2; }


        for (int i = 1; i <= 4; i++)
        {
            //Debug.Log("anti in for: "+anti);
            Vector3 locartion = new Vector3(0, 0, 0);


            if (i == 1) { locartion = new Vector3(distance, 0, 0);   /*Debug.Log("Created a right");*/ }
            else
            if (i == 2) { locartion = new Vector3(0, 0, -distance); /*Debug.Log("Created a bottom");*/ }
            else
            if (i == 3) { locartion = new Vector3(-distance, 0, 0); /*Debug.Log("Created a left");*/ }
            else
            if (i == 4) { locartion = new Vector3(0, 0, distance); /*Debug.Log("Created a top");*/ }


            if (i != anti)
            {
                int index = Random.Range(0, possibleModules.Length);
                GameObject placeHolder = possibleModules[index];
                GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;//changed  be carefull


                Module neueModule = good.GetComponent<Module>();//changed to good was placeholder


                neueModule.ID = i;

                if (i == 1) { right = good; }//if changed be carefull used to be placeholder
                else
            if (i == 2) { bottom = good; }
                else
            if (i == 3) { left = good; }
                else
            if (i == 4) { top = good; }

            }

        }

    }
    void SpawnZombies()
    {
        for (int i = 0; i <= 3; i++)
        {

            if (i == 4 && i!=destination)
            {
                int index = Random.Range(0, 3);
                if (index == 0)
                {
                    Vector3 locartion = new Vector3(0, 1, 5.5f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;

                }
                else if (index == 1 )
                {
                    Vector3 locartion = new Vector3(0, 1, 14.5f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;

                }
                else
               if (index == 2)
                {
                    Vector3 locartion = new Vector3(4.5f, 1, 10f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;

                }
                else
               if (index == 3)
                {
                    Vector3 locartion = new Vector3(-4.5f, 1, 10f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;
                }
            }else
            if (i == 3 && i != destination)
            {
                int index = Random.Range(0, 3);
                if (index == 0)
                {
                    Vector3 locartion = new Vector3(5.5f, 1, 0);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;

                }
                else if (index == 1)
                {
                    Vector3 locartion = new Vector3(-10f, 1, 4.5f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;

                }
                else
               if (index == 2)
                {
                    Vector3 locartion = new Vector3(-14.5f, 1, 0);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;

                }
                else
               if (index == 3)
                {
                    Vector3 locartion = new Vector3(-10f, 1, 4.5f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;
                }
            }
            else
            if (i == 2 && i != destination)
            {
                int index = Random.Range(0, 3);
                if (index == 0)
                {
                    Vector3 locartion = new Vector3(0, 1, -5.5f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;

                }
                else if (index == 1)
                {
                    Vector3 locartion = new Vector3(-4.5f, 1, -10f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;

                }
                else
               if (index == 2)
                {
                    Vector3 locartion = new Vector3(0, 1, -14.5f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;

                }
                else
               if (index == 3)
                {
                    Vector3 locartion = new Vector3(4.5f, 1, -10f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;
                }
            }
            else
            if (i == 1 && i != destination)
            {
                int index = Random.Range(0, 3);
                if (index == 0)
                {
                    Vector3 locartion = new Vector3(5.5f, 1, 0);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;

                }
                else if (index ==1)
                {
                    Vector3 locartion = new Vector3(14.5f, 1, 0f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;

                }
                else
               if (index == 2)
                {
                    Vector3 locartion = new Vector3(10, 1, 4.5f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;

                }
                else
               if (index == 3)
                {
                    Vector3 locartion = new Vector3(10, 1, -4.5f);
                    GameObject placeHolder = Zombie;
                    GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;
                }
            }




        }
    }
    void SpawnGhosts()
    {
        int index = Random.Range(0, 3);
        Vector3 locartion = new Vector3(0, 0, 0);
        if (index == 0)
        {
            locartion = new Vector3(10, 1, 10);
        }
        if (index == 1)
        {
            locartion = new Vector3(10, 1, -10);
        }
        if (index == 2)
        {
            locartion = new Vector3(-10, 1, -10);
        }
        if (index == 3)
        {
            locartion = new Vector3(-10, 1, 10);
        }
        GameObject placeHolder = Ghost;
        GameObject good = (GameObject)Instantiate(placeHolder, locartion, Quaternion.identity) as GameObject;
    }
    void DestroyGhosts()
    {
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");

        for (int i = 0; i < ghosts.Length; i++)
        {
            if (rangeToDestroy >= Vector3.Distance(player.transform.position, ghosts[i].transform.position))
            {
                 Destroy(ghosts[i]);
                 //cooldown = 2;
            }
        }

    }
}