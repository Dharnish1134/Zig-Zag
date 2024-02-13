using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Invoke("Fall",0.1f);
        }

    }

    void Fall()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        Destroy(transform.parent.gameObject,0.5f);
    }
}
