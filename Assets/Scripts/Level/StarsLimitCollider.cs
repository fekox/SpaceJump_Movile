using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarsLimitCollider : MonoBehaviour
{
    [SerializeField] private string starTag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(starTag))
        {
            Destroy(collision.gameObject);
        }
    }
}
