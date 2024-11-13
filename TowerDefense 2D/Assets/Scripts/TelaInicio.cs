using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Classe responsável pelo gerenciamento das interações na tela inicial do jogo.
public class TelaInicio : MonoBehaviour
{
    // Método chamado quando o botão "Jogar" é clicado.
    // Este método carrega a cena principal do jogo.
    public void Jogar()
    {
        // Carrega a cena chamada "SampleScene".
        SceneManager.LoadScene("SampleScene");
    }
}


