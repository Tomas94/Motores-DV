using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Power-ups disponibles
    public enum PowerUpType
    {
        Dash,
        WallBounce,
        DoubleJump
    }

    // Variable estática para acceder al GameManager desde otros scripts
    public static GameManager Instance { get; private set; }

    // Variables para rastrear los power-ups obtenidos
    private bool hasDashPowerUp;
    private bool hasWallBouncePowerUp;
    private bool hasDoubleJumpPowerUp;

    private void Awake()
    {
        // Verificar si ya existe una instancia del GameManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destruir este objeto si ya hay una instancia
            return;
        }

        Instance = this; // Establecer esta instancia como la única instancia
        DontDestroyOnLoad(gameObject); // Mantener el GameManager en las transiciones de escena
    }

    // Función para agregar un power-up al jugador
    public void AddPowerUp(PowerUpType powerUp)
    {
        switch (powerUp)
        {
            case PowerUpType.Dash:
                hasDashPowerUp = true;
                Debug.Log("Obtuviste el power-up: Dash");
                break;
            case PowerUpType.WallBounce:
                hasWallBouncePowerUp = true;
                Debug.Log("Obtuviste el power-up: Wall Bounce");
                break;
            case PowerUpType.DoubleJump:
                hasDoubleJumpPowerUp = true;
                Debug.Log("Obtuviste el power-up: Double Jump");
                break;
            default:
                Debug.Log("Power-up no reconocido");
                break;
        }
    }

    public bool HasDashPowerUp()
    {
        return hasDashPowerUp;
    }

    public bool HasWallBouncePowerUp()
    {
        return hasWallBouncePowerUp;
    }

    public bool HasDoubleJumpPowerUp()
    {
        return hasDoubleJumpPowerUp;
    }
}
