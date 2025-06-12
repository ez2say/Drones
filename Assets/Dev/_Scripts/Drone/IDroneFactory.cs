public interface IDroneFactory
{
    IDrone Create(IBase homeBase, bool isTeamA);
}