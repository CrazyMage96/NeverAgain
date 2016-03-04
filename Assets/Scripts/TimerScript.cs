using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {
   public float timeLimit;
	public int timePoints;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {

        if (timeLimit > 1)

        {
            timeLimit -= Time.deltaTime;
            transform.Translate(Vector3.back * Time.deltaTime, Space.World);
           // Debug.Log(timeLimit);
        }
        else if (timeLimit < 1) {
            GameObject placeholder = GameObject.FindGameObjectWithTag("GameController");
            Controler skript = placeholder.GetComponent<Controler>();
            skript.timeOut= true;
			ScoreManager.score+=timePoints;
            timeLimit = 10; }

    }
	
}
