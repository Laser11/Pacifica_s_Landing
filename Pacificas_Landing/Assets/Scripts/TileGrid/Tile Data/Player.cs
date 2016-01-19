using UnityEngine;
using System.Collections;



public class Player
{

    private int health;
    private int attack;
    private int movement;
    private Vector3 position;
    private GameObject playerObject = GameObject.CreatePrimitive(PrimitiveType.Cube);//(GameObject)Resources.Load("/Objects/Prefabs/Players.prefab");
    private int maxHealth;

    public Player(int maxHealth, Vector3 position)
    {

        setPosition(position);
        setMaxHealth(maxHealth);
        setHealth(maxHealth);
        GameObject.Instantiate(playerObject,position, Quaternion.identity);

    }

    public Player(Player copy)
    {
        if (copy != null)
        {
            setPosition(copy.getPosition());
            setMaxHealth(copy.getMaxHealth());
            setHealth(copy.getMaxHealth());
            playerObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject.Instantiate(playerObject, position, Quaternion.identity);
        }
    }
    public int getHealth()
    {
        return this.health;
    }

    public int getMaxHealth()
    {
        return this.maxHealth;
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public Vector3 getPosition()
    {
        return this.position;
    }

    public void setPosition(Vector3 position)
    {
        this.position = position;
        GameObject.Instantiate(playerObject, position, Quaternion.identity);
    }

    public GameObject getPlayerObject()
    {
        return this.playerObject;
    }

    public void destroyPlayerObject()
    {
        GameObject.DestroyImmediate(playerObject);
    }

    public void setPlayerObject(GameObject playerObject)
    {
        this.playerObject = playerObject;
        
    }

}
