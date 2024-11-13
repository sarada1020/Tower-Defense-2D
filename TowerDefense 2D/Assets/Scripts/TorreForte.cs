using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe que representa uma torre poderosa chamada "TorreForte", herdando de TorreBase.
// Esta torre � especializada em atacar inimigos de uma cor espec�fica (Roxo).
public class TorreForte : TorreBase
{
    public GameObject prefabMunicao; // Prefab da muni��o usada pela torre para disparar contra os inimigos.

    // Define a l�gica para verificar se a torre pode atacar um inimigo.
    // A "TorreForte" s� pode atacar inimigos da classe "InimigoRoxo".
    protected override bool PodeAtacar(IAtacavel atacavel)
    {
        return atacavel is InimigoRoxo; // Retorna verdadeiro apenas se o inimigo for roxo.
    }

    // Implementa a l�gica de ataque para a torre.
    public override void Atacar()
    {
        // Verifica se h� inimigos na lista de alvos no alcance.
        if (atacaveisNoAlcance.Count > 0)
        {
            IAtacavel alvo = atacaveisNoAlcance[0]; // Seleciona o primeiro inimigo da lista.
            Disparar(alvo); // Chama o m�todo de disparo para atacar o inimigo.
        }
    }

    // M�todo que realiza o disparo da muni��o em dire��o ao inimigo.
    private void Disparar(IAtacavel alvo)
    {
        // Cria uma inst�ncia do prefab de muni��o na posi��o de spawn da torre.
        GameObject municaoObj = Instantiate(prefabMunicao, spawnPonto.position, Quaternion.identity);

        // Obt�m o componente "Municao" do objeto criado.
        Municao municao = municaoObj.GetComponent<Municao>();

        // Inicializa a muni��o, passando o inimigo como alvo e o dano da torre.
        municao.Iniciar((InimigoBase)alvo, dano);
    }
}

