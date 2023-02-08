using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject dogPlayerObject, catPlayerObject;
    private Player _dogPlayer;
    private CatPlayer _catPlayer;
    private bool isPlayerDog { get; set; } //isDog's turn
    void Start()
    {
        _dogPlayer = dogPlayerObject.GetComponent<Player>();
        _catPlayer = catPlayerObject.GetComponent<CatPlayer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPlayerDog = !isPlayerDog;
            print(isPlayerDog);
        }
        if (isPlayerDog)
        {
            _dogPlayer.enabled = false;
            _catPlayer.enabled = true;
        }
        else
        {
            _dogPlayer.enabled = true;
            _catPlayer.enabled = false;
        }
    }
}
