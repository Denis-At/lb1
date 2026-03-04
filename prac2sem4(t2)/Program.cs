using System;

public class DamageEventArgs : EventArgs
{
    public int DamageTaken { get; }
    public int CurrentHP { get; }
    public DamageEventArgs(int damage, int hp)
    {
        DamageTaken = damage;
        CurrentHP = hp;
    }
}

public class Player
{
    public event EventHandler<DamageEventArgs> OnDamaged;
    public int Health { get; private set; } = 100;

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0) Health = 0;
        OnDamaged?.Invoke(this, new DamageEventArgs(amount, Health));
    }
}

public class UIHealthBar
{
    public void UpdateUI(object sender, DamageEventArgs e)
    {
        Console.WriteLine($"[UI] Health: {e.CurrentHP}%");
    }
}

public class SoundSystem
{
    public void PlaySound(object sender, DamageEventArgs e)
    {
        Console.WriteLine("[Sound] Damage sound played");
        if (e.CurrentHP <= 20 && e.CurrentHP > 0)
            Console.WriteLine("[Sound] Critical health sound played");
    }
}

public class AchievementSystem
{
    private bool _halfHealthReached = false;
    private bool _firstDeathReached = false;

    public void CheckAchievements(object sender, DamageEventArgs e)
    {
        if (e.CurrentHP <= 50 && !_halfHealthReached)
        {
            Console.WriteLine("[Achievement] Unlocked: Half Health");
            _halfHealthReached = true;
        }
        if (e.CurrentHP <= 0 && !_firstDeathReached)
        {
            Console.WriteLine("[Achievement] Unlocked: First Death");
            _firstDeathReached = true;
        }
    }
}

public class GameLogger
{
    public void LogData(object sender, DamageEventArgs e)
    {
        Console.WriteLine($"[Log] Damage: {e.DamageTaken}, HP: {e.CurrentHP}");
    }
}

class Program
{
    static void Main()
    {
        Player player = new Player();
        UIHealthBar ui = new UIHealthBar();
        SoundSystem sound = new SoundSystem();
        AchievementSystem achievements = new AchievementSystem();
        GameLogger logger = new GameLogger();

        player.OnDamaged += ui.UpdateUI;
        player.OnDamaged += sound.PlaySound;
        player.OnDamaged += achievements.CheckAchievements;
        player.OnDamaged += logger.LogData;

        player.TakeDamage(30);
        player.TakeDamage(25);
        player.TakeDamage(30);
        player.TakeDamage(20);
    }
}