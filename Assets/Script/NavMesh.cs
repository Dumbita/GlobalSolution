using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NavMesh : MonoBehaviour
{

    private NavMeshAgent carro;

    private Transform pacote;

    public Transform garagem;

    private Rigidbody rb;

    bool flag;
    bool espera;

    public List<Transform> patrulha = new List<Transform>();
    public int current = 0;

    [SerializeField] string package;

    void Start()
    {

        carro = GetComponent<NavMeshAgent>();

        rb = GetComponent<Rigidbody>();

        rb.isKinematic = false;

        flag = false;
        espera = false;

        StartCoroutine(Nasce());
        
    }

    void Update()
    {

        

        if (pacote != null && flag == false && espera == true)
        {

            carro.SetDestination(pacote.position);


        }
        else if (pacote == null && flag == true && espera == true)
        {

            carro.SetDestination(garagem.position);
            rb.isKinematic = true;

        }
        else
        {

            MoveToNextPoint();

        }


    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == package)
        {

            Destroy(other.gameObject);
            flag = true;

        }

    }

    void MoveToNextPoint()
    {
        if (patrulha.Count > 0)
        {
            float distance = Vector3.Distance(patrulha[current].position, transform.position);
            carro.destination = patrulha[current].position;

            if (distance <= 2f)
            {
       
                current = Random.Range(0, patrulha.Count);
                current %= patrulha.Count;

            }
        }
    }

    IEnumerator Nasce()
    {

        yield return new WaitForSeconds(22);

        pacote = GameObject.FindGameObjectWithTag(package).transform;

        espera = true;

    }

}
