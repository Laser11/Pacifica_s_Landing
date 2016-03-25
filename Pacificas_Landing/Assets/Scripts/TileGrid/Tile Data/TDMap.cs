public class TDMap
{
    public TDTile[] tiles;
    int _width;
    int _height;

    public TDMap(int width, int height)
    {
        _width = width;
        _height = height;

        tiles = new TDTile[_width * _height];
        for (int i = 0; i < _width * _height; i++)
        {
            setTile(i, 1, 0);
        }
        setTile(733, 1, 1);
        setTile(735, 1, 2);
    }

    public TDTile getTile(int x, int y)
    {
        if (x < 0 || x >= _width || y < 0 || y >= _height)
        {

            return null;
        }
        return tiles[y * _width + x];
    }

    public TDTile getTile(int pos)
    {
        if (pos < 0 || pos >= _width * _height)
        {
            return null;
        }
        return tiles[pos];
    }

    public int getWidth()
    {
        return _width;
    }

    public int getHeight()
    {
        return _height;
    }

    public void setTile(int pos, int type)
    {
        tiles[pos] = new TDTile(type);
    }

    public void setTile(int pos, int type, int occupied)
    {
        tiles[pos] = new TDTile(type, occupied, pos % _width, pos / _width, _width, _height, pos);
    }


}

