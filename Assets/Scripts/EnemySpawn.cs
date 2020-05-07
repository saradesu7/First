using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int count = 0;
    List<GameObject> smlist;

    private void Start()
    {
        smlist = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject objsm = (GameObject)Instantiate(enemy);
            objsm.SetActive(false);
            smlist.Add(objsm);
        }
    }

    private void FixedUpdate()
    {
        if (Time.time % 3 == 0)
            Create(count);
    }

    private void Create(int i)
    {
        if(!smlist[i].activeInHierarchy)
        {
            smlist[i].transform.position = enemy.transform.position;
            smlist[i].transform.rotation = enemy.transform.rotation;
            smlist[i].SetActive(true);
            count++;
        }
        if (count == smlist.Count)
            count = 0;
    }
}
