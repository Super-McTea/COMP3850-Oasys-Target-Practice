using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    private float score;
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
            var position = new Vector3(Random.Range(-8.0f, 8.0f),Random.Range(-4.0f, 4.0f), 0);            
            target = Instantiate(prefab,transform.position + position,Quaternion.identity );
            //target.transform.position = transform.position;
            target.spawner = this;
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
        hideMin = (100 - score) / 50;   // Added the score into the hide timer
        hideMax = (100 - score) / 20;
        hideTimer = Random.Range(hideMin, hideMax) + Time.time;
    }
}
