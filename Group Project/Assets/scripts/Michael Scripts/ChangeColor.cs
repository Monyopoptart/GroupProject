using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer thisThing;
    // Start is called before the first frame update
    void Start()
    {
        thisThing = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float randomColorx = Random.Range(0f, 1f);
        float randomColory = Random.Range(0f, 1f);
        float randomColorz = Random.Range(0f, 1f);
        thisThing.color = new Color(randomColorx, randomColory, randomColorz); //This will cause his color to change seizure like
    }
}
