using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GeradorDeInimigos : MonoBehaviour
{
    public GameObject[] inimigos; // Array de prefabs dos inimigos para spawnar
    public Transform spawnPoint; // Ponto onde os inimigos ser�o spawnados
    public Transform[] pontosDoCaminho; // Pontos que formam o caminho para os inimigos
    public int quantidadePorOnda = 10; // N�mero de inimigos a spawnar em cada onda
    public float intervaloEntreInimigos = 0.5f; // Intervalo de tempo entre o spawn de cada inimigo em uma onda
    public float intervaloEntreOndas = 5f; // Intervalo de tempo entre duas ondas consecutivas

    private bool spawnando = false; // Flag para indicar se uma onda est� sendo spawnada

    private void Start()
    {
        // Inicia a gera��o cont�nua de ondas de inimigos
        StartCoroutine(GerarOndas());
    }

    private IEnumerator GerarOndas()
    {
        while (true) // Loop infinito para manter as ondas cont�nuas
        {
            spawnando = true; // Marca que a gera��o da onda est� em andamento

            // Gera a quantidade de inimigos especificada para a onda
            for (int i = 0; i < quantidadePorOnda; i++)
            {
                SpawnarInimigo(); // Cria um inimigo
                yield return new WaitForSeconds(intervaloEntreInimigos); // Aguarda o intervalo entre inimigos
            }

            spawnando = false; // Marca que a gera��o da onda foi conclu�da

            // Aguarda o intervalo antes de iniciar a pr�xima onda
            yield return new WaitForSeconds(intervaloEntreOndas);
        }
    }

    private void SpawnarInimigo()
    {
        // Seleciona aleatoriamente um inimigo do array de prefabs
        int indice = Random.Range(0, inimigos.Length);

        // Instancia o inimigo no ponto de spawn
        GameObject inimigo = Instantiate(inimigos[indice], spawnPoint.position, Quaternion.identity);

        // Obt�m o componente InimigoBase para configurar o caminho
        InimigoBase inimigoBase = inimigo.GetComponent<InimigoBase>();

        // Configura o caminho para o inimigo, verificando se os pontos do caminho foram atribu�dos
        if (pontosDoCaminho != null && pontosDoCaminho.Length > 0)
        {
            // Converte o array de pontos em uma lista e passa para o inimigo
            inimigoBase.ConfigurarCaminho(new List<Transform>(pontosDoCaminho));
        }
        else
        {
            // Exibe um erro no console se os pontos do caminho n�o foram configurados
            Debug.LogError("Pontos do caminho n�o est�o configurados no GeradorDeInimigos.");
        }
    }
}
