using HundredConvicts.Domain;

namespace HundredConvicts.Services
{
    public class BoxService: IBoxService
    {
        public List<Box> CreateBoxes(int numberOfBoxes)
        {             
            var boxes = new List<Box>();
            for (int i = 0; i < numberOfBoxes; i++)
            {
                boxes.Add(new Box { BoxIndex = i, TicketNumber = i });
            }
            MixTickets(boxes);
            MixTickets(boxes);
            MixTickets(boxes);
            MixTickets(boxes);
            MixTickets(boxes);
            return boxes;
        }

        public SequenceTry CreateSequenceTry(int convictIndex, List<Box> availableBoxes)
        {
            var luckyTicketFound = false;
            var currentBox = availableBoxes[convictIndex];
            var resultSequence = new SequenceTry { Boxes = [ currentBox ] };
            luckyTicketFound = currentBox.TicketNumber == convictIndex;
            while (!luckyTicketFound)
            {
                // get next box
                currentBox = availableBoxes[currentBox.TicketNumber];
                luckyTicketFound = currentBox.TicketNumber == convictIndex;
                resultSequence.Boxes.Add(currentBox);
            }
            return resultSequence;
        }

        private void MixTickets(List<Box> boxes)
        {
            for (var i = 0; i < boxes.Count; i++)
            {
                var random = new Random();
                var randomIndex = random.Next(0, boxes.Count);
                var tempTicket = boxes[i].TicketNumber;
                boxes[i].TicketNumber = boxes[randomIndex].TicketNumber;
                boxes[randomIndex].TicketNumber = tempTicket;
            }
        }
    }

    
}
