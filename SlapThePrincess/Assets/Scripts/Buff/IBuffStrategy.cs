public interface IBuffStrategy 
{
    float Cooldown {  get; set; }
    void ApplyBuff(Monster monster);
}
