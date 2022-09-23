using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public float score;
    private float hideMin, hideMax, hideTimer;
    public Target target;
    public Target prefab;


    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null && hideTimer < Time.time)
        {
            target = Instantiate(prefab);
            target.transform.position = transform.position;
            target.spawn = this;
            Debug.Log("Target spawned");
            //target.lifetime = whatever/score or something
            Restart();
        }
    }

    public void Restart()
    {
        score = Random.Range(30, 90);
        Debug.Log("new target waiting with score of " + score);

        //keep in mind every target will show up within hideMin and hideMax time
        //e.g. min = 10-score, max = 14-score, every target shown every 4 secs
        hideMin = 10 - score / 10;
        hideMax = 14 - score / 10;
        hideTimer = Random.Range(hideMin, hideMax) + Time.time;
    }
}
