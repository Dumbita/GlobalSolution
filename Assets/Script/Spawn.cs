using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{

    [SerializeField] Transform[] pontos;
    public GameObject cubo;

    int i;
    int k;
    int l;
    string name;

    void Start()
    {

        k = -1;

        StartCoroutine(Nasce());

    }

    void Update()
    {
        
    }

    IEnumerator Nasce()
    {

        yield return new WaitForSeconds(20);

        for(int j = 0; j < 3; j++)
        {

            i = Random.Range(0, pontos.Length);

            if(i != k)
            {

                l = j + 1;
                name = "Pacote" + l;
                cubo.gameObject.tag = name;
                Instantiate(cubo, pontos[i].position, pontos[i].rotation);

            }
            else if (i == k)
            {

                j--;

            }
            k = i;

        }
        
    }

}
