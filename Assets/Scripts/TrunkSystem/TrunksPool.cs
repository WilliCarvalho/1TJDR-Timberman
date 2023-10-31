using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrunksPool : MonoBehaviour
{
    public static Action OnTrunkHitted;
    [SerializeField] private GameObject trunkPrefab;
    [SerializeField] List<TrunkBase> activeTrunks;

    private List<TrunkBase> pooledTrunks;
    private const float TRUNK_START_Y_POSITION = 6.6f;

    private void Awake()
    {
        pooledTrunks = new List<TrunkBase>();
    }
    
    public void TrunkHit()
    {
        TrunkBase hittedTrunk = activeTrunks[activeTrunks.Count - 1];
        hittedTrunk.TrunkHitted();
        ReturnTrunkToPool(hittedTrunk);
        RentTrunk();
    }

    public void RentTrunk()
    {
        TrunkBase obj;

        if (pooledTrunks.Count <= 1)
        {
            obj = InstantiateTrunk();
            pooledTrunks.Remove(pooledTrunks.FirstOrDefault());
        }
        else
        {
            obj = pooledTrunks.FirstOrDefault();
            pooledTrunks.Remove(pooledTrunks.FirstOrDefault());
        }

        obj.transform.position = new Vector3(0, TRUNK_START_Y_POSITION);
        obj.gameObject.SetActive(true);
        activeTrunks.Add(obj);
    }

    private TrunkBase InstantiateTrunk()
    {
        GameObject obj = Instantiate(trunkPrefab);

        return obj.GetComponent<TrunkBase>();
    }

    public void ReturnTrunkToPool(TrunkBase trunk)
    {
        activeTrunks.Remove(trunk);
        trunk.gameObject.SetActive(false);
        pooledTrunks.Add(trunk);
    }
}