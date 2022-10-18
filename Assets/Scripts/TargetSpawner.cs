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
    public GameObject centre;
    //public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null && hideTimer < Time.time)
        {   
            score = gameManager.GetScore();
            var position = new Vector3(Random.Range(-12.5f, 12.5f),Random.Range(-1.0f, 5.0f), 0);            
            target = Instantiate(prefab,centre.transform.position + position,Quaternion.identity );
            //target.transform.position = transform.position;
            target.spawn = this;
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
        hideMin = 5;
        hideMax = 9;
        hideTimer = Random.Range(hideMin, hideMax) + Time.time;
    }
}
