using Code.Meta.UI.HUD.HPContainer;

public class HPBarService : IHPBarService
{
    private HPBarController _hpBarController;
    public HPBarController SetHPBar(HPBarController hpBarController)
    {
        _hpBarController = hpBarController;
        return _hpBarController;
    }
    public HPBarController GetHPBar()
    {
        return _hpBarController;
    }   
}
