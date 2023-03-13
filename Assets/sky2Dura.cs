using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sky2Dura : MonoBehaviour
{
    public int maxDura = 30;
    public int currentDura;

    public Durability durability;
    // Start is called before the first frame update
    void Start()
    {
        currentDura = maxDura;
        StartCoroutine("DuraDecrease");
        durability.SetMaxDura(maxDura);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDura <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DuraDecrease()
    {
        while (currentDura > 0)
        {
            currentDura -= 1;
            durability.SetDurability(currentDura);
            yield return new WaitForSeconds(1f);
        }

    }
}
