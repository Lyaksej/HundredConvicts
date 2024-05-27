using HundredConvicts.Domain;

namespace HundredConvicts.Services
{
    public interface IBoxService
    {
        List<Box> CreateBoxes(int numberOfBoxes);
        SequenceTry CreateSequenceTry(int convictIndex, List<Box> availableBoxes);
    }
}
