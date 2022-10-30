using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public float score;
    private float hideMin, hideMax, hideTimer;
    public Target target;
    public Target prefab;
    private GameManager gameManager;
    //public GameObject centre;
    //public GameObject player;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.FindWithTag("Player");
        gameManager = FindObjectOfType<GameManager>();
        Restart();
    }

    // Update is called once per frame
    void Update()
    {   
        //rotate inline to player
        Vector3 direction = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        if(target == null && hideTimer < Time.time)
        {   
            score = gameManager.GetScore();
            var position = new Vector3(Random.Range(-5.0f, 5.0f),Random.Range(-3.0f, 3.0f), 0);            
            target = Instantiate(prefab,transform.position + position,Quaternion.identity );
            //target.transform.position = transform.position;
            // target.spawn = this;
            target.lifetime = 1 + (100 - score) / 20;
            Debug.Log("Target spawned with life of " + target.lifetime);
            //target.lifetime = whatever/score or something
            Restart();
        }
    }

    public void Restart()
    {
        score = gameManager.GetScore();

        //keep in mind every target will show up within hideMin and hideMax time
        //e.g. min = 10-score, max = 14-score, every target shown every 4 secs
        hideMin = 1 + (100 - score) / 25;   // Added the score into the hide timer
        hideMax = 3 + (100 - score) / 20;
        hideTimer = Random.Range(hideMin, hideMax) + Time.time;
    }
}
