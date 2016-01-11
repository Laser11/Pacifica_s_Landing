using UnityEngine;
using System.Collections;

public class TDSelector : MonoBehaviour
{

    public bool playerSelected;
    TGMap _TGMap;
    TDMap map;
    TDPath path;
    int moving = -1;
    TDTile occupy;

    Vector3 currentTileCoord;
    Vector3 playerSelectedCoord;
    public Transform selectionCube;
    // Use this for initialization
    void Start()
    {
        _TGMap = GetComponent<TGMap>();

    }

    // Update is called once per frame
    void Update()
    {
        bool firstRun = true;
        if (firstRun)
        {
            map = _TGMap.getMapData();
            firstRun = false;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (_TGMap.GetComponent<Collider>().Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            int x = Mathf.FloorToInt(hitInfo.point.x / _TGMap.tileSize);
            int z = Mathf.FloorToInt(hitInfo.point.z / _TGMap.tileSize);

            currentTileCoord.x = x;
            currentTileCoord.z = z;
            selectionCube.transform.position = currentTileCoord * _TGMap.tileSize;
        }
        else
        {

        }

        if (Input.GetMouseButtonDown(0))
        {
            occupy = map.getTile((int)playerSelectedCoord.x, (int)playerSelectedCoord.z);
            if (map.getTile((int)currentTileCoord.x, (int)currentTileCoord.z).getOccupied() == 1)
            {
                playerSelected = true;
                Debug.Log("Player Selected" + map.getTile((int)currentTileCoord.x, (int)currentTileCoord.z));
                playerSelectedCoord = new Vector3(currentTileCoord.x, 0, currentTileCoord.z);

            }
            else if (map.getTile((int)currentTileCoord.x, (int)currentTileCoord.z).getOccupied() == 0 && playerSelected == true)
            {
                playerSelected = false;
                Debug.Log("Player Moved New coord: " + map.getTile((int)currentTileCoord.x, (int)currentTileCoord.z));
                Debug.Log("Player Moved Old coord: " + map.getTile((int)playerSelectedCoord.x, (int)playerSelectedCoord.z));
                path = checkPath(map, map.getTile((int)playerSelectedCoord.x, (int)playerSelectedCoord.z), 7);

                if (path != null)
                {
                    Debug.Log(path);
                    Debug.Log(path.path[0]);
                    moving = path.path.Count - 1;
                }

            }

        }
        if (moving >= 0)
        {
            Debug.Log(moving);
            occupy.setOccupied(0);
            occupy = (TDTile)path.getPath()[moving];
            occupy.setOccupied(1);
            _TGMap.UpdateGraphics();
            moving -= 1;
        }
    }

    public TDPath checkPath(TDMap map, TDTile start, int maxStamina)
    {
        TDTile selected = new TDTile();
        TDTile finalSelected = new TDTile();
        TDTile pathRun = new TDTile();
        ArrayList finalPath = new ArrayList();
        ArrayList unvisited = new ArrayList();
        for (int i = start.position - maxStamina - maxStamina * map.getWidth(); i < start.position + maxStamina + maxStamina * map.getWidth(); i++)
        {
            if (i > 0 && i < map.getWidth() * map.getHeight())
            {
                map.getTile(i).distance = 20000;
                map.getTile(i).previousTile = null;
                unvisited.Add(map.getTile(i));
            }
            Debug.Log("On position " + i);
            if (i % map.getWidth() == start.x + maxStamina)
            {

                i += map.getWidth() - maxStamina * 2 - 1;
                Debug.Log("Switched Rows " + i);

            }
        }
        map.getTile(start.position).distance = 0;
        int looped = 0;
        int finalDistance = -1;
        while (unvisited.Count > 0 && !selected.equals(map.getTile((int)currentTileCoord.x, (int)currentTileCoord.z)) && selected.distance < maxStamina)
        {
            looped++;
            selected.distance = 200000;
            for (int i = 0; i < unvisited.Count; i++)
            {
                TDTile comparing = (TDTile)unvisited[i];
                if (comparing.distance < selected.distance)
                {

                    selected = comparing;
                    if (selected.equals(map.getTile((int)currentTileCoord.x, (int)currentTileCoord.z)))
                    {
                        if (selected.distance > maxStamina)
                        {
                            return null;
                        }
                        finalDistance = selected.distance;
                        finalSelected = selected;
                        pathRun = finalSelected;
                        while (pathRun.previousTile != null)
                        {
                            finalPath.Add(pathRun);
                            pathRun = pathRun.previousTile;
                        }

                        return new TDPath(finalPath, finalDistance);
                    }
                    Debug.Log(" Selected: " + selected + " " + selected.distance + "looped: " + looped);
                }
                unvisited.Remove(selected);
                for (int j = 0; j < selected.findNeighbors().Length; j++)
                {
                    TDTile neighbor = map.getTile(selected.findNeighbors()[j]);
                    if (neighbor != null)
                    {
                        if (unvisited.Contains(neighbor))
                        {
                            int alternate = selected.distance + 1;
                            if (alternate < neighbor.distance)
                            {
                                neighbor.distance = alternate;
                                neighbor.previousTile = selected;
                            }

                        }
                    }
                }
            }
        }
        return null;

    }
}
