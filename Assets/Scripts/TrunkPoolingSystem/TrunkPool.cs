using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrunkPool : MonoBehaviour
{
    public static Action OnTrunkHitted;

    [SerializeField] private GameObject trunkPrefab;
    [SerializeField] private List<TrunkBase> activeTrunks;

    private List<TrunkBase> pooledTrunks;

    private void Awake()
    {
        pooledTrunks = new List<TrunkBase>();
    }

    public void TrunkHit()
    {
        TrunkBase hittedTrunk = activeTrunks.FirstOrDefault();

        hittedTrunk.TrunkHitted();
        ReturnTrunkToPool(hittedTrunk);
        RentTrunk();
    }

    private void ReturnTrunkToPool(TrunkBase trunk)
    {
        trunk.gameObject.SetActive(false);
        activeTrunks.Remove(trunk);
        pooledTrunks.Add(trunk);
    }

    private void RentTrunk()
    {
        TrunkBase trunk;

        if (pooledTrunks.Count() < 1)
        {
            trunk = InstantiateTrunk();
        }
        else
        {
            trunk = pooledTrunks.FirstOrDefault();
            pooledTrunks.Remove(trunk);
        }

        trunk.transform.position = new Vector2(0, 6.6f);
        trunk.gameObject.SetActive(true);
        activeTrunks.Add(trunk);
    }
    
    private TrunkBase InstantiateTrunk()
    {
        GameObject trunkObject = Instantiate(trunkPrefab);

        return trunkObject.GetComponent<TrunkBase>();
    }
}
