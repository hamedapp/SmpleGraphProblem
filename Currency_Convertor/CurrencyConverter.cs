using QuickGraph;
using QuickGraph.Algorithms;
using System;
using System.Collections.Generic;

namespace Currency_Convertor
{
    public class CurrencyConverter: ICurrencyConverter
    {
        private static readonly CurrencyConverter instance = new CurrencyConverter();

        private CurrencyConverter()
        {
        }
        public static CurrencyConverter Instance
        {
            get
            {
                return instance;
            }
        }

        private AdjacencyGraph<string, Edge<string>> _graph = new AdjacencyGraph<string, Edge<string>>();
        private Dictionary<Edge<string>, double> _costs = new Dictionary<Edge<string>, double>();
        private void AddEdgeWithCosts(string source, string target, double cost)
        {
            var edge = new Edge<string>(source, target);
            _graph.AddVerticesAndEdge(edge);
            _costs.Add(edge, cost);
        }

        private void AddCost(Edge<string> edge, double cost)
        {
            _costs.Add(edge, cost);
        }

        public void ClearConfiguration()
        {
            _graph.Clear();
            _costs.Clear();
        }

        public double Convert(string fromCurrency, string toCurrency, double amount)
        {
            var edgeCost = AlgorithmExtensions.GetIndexer(_costs);
            var tryGetPath = _graph.ShortestPathsDijkstra(edgeCost, fromCurrency);

            var isPathExist = tryGetPath(toCurrency, out IEnumerable<Edge<string>> path);
            if (isPathExist)
            {
                double finalAount = amount;

                foreach (var item in path)
                {
                    var cost = _costs[item];
                    finalAount *= cost;
                }
                return finalAount;
            }
            else
            {
                Console.WriteLine("No path found from {0} to {1}.");
                return -1;
            }
        }

        public void UpdateConfiguration(IEnumerable<ValueTuple<string, string, double>> conversionRates)
        {
            foreach (var item in conversionRates)
            {
                bool rateExist = _graph.TryGetEdge(item.Item1, item.Item2, out Edge<string> prevEdge);

                if (rateExist)
                {
                    _graph.RemoveEdge(prevEdge);
                    AddEdgeWithCosts(item.Item1, item.Item2, item.Item3);
                    _costs[prevEdge] = item.Item3;

                    continue;
                }

                AddEdgeWithCosts(item.Item1, item.Item2, item.Item3);
            }
        }

        //public void UpdateConfiguration(IEnumerable<Tuple<string, string, double>> conversionRates)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
