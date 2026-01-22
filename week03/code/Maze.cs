using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        // index 0 = left
        if (_mazeMap[(_currX, _currY)][0])
            _currX--;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveRight()
    {
        // index 1 = right
        if (_mazeMap[(_currX, _currY)][1])
            _currX++;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveUp()
    {
        // index 2 = up
        if (_mazeMap[(_currX, _currY)][2])
            _currY--;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveDown()
    {
        // index 3 = down
        if (_mazeMap[(_currX, _currY)][3])
            _currY++;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
