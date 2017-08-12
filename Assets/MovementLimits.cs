using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Movement
{
    UP, DOWN, LEFT, RIGHT
}

public class MovementAllowed
{
    private String title;
    private Movement[] allowed;

    public MovementAllowed(String title, Movement[] allowed)
    {
        this.title = title;
        this.allowed = allowed;
    }

    public String getTitle()
    {
        return this.title;
    }

    public Movement[] getAllowedDirections()
    {
        return this.allowed;
    }
}

public class MovementLimits {

    // TODO: Alternative titles

    private static MovementAllowed rightOnly = new MovementAllowed("Right", new Movement[] { Movement.RIGHT });
    private static MovementAllowed leftOnly = new MovementAllowed("Left", new Movement[] { Movement.LEFT });
    private static MovementAllowed upOnly = new MovementAllowed("Up", new Movement[] { Movement.UP });
    private static MovementAllowed downOnly = new MovementAllowed("Down", new Movement[] { Movement.DOWN });

    private static MovementAllowed notRight = new MovementAllowed("Not Right", new Movement[] { Movement.UP, Movement.LEFT, Movement.DOWN });
    private static MovementAllowed notLeft = new MovementAllowed("Not Left", new Movement[] { Movement.UP, Movement.RIGHT, Movement.DOWN });
    private static MovementAllowed notUp = new MovementAllowed("Not Up", new Movement[] { Movement.RIGHT, Movement.LEFT, Movement.DOWN });
    private static MovementAllowed notDown = new MovementAllowed("Not Down", new Movement[] { Movement.UP, Movement.LEFT, Movement.RIGHT });

    private static MovementAllowed horizontalOnly = new MovementAllowed("Left or Right", new Movement[] { Movement.LEFT, Movement.RIGHT });
    private static MovementAllowed verticalOnly = new MovementAllowed("Up or Down", new Movement[] { Movement.UP, Movement.DOWN });


    private static MovementAllowed[] restrictions = {
        rightOnly,
        leftOnly,
        upOnly,
        downOnly,
        notRight,
        notLeft,
        notUp,
        notDown,
        horizontalOnly,
        verticalOnly
    };


    public static MovementAllowed getRandomRestriction()
    {
        return restrictions[UnityEngine.Random.Range(0, restrictions.Length)];
    }
}
