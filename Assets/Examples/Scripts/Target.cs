using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void Hit()
    {
        Destory(gameObject);
        //GameManager.Instance.Score();
    }
}
