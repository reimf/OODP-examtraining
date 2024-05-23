public class Mushroom
{
    public string Name { get; set; }
    public string ScientificName { get; set; }
    public bool Edible { get; set; }
    public string CapColor { get; set; }
    public string CapShape { get; set; }
    public string StemColor { get; set; }
    public List<string> Habitat { get; set; }
    public List<string> Season { get; set; }
    public string SporePrintColor { get; set; }
    public string Odor { get; set; }
    public string Taste { get; set; }
    public int MinCapDiameterInCm { get; set; }
    public int MaxCapDiameterInCm { get; set; }
    public int MinHeightInCm { get; set; }
    public int MaxHeightInCm { get; set; }
    public int Toxicity { get; set; }
    public int AverageWeightInGrams { get; set; }
}
