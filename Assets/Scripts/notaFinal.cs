using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class notaFinal : MonoBehaviour {

    private int idTema;

    public Text txtNota;
    public Text txtInfoTema;

    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    private int notaFinall;
    private int acertos;

    // Use this for initialization
    void Start () {

        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);

        idTema = PlayerPrefs.GetInt("idTema");
        notaFinall = PlayerPrefs.GetInt("notaFinalTemp"+idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosTemp"+idTema.ToString());

        txtNota.text = notaFinall.ToString();
        txtInfoTema.text = "Você acertou "+acertos.ToString()+" de 20 perguntas";

        if (notaFinall == 10)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        } else if (notaFinall >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        } else if (notaFinall >= 5) {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }
    }

    public void jogarNovamente()
    {
        Application.LoadLevel("T" + idTema.ToString());
    }
}
