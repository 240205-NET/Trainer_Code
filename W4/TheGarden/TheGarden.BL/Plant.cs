using System.Drawing;

namespace TheGarden.BL
{
    public class Plant
    {
        // Fields
        public int? PlantID { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public int Zone { get; set; }
        public Size Size { get; set; }
        public DateTime AdoptionDate { get; set; }

        // Constructor
        public Plant()
        { }

        public Plant(string scientificName, string commonName, int zone, Size size, DateTime adoptionDate)
        {
            ScientificName = scientificName;
            CommonName = commonName;
            Zone = zone;
            Size = size;
            AdoptionDate = adoptionDate;
        }

        public Plant(int plantId, string scientificName, string commonName, int zone, Size size, DateTime adoptionDate)
        {
            PlantID = plantId;
            ScientificName = scientificName;
            CommonName = commonName;
            Zone = zone;
            Size = size;
            AdoptionDate = adoptionDate;
        }

        // Methods

    }
}
