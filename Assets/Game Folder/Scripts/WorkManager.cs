using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class WorkManager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> _boxList = new List<GameObject>();

    [SerializeField]
    private Transform _boxPoint, _moneyDropPoint;

    [SerializeField]
    private GameObject _boxPrefab, _moneyPrefab;

    private List<GameObject> _moneyList = new List<GameObject>();



    private void Start()
    {
        StartCoroutine(GenerateMoney());
    }

    private IEnumerator GenerateMoney()
    {
        while (true)
        {
            if (_boxList.Count > 0)
            {
                GameObject temp = Instantiate(_moneyPrefab);
                temp.transform.position = new Vector3(_moneyDropPoint.position.x, _moneyDropPoint.position.y + (_moneyList.Count * _moneyPrefab.transform.localScale.y * .03f), _moneyDropPoint.position.y);
                _moneyList.Add(temp);
                RemoveLast();
            }
        yield return new WaitForSeconds(.5f);

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





    public void GetBox()
    {
        GameObject temp = Instantiate(_boxPrefab,new Vector3(_boxPoint.position.x, _boxPoint.position.y + (_boxList.Count * _boxPrefab.transform.localScale.y * .6f ), _boxPoint.position.z), Quaternion.identity);


        
        _boxList.Add(temp);

    }





}//class
