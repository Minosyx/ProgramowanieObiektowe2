using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance { get; private set; }
    internal int playerHealth = 3;
    internal int acorns;
    private Tilemap numbers;
    [SerializeField] TileBase[] tiles;
    [SerializeField] GameObject heartPref;
    private Vector2 lastHeartPos;
    private int lastHeartNum = 0;
    private GameObject healthBar;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("There's more than one instance running!");
        Instance = this;
    }

    private void Start()
    {
        numbers = GameObject.Find("Numbers").GetComponent<Tilemap>();
        acorns = GameObject.FindGameObjectsWithTag("Acorn").Length;
        healthBar = GameObject.Find("Health");
        lastHeartPos = healthBar.transform.position;
        AddHeart(playerHealth);
        InsertTile();
    }

    private void FixedUpdate()
    {
        var keyboard = Keyboard.current;
        if (keyboard.escapeKey.isPressed)
            Application.Quit();
    }

    public void OnHealthChange(int amount)
    {
        if (playerHealth == 5 && amount > 0)
            return;
        playerHealth += amount;
        if (amount > 0)
            AddHeart(amount);
        else if (amount < 0)
            DeleteHeart(amount * -1);
        if (playerHealth <= 0)
            SceneRestart();
    }

    private void DeleteHeart(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var obj = GameObject.Find($"Heart{GameObject.Find("Health").transform.childCount - 1 - i}");
            lastHeartNum--;
            Destroy(obj);
        }
        lastHeartPos = new Vector2(lastHeartPos.x - amount, lastHeartPos.y);
    }

    private void AddHeart(int amount)
    {
        float lastX = lastHeartPos.x;
        for (int i = 0; i < amount; i++)
        { 
            var heart = Instantiate(heartPref, healthBar.transform);
            heart.transform.localPosition = new Vector3(lastX++, lastHeartPos.y);
            heart.name = $"Heart{lastHeartNum++}";
            heart.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
        }
        lastHeartPos = new Vector2(lastX, lastHeartPos.y);
    }

    public void AcornsLeft()
    {
        acorns -= 1;
        InsertTile();
        if (acorns == 0)
            GameClose();
    }

    public int GetPlace(int value, int place)
    {
        return ((value % (place * 10)) - (value % place)) / place;
    }

    public void InsertTile()
    {
        int st = GetPlace(acorns, 1);
        int nd = GetPlace(acorns, 10);
        numbers.SetTile(new Vector3Int(1, 0, 0), tiles[nd]);
        numbers.SetTile(new Vector3Int(2, 0, 0), tiles[st]);
    }
    public void GameClose()
    {
        Application.Quit();
    }
    public void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
