using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectManager : MonoBehaviour
{

    [SerializeField]
    List<GameObject> _boxList = new List<GameObject>();
    [SerializeField]
    GameObject _boxPrefab;
    [SerializeField]
    Transform _collectPoint;


    
    private int _boxCapacity = 10;



    private void OnEnable()
    {
        TriggerManager.OnBoxCollect += GetBox;
        TriggerManager.OnBoxGive += GiveBox;
    }

    private void OnDisable()
    {
        TriggerManager.OnBoxCollect -= GetBox;
        TriggerManager.OnBoxGive -= GiveBox;
    }

    private void GetBox()
    {
        if (_boxList.Count <= _boxCapacity)
        {
            GameObject temp = Instantiate(_boxPrefab,_collectPoint, true);
        

           
            temp.transform.DOLocalMove(new Vector3(_collectPoint.transform.localPosition.x, Mathf.Abs(_boxList.Count * temp.transform.localPosition.y * 3f), _collectPoint.localPosition.z), 1f);
            temp.transform.localRotation = Quaternion.identity;
            _boxList.Add(temp);
            if (TriggerManager.respawnBoxes != null)
            {
                TriggerManager.respawnBoxes.RemoveLast();
            }
        }

    }

    public void RemoveLast()
    {
        if (_boxList.Count > 0)
        {
            Destroy(_boxList[_boxList.Count - 1]);
            _boxList.RemoveAt(_boxList.Count - 1);
        }
    }

    private void GiveBox()
    {
        if (_boxList.Count > 0)
        {
            TriggerManager.workerManager.GetBox();
            RemoveLast();
        }
    }





}//class
