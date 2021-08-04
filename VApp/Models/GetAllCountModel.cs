namespace VApp.Models
{
    public class GetAllCountModel
    {
        public int TotalEmployee { get; set; }
        public int NotYetVaccinated { get; set; }
        public int CovaxinDose1Count { get; set; }
        public int CovaxinDose2Count { get; set; }
        public int CovisheildDose1Count { get; set; }
        public int CovisheildDose2Count { get; set; }
        public int SputnikDose1Count { get; set; }
        public int SputnikDose2Count { get; set; }
        public double FirstDoseVaccinationPercentage
        {
            get { return (CovaxinDose1Count + CovisheildDose1Count + SputnikDose1Count) / TotalEmployee; }
        }
        public double SecondDoseVaccinationPercentage
        {
            get { return (CovaxinDose2Count + CovisheildDose2Count + SputnikDose2Count) / TotalEmployee; }
        }
        public double NotYetVaccinatedPercentage
        {
            get { return NotYetVaccinated / TotalEmployee; }
        }

        public int FisrtDoseTotal
        {
            get { return CovaxinDose1Count + CovisheildDose1Count + SputnikDose1Count; }
        }
        public int SecondDoseTotal
        {
            get { return CovaxinDose2Count + CovisheildDose2Count + SputnikDose2Count; }
        }

        public int CovaxinTotal
        {
            get { return CovaxinDose1Count + CovaxinDose2Count; }
        }

        public int CovisheildTotal
        {
            get { return CovisheildDose1Count + CovisheildDose2Count; }
        }

        public int SputnikTotal
        {
            get { return SputnikDose1Count + SputnikDose2Count; }
        }

    }
}
