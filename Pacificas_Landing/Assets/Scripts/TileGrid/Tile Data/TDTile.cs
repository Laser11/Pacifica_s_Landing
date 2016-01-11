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

