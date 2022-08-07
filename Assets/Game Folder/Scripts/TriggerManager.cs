using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnBoxCollect;
    public static RespawnBoxes respawnBoxes;

    private bool _isCollecting, _isGiving;

    public delegate void OnDropArea();
    public static event OnDropArea OnBoxGive;
    public static WorkManager workerManager;

    public delegate void OnMoneySection();
    public static event OnMoneySection OnMoneyCollected;

    private void Start()
    {
        StartCoroutine(CollectEnum());
    }


    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (_isCollecting)
            {
                OnBoxCollect();
            }
            if (_isGiving)
            {
                OnBoxGive();
            }
            yield return new WaitForSeconds(.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Money")
        {
            OnMoneyCollected();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "CollectArea")
        {
            _isCollecting = true;
            respawnBoxes = other.gameObject.GetComponent<RespawnBoxes>();
        }
        if (other.tag == "DropSection")
        {
            _isGiving = true;
            workerManager = other.gameObject.GetComponent<WorkManager>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CollectArea")
        {
            _isCollecting = false;
            respawnBoxes = null;
        }

        if (other.tag == "DropSection")
        {
            _isGiving = false;
            workerManager = null;
            
        }

    }





}
