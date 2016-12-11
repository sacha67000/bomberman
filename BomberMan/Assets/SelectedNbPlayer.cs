using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectedNbPlayer : MonoBehaviour {

    private int nb_players;

    public Text text;

    void Start()
    {
        nb_players = 2;
        PlayerPrefs.SetInt("Players", nb_players);
        text.text = "Players : " + nb_players;
    }

    public void IncreaseNbPlayers()
    {
        if (nb_players < 4)
        {
            nb_players++;
            PlayerPrefs.SetInt("Players", nb_players);
            text.text = "Players : " + nb_players;
        }
    }

    public void DecreaseNbPlayers()
    {
        if (nb_players > 2)
        {
            nb_players--;
            PlayerPrefs.SetInt("Players", nb_players);
            text.text = "Players : " + nb_players;
        }
    }

    public int GetNbPlayers()
    {
        return nb_players;
    }
}
