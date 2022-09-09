using Godot;
using System;

public class Mario : KinematicBody2D
{
[Export] public int speed = 200;

    public Vector2 velocity = new Vector2();

    public void GetInput()
    {
        velocity = new Vector2();

        if (Input.IsKeyPressed((int)KeyList.D))
            velocity.x += 1;

        if (Input.IsKeyPressed((int)KeyList.A))
            velocity.x -= 1;

        if (Input.IsKeyPressed((int)KeyList.S))
            velocity.y += 1;

        if (Input.IsKeyPressed((int)KeyList.W))
            velocity.y -= 1;

        velocity = velocity.Normalized() * speed;
    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput(); 
        velocity = MoveAndSlide(velocity);
    }

}
