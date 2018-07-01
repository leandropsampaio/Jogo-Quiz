using UnityEngine;
using System.Collections;

public class comandosBasicos : MonoBehaviour
{

    public void carregarCena(string nomeCena)
    {
        Application.LoadLevel(nomeCena);
    }

    public void resetarPontuacoes()
    {
        PlayerPrefs.DeleteAll();
    }
}