using System;

namespace Core.Interfaces {
    public interface ISpecification<T> {
        bool IsSatisfiedBy (T o);
        ISpecification<T> And (ISpecification<T> specification);
        ISpecification<T> Or (ISpecification<T> specification);
        ISpecification<T> Not (ISpecification<T> specification);

        Func<T, object> orderExpression { get; set; }
    }
}