using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other.name);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    //�ʉ߂����I�u�W�F�N�g��j��
    //    Destroy(other.gameObject);
    //}

    private void OnBecameInvisible()
    {
        //Debug.Log(this.gameObject.name);
        Destroy(this.gameObject);
    }
}
