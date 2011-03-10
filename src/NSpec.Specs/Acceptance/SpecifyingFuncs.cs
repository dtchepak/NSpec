using System;
using NUnit.Framework;

namespace NSpec.Specs.Acceptance
{
    public class SpecifyingFuncs : Spec
    {
        [Test]
        public void should_pass_when_specifying_func_that_returns_true()
        {
            var result = this.Execute(specify_func_that_returns_true);

            specify(() => result);
        }

        void specify_func_that_returns_true()
        {
            specify(() => true);
        }

        [Test]
        [Pending]
        public void should_fail_when_specifying_func_that_returns_false()
        {
            var result = this.Execute(specify_func_that_returns_false);

            specify(() => !result);
        }

        void specify_func_that_returns_false()
        {
            specify(() => false);
        }

        [Test]
        [Pending]
        public void should_fail_when_specifying_func_that_throws_exception()
        {
            var result = this.Execute(specify_func_that_throws_exception);

            specify(() => !result);
        }

        void specify_func_that_throws_exception()
        {
            specify(() => func_that_throws_exception());
        }

        bool func_that_throws_exception()
        {
            throw new Exception();
        }
    }
}