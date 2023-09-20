using EvalExpression.Extensions;
using Parser.Exceptions;
using @core = EvalExpression.EvalExpression;

namespace Integration
{
    public class IntegrationTests
    {
        [Fact]
        public void SimpleEvaluation()
        {
            var input = "1+2*3";

            var expected = 7m;

            var actual = core.Build(input).Evaluate();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ComplexOperatorPrecedence()
        {
            var input = "1+2*3+((2+3)-2^3+(4*4-(3^2)))";

            var expected = 11m;

            var actual = core.Build(input).Evaluate();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UnaryOperator()
        {
            var input = "-(1+2*3)";

            var expected = -7m;

            var actual = core.Build(input).Evaluate();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SyntaxException()
        {
            var input = "-(1+2*3a32)";

            Assert.Throws<SyntaxException>(() => core.Build(input).Evaluate());
        }
    }
}