using Godot;
using System;

public class RedPanda : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    float distancex;
    float distancey;
    static float xpos;
    static float ypos;
    Vector2 velocity = new Vector2();
    public static Vector2 pluer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        PackedScene Mario = (PackedScene)GD.Load("Mario.tscn");
        KinematicBody2D Player = (KinematicBody2D)Mario.Instance();
        pluer = GetTree().Root.GetNode("World").GetNode<KinematicBody2D>("Mario").Position;

        distancex = (pluer.x - Position.x);
        distancey = (pluer.y - Position.y);

        xpos = Position.x;
        ypos = Position.y;

        Vector2 right = new Vector2(Position.x + 10, Position.y);
        Vector2 left = new Vector2(Position.x -10, Position.y);
        Vector2 up = new Vector2(Position.x, Position.y -10);
        Vector2 down = new Vector2(Position.x, Position.y + 10);

        if((Position.y < pluer.y - 2) || (Position.y > pluer.y+2))
        {
            if(distancey > 2)
            {
                velocity = Position.DirectionTo(down) * 200;
            }
            if(distancey <= -2)
            {
                velocity = Position.DirectionTo(up) * 200;
            }
        } else {
            if(distancex > 0)
            {
                velocity = Position.DirectionTo(right) * 200;
                LookAt(right);
            }
            if(distancex <= 0)
            {
                velocity = Position.DirectionTo(left) * 200;
            }
        }
        velocity = MoveAndSlide(velocity);
        GD.Print(distancex + "adasdasd" + distancey);
    }
}
