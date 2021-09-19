using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Hit");
        Destroy(this);
    }
}
