using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lifetime = 3;
    private float lifeTimer = 0;
    private float particleTimer = 0.5f;
    private bool hit;
    private Collider hitbox;
    public TargetSpawner spawner;
    public GameObject target;
    private ParticleSystem particles;
    private GameManager gameManager;
    private bool isBomb;
    public GameObject bombPrefab;
    private GameObject bomb;

    private bool hasScored = false;

    private Animator anim;
    private bool spawned;


    //sfx
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject blue;
    public GameObject red;
    public GameObject green;
    public GameObject purple;
    public GameObject yellow;
    public GameObject orange;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        prefabList.Add(blue);
        prefabList.Add(red);
        prefabList.Add(green);
        prefabList.Add(yellow);
        prefabList.Add(orange);
        prefabList.Add(purple);

        anim = GetComponent<Animator>();
        lifeTimer = lifetime + Time.time + 1.5f; // The 1.5 is additional time for the despawn animation
        hit = false;
        hitbox = GetComponent<Collider>();
        target = GameObject.FindWithTag("Player");
        spawned = false;

        if(Random.value < 0.1f && gameManager.GetScore() > 40)
        {
            isBomb = true;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            bomb = Instantiate(bombPrefab);
            bomb.transform.parent = transform;
            bomb.transform.localPosition = new Vector3(0, 0, 0);

            lifeTimer += 1f;    // Just so the bombs last longer and are subsequently more dangerous
        }
        else { isBomb = false; }
    }

    private void Update()
    {   
        if (!spawned)
        {
            anim.SetBool("Spawned", true);
            spawned = true;
            
        }
        Vector3 direction = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;

        if (lifeTimer < Time.time)
        {
            if(!hit && !isBomb)
            {
                Debug.Log("TARGET MISS");
                if (!hasScored)
                {
                    GameManager.Instance.Miss();
                    hasScored = true;
                }
                // anim.SetTrigger("Despawn");
                // Moving the above code so that the target can still register a hit before it completely disappears
            }
            Destroy(gameObject);
        }

        if (lifeTimer-1.5 < Time.time)
        {
            // Triggers the despawn animation 1.5 seconds before the Target dies
            anim.SetTrigger("Despawn");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        hit = true;
        Debug.Log("TARGET HIT"); 
        //Just made it here for now for a workable build- ask zach the intended way
        if (!hasScored && !isBomb)
        {
            GameManager.Instance.Hit();
            hasScored = true;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        //get random colour particle for death sfx
        int prefabIndex = UnityEngine.Random.Range(0,6);
        particles = Instantiate(prefabList[prefabIndex], transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        hitbox.enabled = false;
        if(isBomb)
        {
            Debug.Log("bomb lol");
            GameManager.Instance.Bomb();
        }
    }

    //if collides with bullet, hit = true and gameManager.Hit()
    //if StandingTimer runs out first, gameManager.Miss()
}
