using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RespawnBoxes : MonoBehaviour
{
    
    [SerializeField]
    List<GameObject> _boxList = new List<GameObject>();
    [SerializeField]
    GameObject _boxPrefab;
    [SerializeField]
    Transform _startPoint;
    [SerializeField]
    Transform _exitPoint;
    


    private void Start()
    {
        StartCoroutine(BoxRespawn());
    }



    IEnumerator BoxRespawn()
    {
        while (true)
        {
            float boxCount = _boxList.Count;
            GameObject prefab = Instantiate(_boxPrefab, _startPoint.transform.position, Quaternion.identity);
            prefab.transform.DOMove(new Vector3(_exitPoint.position.x, (boxCount * 0.15f), _exitPoint.position.z), 3f);
            
            _boxList.Add(prefab);
            yield return new WaitForSeconds(2.5f);


        }
    }






}
