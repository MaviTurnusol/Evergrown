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

        Rotation = (GetGlobalMousePosition() - GlobalPosition).Angle();
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
        
            if (@event is InputEventMouseButton mouseButton)
            {
                if (mouseButton.ButtonIndex == (int)ButtonList.Left && mouseButton.Pressed)
                {
                    Bullet bullet = (Bullet)Bulletscene.Instance();
                    bullet.Position = Position;
                    bullet.Rotation = Rotation;
                    GetParent().AddChild(bullet);
                    GetTree().SetInputAsHandled();
                }
                if (mouseButton.ButtonIndex == (int)ButtonList.Right && mouseButton.Pressed)
                {
                GetGlobalMousePosition();
               
                Position = new Vector2(GetGlobalMousePosition());
                }

            }


    }

}
