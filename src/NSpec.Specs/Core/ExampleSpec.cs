using System;
using NSpec.Core;
using NSubstitute;
using NUnit.Framework;

namespace NSpec.Specs.Core
{
    public class ExampleSpec : Spec
    {
        Example example;
        IExpectation failingExpectation;
        IExpectation passingExpectation;

        [SetUp]
        public void setup()
        {
            example = new Example();

            failingExpectation = CreateSubstituteExpectation(e => e.IsFail.Returns(true));
            passingExpectation = CreateSubstituteExpectation(e => e.IsPass.Returns(true));
        }

        [Test]
        public void should_pass_when_all_expectations_pass()
        {
            example.AddExpectation(passingExpectation);

            specify(() => example.IsPass);
        }

        [Test]
        public void should_fail_when_any_expectations_fail()
        {
            example.AddExpectation(passingExpectation);
            example.AddExpectation(failingExpectation);

            specify(() => example.IsFail);
        }

        [Test]
        public void should_run_all_expectations_when_running_example()
        {
            example.AddExpectation(passingExpectation);
            example.AddExpectation(failingExpectation);

            example.Run();

            specify(() => passingExpectation.Received().Run());
            specify(() => failingExpectation.Received().Run());
        }

        IExpectation CreateSubstituteExpectation(Action<IExpectation> initialize)
        {
            var expectation = Substitute.For<IExpectation>();
            initialize(expectation);

            return expectation;
        }
    }
}