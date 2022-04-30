//using QuickGraph;
//using QuickGraph.Algorithms.ShortestPath;

//namespace Currency_Convertor
//{
//    public static class Extensions
//    {
//        class AStarWrapper<TVertex, TEdge>
//        where TEdge : IEdge<TVertex>
//        {
//            private TVertex target;
//            private AStarShortestPathAlgorithm<TVertex, TEdge> innerAlgorithm;
//            public AStarWrapper(AStarShortestPathAlgorithm<TVertex, TEdge> innerAlgo, TVertex root, TVertex target)
//            {
//                innerAlgorithm = innerAlgo;
//                this.innerAlgorithm.SetRootVertex(root);
//                this.target = target;
//                this.innerAlgorithm.FinishVertex += new VertexAction<TVertex>(innerAlgorithm_FinishVertex);
//            }
//            void innerAlgorithm_FinishVertex(TVertex vertex)
//            {
//                if (object.Equals(vertex, target))
//                    this.innerAlgorithm.Abort();
//            }
//            public double Compute()
//            {
//                this.innerAlgorithm.Compute();
//                return this.innerAlgorithm.Distances[target];
//            }
//        }

//        public static double ComputeDistanceBetween<TVertex, TEdge>(this AStarShortestPathAlgorithm<TVertex, TEdge> algo, TVertex start, TVertex end)
//            where TEdge : IEdge<TVertex>
//        {
//            var wrap = new AStarWrapper<TVertex, TEdge>(algo, start, end);
//            return wrap.Compute();
//        }
//    }
//}
