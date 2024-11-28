/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
         // Check if the current position allows movement to the left (directions[0])
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions) && directions[0])
        {
            // Move left by decreasing the x-coordinate
            _currX--;
        }
        else
        {
            // Throw an exception if movement is not possible
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
         // Check if the current position allows movement to the right (directions[1])
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions) && directions[1])
        {
            // Move right by increasing the x-coordinate
            _currX++;
        }
        else
        {
            // Throw an exception if movement is not possible
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // Check if the current position allows movement up (directions[2])
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions) && directions[2])
        {
            // Move up by decreasing the y-coordinate
            _currY--;
        }
        else
        {
             // Throw an exception if movement is not possible
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
         // Check if the current position allows movement down (directions[3])
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions) && directions[3])
        {
            // Move down by increasing the y-coordinate
            _currY++;
        }
        else
        {
            // Throw an exception if movement is not possible
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}