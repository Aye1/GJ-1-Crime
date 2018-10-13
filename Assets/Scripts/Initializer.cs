using Assets.Scripts.Utils;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    public Hole BaseHole;
    public int xMin, xMax, yMin, yMax;
    public Vector2 respawn;

    private bool[,] _gridIsPath;
    private bool _isStraightLine = true;
    private int _deltaX, _deltaY;

    void Start()
    {
        _deltaX = xMax - xMin;
        _deltaY = yMax - yMin;
        BaseHole.RespawnPosition = respawn;

        CreateGrid();
        for (int currX = 0; currX < _deltaX; currX++)
        {
            for (int currY = 0; currY < _deltaY; currY++)
            {
                if (!_gridIsPath[currX, currY])
                {
                    AddHoleTo(new Vector2(xMin + currX, yMin + currY));
                }
            }
        }
    }

    private void AddHoleTo(Vector2 position)
    {
        Instantiate(BaseHole, new Vector3(position.x, position.y, 1), Quaternion.identity, this.transform);
    }

    private void CreateGrid()
    {
        _gridIsPath = new bool[_deltaX, _deltaY];
        int midY = Mathf.FloorToInt((_deltaY) / 2);
        _gridIsPath[0, midY] = true;
        _gridIsPath[1, midY] = true;

        Vector2Int currentLoc = new Vector2Int(1, midY);

        while (currentLoc.x != _deltaX - 1)
        {
            var validDirections = GetValidDirectionsFrom(currentLoc);
            int myNextDirIndex = Random.Range(0, validDirections.Count());
            switch (validDirections[myNextDirIndex])
            {
                case Directions.Up:
                    _gridIsPath[currentLoc.x, currentLoc.y + 1] = true;
                    currentLoc.y++;
                    break;
                case Directions.Down:
                    _gridIsPath[currentLoc.x, currentLoc.y - 1] = true;
                    currentLoc.y--;
                    break;
                case Directions.Left:
                    _gridIsPath[currentLoc.x - 1, currentLoc.y] = true;
                    currentLoc.x--;
                    break;
                case Directions.Right:
                    _gridIsPath[currentLoc.x + 1, currentLoc.y] = true;
                    currentLoc.x++;
                    break;
            }
        }
    }

    private List<Directions> GetValidDirectionsFrom(Vector2Int currentLoc)
    {
        var results = new List<Directions>();

        if (currentLoc.x > 1
            && !_gridIsPath[currentLoc.x - 1, currentLoc.y]
            && currentLoc.y + 1 > _deltaY
            && !_gridIsPath[currentLoc.x - 1, currentLoc.y + 1]
            && currentLoc.y - 1 > 1
            && !_gridIsPath[currentLoc.x - 1, currentLoc.y - 1])
        {
            results.Add(Directions.Left);
        }

        if (currentLoc.y > 1
            && !_gridIsPath[currentLoc.x, currentLoc.y - 1]
            && !_gridIsPath[currentLoc.x - 1, currentLoc.y - 1]
            && !_gridIsPath[currentLoc.x + 1, currentLoc.y - 1])
        {
            results.Add(Directions.Down);
            _isStraightLine = false;
        }

        if (currentLoc.y < _deltaY - 1
            && !_gridIsPath[currentLoc.x, currentLoc.y + 1]
            && !_gridIsPath[currentLoc.x - 1, currentLoc.y + 1]
            && !_gridIsPath[currentLoc.x + 1, currentLoc.y + 1])
        {
            results.Add(Directions.Up);
            _isStraightLine = false;
        }

        if (currentLoc.x < _deltaX - 1
            && !_isStraightLine
            && !_gridIsPath[currentLoc.x + 1, currentLoc.y]
            && (currentLoc.y + 1 >= _deltaY || !_gridIsPath[currentLoc.x + 1, currentLoc.y + 1])
            && (currentLoc.y - 1 <= 0 || !_gridIsPath[currentLoc.x + 1, currentLoc.y - 1]))
        {
            results.Add(Directions.Right);
        }

        return results;
    }
}
