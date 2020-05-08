using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpEnemy2 : MonoBehaviour
{
    public Magician mg;
    [SerializeField] private Sprite first;
    [SerializeField] private Sprite second;
    [SerializeField] private Sprite third;
    [SerializeField] private Sprite fourth;
    [SerializeField] private Sprite fifth;
    private void Update()
    {
        if (mg.count == 1)
            this.GetComponent<SpriteRenderer>().sprite = first;
        if (mg.count == 5)
            this.GetComponent<SpriteRenderer>().sprite = second;
        if (mg.count == 10)
            this.GetComponent<SpriteRenderer>().sprite = third;
        if (mg.count == 15)
            this.GetComponent<SpriteRenderer>().sprite = fourth;
        if (mg.count == 20)
            this.GetComponent<SpriteRenderer>().sprite = fifth;
    }
}
