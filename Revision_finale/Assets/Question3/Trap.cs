using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Trap : NetworkBehaviour
{
    private GameObject owner;
    public Renderer rend;

    public void SetOwner(GameObject newOwner)
    {
        owner = newOwner;
        rend = GetComponent<Renderer>();
        if(owner.GetComponent<NetworkIdentity>().isLocalPlayer)
        {
            rend.enabled = true;
        }
        else
        {
            rend.enabled = false;
        }
    }

    public void Triggertrap(Collider2D collision)
    {
        print("Faire du dégat");
        Destroy(gameObject);
    }

    private bool TrapShouldTrigger(Collider2D collision)
    {
        if (collision.gameObject == owner)
        {
            return false;
        }
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (TrapShouldTrigger(collision))
        {
            Triggertrap(collision);
        }

    }

}
