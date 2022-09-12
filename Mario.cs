using Godot;
using System;

public class Mario : KinematicBody2D
{
    PackedScene Bulletscene;

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

    public override void _Ready()
    {
        Bulletscene = GD.Load<PackedScene>("res://Bullet.tscn");

    }


    public override void _UnhandledInput(InputEvent @event)
    {        
        base._UnhandledInput(@event);
        
            if (@event is InputEventKey arrows)
            {
                if (arrows.Pressed && arrows.Scancode == (int)KeyList.Right)
                {
                    Bullet bullet = (Bullet)Bulletscene.Instance();
                    bullet.Position = Position;
                    bullet.RotationDegrees = 0;
                    GetParent().AddChild(bullet);
                    GetTree().SetInputAsHandled();
                }
                if (arrows.Pressed && arrows.Scancode == (int)KeyList.Left)
                {
                    Bullet bullet = (Bullet)Bulletscene.Instance();
                    bullet.Position = Position;
                    bullet.RotationDegrees = 180;
                    GetParent().AddChild(bullet);
                    GetTree().SetInputAsHandled();
                }
                if (arrows.Pressed && arrows.Scancode == (int)KeyList.Up)
                {
                    Bullet bullet = (Bullet)Bulletscene.Instance();
                    bullet.Position = Position;
                    bullet.RotationDegrees = -90;
                    GetParent().AddChild(bullet);
                    GetTree().SetInputAsHandled();
                }
                if (arrows.Pressed && arrows.Scancode == (int)KeyList.Down)
                {
                    Bullet bullet = (Bullet)Bulletscene.Instance();
                    bullet.Position = Position;
                    bullet.RotationDegrees = 90;
                    GetParent().AddChild(bullet);
                    GetTree().SetInputAsHandled();
                }
            }
        

    }

}
