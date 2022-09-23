namespace DogDescriptionApi.Models
{

    public class VisitReasons
    {
        public List<string> GetVisitReasons()
        {
            var list = Enum.GetNames(typeof(VisitReason)).ToList();
            return list;
        }

        public VisitReason GetReason(string visitReason)
        {
            string reason = visitReason.ToUpper();
            VisitReason selectedReason = (VisitReason)Enum.Parse(typeof(VisitReason), reason);
            return selectedReason;
        }
    }
    public enum VisitReason
    {
        BORDATELLAVACCINE,
        RABIESVACCINE,
        PARVOVACCINE,
        LEPTOVACCINE,
        CHECKUP,
        OTHER,
        CUDDLES
    }
}
