using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void Hit()
    {
        Destroy(gameObject);
        GameManager.Instance.Hit();
    }
}
