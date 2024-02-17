using System.Text;
using System.Text.RegularExpressions;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }

        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }
        public int GetCount=>Species.Count;

        public void AddShark(Shark shark)
        {
            if (Species.Count < Capacity)
            {
                if (!Species.Contains(shark))
                { Species.Add(shark); }
            }
        }

        public bool RemoveShark(string kind)
        {
            var shark = Species.FirstOrDefault(x=>x.Kind == kind);
            if (Species.Contains(shark))
            {
                Species.Remove(shark);
                return true;
            }
             return false;
        }

        public string GetLargestShark()
        {
            int largest = 0;
            foreach (var sh in Species)
            {
                if (sh.Length > largest)
                { largest = sh.Length; }
            }
            Shark shark = Species.FirstOrDefault(x=>x.Length==largest);
            return shark.ToString().TrimEnd();
        }

        public double GetAverageLength()
        {
            double lengthSum = 0;
            foreach (var item in Species)
            {
                lengthSum += item.Length;
            }
            double average = lengthSum / Species.Count;
            return average;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Species.Count} sharks classified:");
            foreach (var shark in Species)
            {
                sb.AppendLine(shark.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
