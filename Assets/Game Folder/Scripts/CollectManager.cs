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
    }

    private void OnDisable()
    {
        TriggerManager.OnBoxCollect -= GetBox;
    }

    private void GetBox()
    {
        if (_boxList.Count <= _boxCapacity)
        {
            GameObject temp = Instantiate(_boxPrefab,_collectPoint, true);
            // temp.transform.localScale *= 200;

           
            temp.transform.DOLocalMove(new Vector3(_collectPoint.transform.localPosition.x, Mathf.Abs(_boxList.Count * temp.transform.localPosition.y * 3f), _collectPoint.localPosition.z), 1f);
            temp.transform.localRotation = Quaternion.identity;
          // temp.transform.DOMove(new Vector3(_collectPoint.transform.position.x, (_boxList.Count * temp.transform.position.y * .6f), _collectPoint.position.z), 2f);
            _boxList.Add(temp);
        }

    }





}
