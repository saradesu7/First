using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy1;
    [SerializeField] private int countsm = 0;
    List<GameObject> smlist;

    [SerializeField] private GameObject enemy2;
    [SerializeField] private int countmg = 0;
    List<GameObject> mglist;

    private void Start()
    {
        smlist = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject objsm = (GameObject)Instantiate(enemy1);
            objsm.SetActive(false);
            smlist.Add(objsm);
        }

        mglist = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject objmg = (GameObject)Instantiate(enemy2);
            objmg.SetActive(false);
            mglist.Add(objmg);
        }
    }

    private void FixedUpdate()
    {
        if (Time.time % 5 == 0)
            Createsm(countsm);
        if (Time.time % 15 == 0)
            Createmg(countmg);
    }

    private void Createsm(int i)
    {
        if(!smlist[i].activeInHierarchy)
        {
            smlist[i].transform.position = enemy1.transform.position;
            smlist[i].transform.rotation = enemy1.transform.rotation;
            smlist[i].SetActive(true);
            countsm++;
        }
        if (countsm == smlist.Count)
            countsm = 0;
    }

    private void Createmg(int i)
    {
        if (!mglist[i].activeInHierarchy)
        {
            mglist[i].transform.position = enemy2.transform.position;
            mglist[i].transform.rotation = enemy2.transform.rotation;
            mglist[i].SetActive(true);
            countmg++;
        }
        if (countmg == mglist.Count)
            countmg = 0;
    }
}
