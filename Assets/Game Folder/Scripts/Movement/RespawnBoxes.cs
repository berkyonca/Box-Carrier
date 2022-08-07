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
    int _stackCount = 10;

    private bool _isPaletFull = false;

    private void Start()
    {
        StartCoroutine(BoxRespawn());
    }



    IEnumerator BoxRespawn()
    {
        while (true)
        {
            
                float boxCount = _boxList.Count;
            int rowCount = (int)boxCount / _stackCount;
            if (!_isPaletFull)
            {
                
                GameObject prefab = Instantiate(_boxPrefab, _startPoint.transform.position, Quaternion.identity);
                prefab.transform.DOMove(new Vector3(_exitPoint.position.x + (float)rowCount/3, (boxCount%_stackCount * prefab.transform.localScale.y*.6f), _exitPoint.position.z), 3f);
                _boxList.Add(prefab);
                if (_boxList.Count >= 30)
                {
                    _isPaletFull = true;
                    print("Palet Full Kardeþ.");
                }
            }
            if (_boxList.Count < 30)
            {
                _isPaletFull = false;
            }

            yield return new WaitForSeconds(.4f);


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







}
