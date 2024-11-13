using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe que representa uma torre poderosa chamada "TorreForte", herdando de TorreBase.
// Esta torre é especializada em atacar inimigos de uma cor específica (Roxo).
public class TorreForte : TorreBase
{
    public GameObject prefabMunicao; // Prefab da munição usada pela torre para disparar contra os inimigos.

    // Define a lógica para verificar se a torre pode atacar um inimigo.
    // A "TorreForte" só pode atacar inimigos da classe "InimigoRoxo".
    protected override bool PodeAtacar(IAtacavel atacavel)
    {
        return atacavel is InimigoRoxo; // Retorna verdadeiro apenas se o inimigo for roxo.
    }

    // Implementa a lógica de ataque para a torre.
    public override void Atacar()
    {
        // Verifica se há inimigos na lista de alvos no alcance.
        if (atacaveisNoAlcance.Count > 0)
        {
            IAtacavel alvo = atacaveisNoAlcance[0]; // Seleciona o primeiro inimigo da lista.
            Disparar(alvo); // Chama o método de disparo para atacar o inimigo.
        }
    }

    // Método que realiza o disparo da munição em direção ao inimigo.
    private void Disparar(IAtacavel alvo)
    {
        // Cria uma instância do prefab de munição na posição de spawn da torre.
        GameObject municaoObj = Instantiate(prefabMunicao, spawnPonto.position, Quaternion.identity);

        // Obtém o componente "Municao" do objeto criado.
        Municao municao = municaoObj.GetComponent<Municao>();

        // Inicializa a munição, passando o inimigo como alvo e o dano da torre.
        municao.Iniciar((InimigoBase)alvo, dano);
    }
}

