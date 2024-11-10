using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigos : MonoBehaviour
{
    public GameObject[] inimigos; // Prefabs dos inimigos
    public Transform spawnPoint; // Ponto de spawn
    public Transform[] pontosDoCaminho; // Pontos do caminho
    public int quantidadePorOnda = 10; // Número de inimigos por onda
    public float intervaloEntreInimigos = 0.5f; // Intervalo entre inimigos da mesma onda
    public float intervaloEntreOndas = 5f; // Tempo entre ondas

    private bool spawnando = false;

    private void Start()
    {
        // Começa a primeira onda
        StartCoroutine(GerarOndas());
    }

    private IEnumerator GerarOndas()
    {
        while (true) // Loop infinito para gerar ondas continuamente
        {
            spawnando = true;

            // Gera os inimigos da onda
            for (int i = 0; i < quantidadePorOnda; i++)
            {
                SpawnarInimigo();
                yield return new WaitForSeconds(intervaloEntreInimigos);
            }

            spawnando = false;

            // Espera antes de iniciar a próxima onda
            yield return new WaitForSeconds(intervaloEntreOndas);
        }
    }

    private void SpawnarInimigo()
    {
        int indice = Random.Range(0, inimigos.Length);
        GameObject inimigo = Instantiate(inimigos[indice], spawnPoint.position, Quaternion.identity);
        InimigoBase inimigoBase = inimigo.GetComponent<InimigoBase>();

        // Configura o caminho para o inimigo
        if (pontosDoCaminho != null && pontosDoCaminho.Length > 0)
        {
            inimigoBase.ConfigurarCaminho(new List<Transform>(pontosDoCaminho));
        }
        else
        {
            Debug.LogError("Pontos do caminho não estão configurados no GeradorDeInimigos.");
        }
    }
}