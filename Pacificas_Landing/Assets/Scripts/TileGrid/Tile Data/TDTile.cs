﻿using UnityEngine;
public class TDTile
{

    public const int TILE_OCEAN = 0;
    public const int TILE_GRASS = 1;
    public const int TILE_PLAIN = 2;
    public const int TILE_MOUNT = 3;
    public int type = TILE_GRASS;

    public const int EMPTY = 0;
    public const int PLAYER = 1;
    public const int ENEMY = 2;
    public int occupied = PLAYER;

    public int mapWidth;
    public int mapHeight;
    public int width;
    public int height;
    public int x;
    public int y;
    public int position;
    public int distance;
    public TDTile previousTile;
    public Player player;
    public Enemy enemy;


    public TDTile()
    {
        type = TILE_GRASS;
        occupied = PLAYER;

    }

    public TDTile(int type)
    {
        this.type = type;

    }

    public TDTile(int type, int occupied)
    {
        this.type = type;
        this.occupied = occupied;
    }

    public TDTile(int type, int occupied, int x, int y, int width, int height, int position)
    {
        this.type = type;
        this.occupied = occupied;
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.position = position;
        if(occupied == 1)
        {
            this.player = new Player(5, new Vector3(x,0,y));
        }
        else if (occupied == 2)
        {
            this.enemy = new Enemy(5, new Vector3(x, 0, y));
        }
    }


    public int getType()
    {
        return this.type;
    }

    public int getOccupied()
    {
        return this.occupied;
    }

    public void setType(int type)
    {
        this.type = type;

    }

    public Player getPlayer()
    {
        return this.player;
    }

    public Enemy getEnemy()
    {
        return this.enemy;
    }

    public void setEnemy(Enemy enemy)
    {
        this.enemy = new Enemy(enemy);
    }
    public void setPlayer(Player player)
    {
        this.player = new Player(player);
    }

    public void removePlayer()
    {
        if (player != null)
        {
            player.destroyPlayerObject();
            this.player = null;
        }
    }

    public void switchPlayers(TDTile other)
    {
        Player switchPlayer = this.getPlayer();
        this.setPlayer(other.getPlayer());
        other.setPlayer(switchPlayer);
    }

    public void setOccupied(int occupied)
    {
        this.occupied = occupied;
    }

    public bool equals(TDTile other)
    {
        if (this.position == other.position)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int[] findNeighbors()
    {
        int[] positions = new int[4];
        positions[0] = position - width;
        positions[1] = position - 1;
        positions[2] = position + 1;
        positions[3] = position + width;
        return positions;
    }

    override
    public string ToString()
    {
        return "Tile: " + getType() + " Occupied: " + getOccupied() + " Position: " + position + " Distance: " + distance;
    }


}

