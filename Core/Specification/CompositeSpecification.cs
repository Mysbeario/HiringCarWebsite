using System;
using Core.Interfaces;

namespace Core.Specification {
    public abstract class CompositeSpecification<T> : ISpecification<T> {
        public abstract bool IsSatisfiedBy (T o);
        public Func<T, object> orderExpression { get; set; }

        public ISpecification<T> And (ISpecification<T> specification) {
            return new AndSpecification<T> (this, specification);
        }
        public ISpecification<T> Or (ISpecification<T> specification) {
            return new OrSpecification<T> (this, specification);
        }
        public ISpecification<T> Not (ISpecification<T> specification) {
            return new NotSpecification<T> (specification);
        }
    }
}