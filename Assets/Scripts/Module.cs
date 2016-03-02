using UnityEngine;
using System.Collections;

public class Module : MonoBehaviour {
    public int ID;
    

    

	public void OnCollisionEnter(Collision bit)
    {
        //Debug.Log("first collide ");
        if (bit.gameObject == GameObject.Find("Player"))
        {

            //Debug.Log("second collide ");
            if (ID != 0)
            {
                //Debug.Log("collision detected " + ID);

                GameObject placeholder = GameObject.FindGameObjectWithTag("GameController");
                Controler skript = placeholder.GetComponent<Controler>();
                skript.change = true;
                skript.destination = ID;
                
            }
        }
    }

}
