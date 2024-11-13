using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Classe respons�vel pelo gerenciamento das intera��es na tela inicial do jogo.
public class TelaInicio : MonoBehaviour
{
    // M�todo chamado quando o bot�o "Jogar" � clicado.
    // Este m�todo carrega a cena principal do jogo.
    public void Jogar()
    {
        // Carrega a cena chamada "SampleScene".
        SceneManager.LoadScene("SampleScene");
    }
}


