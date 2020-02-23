﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBossBiteEast : MonoBehaviour
{

    public int biteDamage = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerChar>().TakeDamage(biteDamage);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(other.transform.right * 10000f);
        }
    }
}