using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int platformID=0;
   

	public Transform goal;
	
	void Update () {


		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 
	}

    /*public void OnCollisionEnter(Collision hit)
     {
         if (hit.gameObject.CompareTag("Module"))
         {
             GameObject platform = hit.gameObject;
             Module module = null;
             module = platform.GetComponent<Module>();

             platformID = module.ID;
         Debug.Log("+++++++++++++++++++++++++++++++YOMBIE ID:" + platformID);
         }
     }
     public void OnCollisionExit() { Debug.Log("0000000000000000000000Exited"); }

     public void OnCollisionStay() { Debug.Log("0000000000000000000000Stay"); }*/
}
