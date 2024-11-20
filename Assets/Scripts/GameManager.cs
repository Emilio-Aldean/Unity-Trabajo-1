using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text textScore;

    void Start()
    {
        if (textScore == null)
        {
            Debug.LogError("TextScore no está asignado en el Inspector.");
        }
    }

    public void AddScore()
    {
        score++;
        if (textScore != null)
        {
            textScore.text = score.ToString();
        }
        else
        {
            Debug.LogError("No se pudo actualizar el puntaje porque TextScore es nulo.");
        }
    }
}
