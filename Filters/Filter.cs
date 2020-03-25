using System.Collections.Generic;

namespace Modio.Filters
{
    using Parameters = IDictionary<string, string>;

    public class Filter
    {
        private Parameters parameters;

        internal Filter()
        {
            parameters = new SortedDictionary<string, string>();
        }

        internal Filter(Parameters parameters)
        {
            this.parameters = new SortedDictionary<string, string>(parameters);
        }

        internal Filter(string name, string value) : this()
        {
            parameters[name] = value;
        }

        public static Filter WithLimit(uint limit)
        {
            return new Filter("_limit", limit.ToString());
        }

        public static Filter WithOffset(uint offset)
        {
            return new Filter("_offset", offset.ToString());
        }

        public Filter And(Filter other)
        {
            var filter = new Filter(this.parameters);
            filter.parameters.Extend(other.parameters);
            return filter;
        }

        public Filter Limit(uint limit)
        {
            var filter = new Filter(this.parameters);
            filter.parameters["_limit"] = limit.ToString();
            return filter;
        }

        public Filter Offset(uint offset)
        {
            var filter = new Filter(this.parameters);
            filter.parameters["_offset"] = offset.ToString();
            return filter;
        }

        public IDictionary<string, string> ToParameters()
        {
            return new SortedDictionary<string, string>(parameters);
        }
    }

    public abstract class FilterField
    {
        protected readonly string Field;

        internal FilterField(string field)
        {
            Field = field;
        }

        protected Filter Asc()
        {
            return new Filter("_sort", Field);
        }

        protected Filter Desc()
        {
            return new Filter("_sort", "-" + Field);
        }
    }

    public sealed class SortField
    {

        private string Field;

        internal SortField(string field)
        {
            Field = field;
        }

        public Filter Asc()
        {
            return new Filter("_sort", "-" + Field);
        }

        public Filter Desc()
        {
            return new Filter("_sort", Field);
        }
    }

    public sealed class NumericField<T> : FilterField
    {
        internal NumericField(string field) : base(field) { }

        public new Filter Asc()
        {
            return base.Asc();
        }

        public new Filter Desc()
        {
            return base.Desc();
        }

        public Filter Eq(T value)
        {
            var name = Operator.Equal.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }

        public Filter Not(T value)
        {
            var name = Operator.NotEqual.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }
        public Filter In(IEnumerable<T[]> values)
        {
            var name = Operator.In.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        public Filter NotIn(IEnumerable<T> values)
        {
            var name = Operator.NotIn.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        public Filter In(params T[] values)
        {
            var name = Operator.In.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        public Filter NotIn(params T[] values)
        {
            var name = Operator.NotIn.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        public Filter LessThan(T value)
        {
            var name = Operator.LessThan.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }

        public Filter LessOrEqual(T value)
        {
            var name = Operator.LessOrEqual.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }

        public Filter GreaterThan(T value)
        {
            var name = Operator.GreaterThan.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }

        public Filter GreaterOrEqual(T value)
        {
            var name = Operator.GreaterOrEqual.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }

        public Filter BitwiseAnd(T value)
        {
            var name = Operator.BitwiseAnd.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }
    }

    public sealed class FullTextField : FilterField
    {
        internal FullTextField() : base("_q") { }

        public Filter Eq(string value)
        {
            var name = Operator.Equal.ToName(Field);
            return new Filter(name, value);
        }
    }

    public sealed class TextField : FilterField
    {
        internal TextField(string field) : base(field) { }

        public new Filter Asc()
        {
            return base.Asc();
        }

        public new Filter Desc()
        {
            return base.Desc();
        }

        public Filter Eq(string value)
        {
            var name = Operator.Equal.ToName(Field);
            return new Filter(name, value);
        }

        public Filter Not(string value)
        {
            var name = Operator.NotEqual.ToName(Field);
            return new Filter(name, value);
        }

        public Filter Like(string value)
        {
            var name = Operator.Like.ToName(Field);
            return new Filter(name, value);
        }

        public Filter NotLike(string value)
        {
            var name = Operator.NotLike.ToName(Field);
            return new Filter(name, value);
        }

        public Filter In(IEnumerable<string> values)
        {
            var name = Operator.In.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        public Filter NotIn(IEnumerable<string> values)
        {
            var name = Operator.NotIn.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        public Filter In(params string[] values)
        {
            var name = Operator.In.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        public Filter NotIn(params string[] values)
        {
            var name = Operator.NotIn.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }
    }

    public class GenericTextField<T> : FilterField
        where T : notnull
    {
        internal GenericTextField(string field) : base(field) { }

        public Filter Eq(T value)
        {
            var name = Operator.Equal.ToName(Field);
            return new Filter(name, value.ToString()!);
        }

        public Filter Not(T value)
        {
            var name = Operator.NotEqual.ToName(Field);
            return new Filter(name, value.ToString()!);
        }

        public Filter Like(T value)
        {
            var name = Operator.Like.ToName(Field);
            return new Filter(name, value.ToString()!);
        }

        public Filter NotLike(T value)
        {
            var name = Operator.NotLike.ToName(Field);
            return new Filter(name, value.ToString()!);
        }

        public Filter In(IEnumerable<T> values)
        {
            var name = Operator.In.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        public Filter NotIn(IEnumerable<T> values)
        {
            var name = Operator.NotIn.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        public Filter In(params T[] values)
        {
            var name = Operator.In.ToName(Field);
            return new Filter(name, string.Join(",", new List<T>(values)));
        }

        public Filter NotIn(params T[] values)
        {
            var name = Operator.NotIn.ToName(Field);
            return new Filter(name, string.Join(",", new List<T>(values)));
        }
    }

    internal enum Operator
    {
        Equal,
        NotEqual,
        Like,
        NotLike,
        In,
        NotIn,
        LessThan,
        LessOrEqual,
        GreaterThan,
        GreaterOrEqual,
        BitwiseAnd,
    }

    internal static class OperatorMethods
    {
        internal static string ToName(this Operator method, string name)
        {
            switch (method)
            {
                case Operator.Equal:
                    return name;
                case Operator.NotEqual:
                    return name + "-not";
                case Operator.Like:
                    return name + "-lk";
                case Operator.NotLike:
                    return name + "-not-lk";
                case Operator.In:
                    return name + "-in";
                case Operator.NotIn:
                    return name + "-not-in";
                case Operator.LessThan:
                    return name + "-st";
                case Operator.LessOrEqual:
                    return name + "-max";
                case Operator.GreaterThan:
                    return name + "-gt";
                case Operator.GreaterOrEqual:
                    return name + "-min";
                case Operator.BitwiseAnd:
                    return name + "-bitwise-and";
                default:
                    return name;
            }
        }
    }
}
