using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigos : MonoBehaviour
{
    public GameObject[] inimigos;
    public float intervalo = 2f;
    public Transform spawnPoint;
    public Transform[] pontosDoCaminho;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnarInimigo), 1f, intervalo);
    }

    void SpawnarInimigo()
    {
        int indice = Random.Range(0, inimigos.Length);
        GameObject inimigo = Instantiate(inimigos[indice], spawnPoint.position, Quaternion.identity);
        InimigoBase inimigoBase = inimigo.GetComponent<InimigoBase>();
        inimigoBase.ConfigurarCaminho(new List<Transform>(pontosDoCaminho));
    }
}
