using Godot;
using System;

public class Mario : KinematicBody2D
{
    PackedScene Bulletscene;

    [Export] public int speed = 200;

    public Vector2 velocity = new Vector2();

    public static bool dash;

    public float health = 10;



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

        if (health <= 0)
        {
            QueueFree();
        }

    }
    

    public override void _Ready()
    {
        Bulletscene = GD.Load<PackedScene>("res://Bullet.tscn");

        Timer timer = this.GetNode<Timer>("Timer");
        timer.WaitTime = 1;
        timer.Connect("timeout", this, "on_timeout");
        timer.Start();
    }

    public static void on_timeout()
    {
        dash = true;
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
            if (mouseButton.ButtonIndex == (int)ButtonList.Right && mouseButton.Pressed && dash)
            {
                Vector2 moveDirection = (GetGlobalMousePosition() - Position).Normalized();
                Position += moveDirection * 250;
                dash = false;
            }
        }

    }
}
