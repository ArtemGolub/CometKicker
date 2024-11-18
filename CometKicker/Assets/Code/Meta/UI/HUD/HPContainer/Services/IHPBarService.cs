using Code.Meta.UI.HUD.HPContainer;

public interface IHPBarService
{
    HPBarController SetHPBar(HPBarController hpBarController);
    HPBarController GetHPBar();
}