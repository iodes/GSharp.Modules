using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;
using Accord.Statistics.Filters;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System.Data;
using System.Linq;

namespace GSharp.Modules.Accord
{
    public class GDecisionTree : GModule
    {
        [GCommand("{0}의 {1}열에서 {2}열을 학습")]
        public DecisionTree Learn(DataTable data, string[] inputColumns, string outputColumn)
        {
            var codebook = new Codification(data);
            var symbols = codebook.Apply(data);

            double[][] inputs = symbols.ToJagged(inputColumns);
            int[] outputs = symbols.ToArray<int>(outputColumn);

            var attributes = DecisionVariable.FromCodebook(codebook, inputColumns);
            var c45 = new C45Learning(attributes);

            return c45.Learn(inputs, outputs);
        }

        [GCommand("{0}모델로 {1}값의 결과 예측")]
        public int Decide(DecisionTree tree, double[] inputs)
        {
            return tree.Decide(inputs);
        }
    }
}
