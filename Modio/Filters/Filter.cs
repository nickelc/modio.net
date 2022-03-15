using System.Collections.Generic;

namespace Modio.Filters
{
    using Parameters = IDictionary<string, string>;

    /// <summary>
    /// Used to filter search results for several endpoints.
    /// </summary>
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

        /// <summary>
        /// Initializes a new custom instance of <see cref="Filter"/>.
        /// </summary>
        public static Filter Custom(string name, Operator op, string value)
        {
            return new Filter(op.ToName(name), value);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Filter"/> with <paramref name="limit"/>.
        /// </summary>
        public static Filter WithLimit(uint limit)
        {
            return new Filter("_limit", limit.ToString());
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Filter"/> with <paramref name="offset"/>.
        /// </summary>
        public static Filter WithOffset(uint offset)
        {
            return new Filter("_offset", offset.ToString());
        }

        /// <summary>
        /// Returns a new filter that combines this filter and <paramref name="other"/>.
        /// </summary>
        public Filter And(Filter other)
        {
            var filter = new Filter(this.parameters);
            filter.parameters.Extend(other.parameters);
            return filter;
        }

        /// <summary>
        /// Sets the limit for the filter.
        /// </summary>
        public Filter Limit(uint limit)
        {
            var filter = new Filter(this.parameters);
            filter.parameters["_limit"] = limit.ToString();
            return filter;
        }

        /// <summary>
        /// Sets the offset for the filter.
        /// </summary>
        public Filter Offset(uint offset)
        {
            var filter = new Filter(this.parameters);
            filter.parameters["_offset"] = offset.ToString();
            return filter;
        }

        internal IDictionary<string, string> ToParameters()
        {
            return new SortedDictionary<string, string>(parameters);
        }
    }

    /// <summary>
    /// Base class for the different types of filters.
    /// </summary>
    public abstract class FilterField
    {
        /// <summary>
        /// Name of the filter.
        /// </summary>
        protected readonly string Field;

        internal FilterField(string field)
        {
            Field = field;
        }

        /// <summary>
        /// Returns a new sorting filter in ascending order.
        /// </summary>
        protected Filter Asc()
        {
            return new Filter("_sort", Field);
        }

        /// <summary>
        /// Returns a new sorting filter in descending order.
        /// </summary>
        protected Filter Desc()
        {
            return new Filter("_sort", "-" + Field);
        }
    }

    /// <summary>
    /// Represents a special sorting field.
    /// </summary>
    public sealed class SortField
    {

        private string Field;

        internal SortField(string field)
        {
            Field = field;
        }

        /// <summary>
        /// Returns a new sorting filter in ascending order.
        /// </summary>
        public Filter Asc()
        {
            return new Filter("_sort", "-" + Field);
        }

        /// <summary>
        /// Returns a new sorting filter in descending order.
        /// </summary>
        public Filter Desc()
        {
            return new Filter("_sort", Field);
        }
    }

    /// <summary>
    /// Specialized field for numeric filters.
    /// </summary>
    public sealed class NumericField<T> : FilterField
    {
        internal NumericField(string field) : base(field) { }

        /// <inheritdoc/>
        public new Filter Asc()
        {
            return base.Asc();
        }

        /// <inheritdoc/>
        public new Filter Desc()
        {
            return base.Desc();
        }

        /// <summary>
        /// Returns a new filter that <b>equals</b> to <paramref name="value"/>.
        /// </summary>
        public Filter Eq(T value)
        {
            var name = Operator.Equal.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }

        /// <summary>
        /// Returns a new filter that is <b>not</b> <paramref name="value"/>.
        /// </summary>
        public Filter Not(T value)
        {
            var name = Operator.NotEqual.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }

        /// <summary>
        /// Returns a new filter that is <b>in</b> <paramref name="values"/>.
        /// </summary>
        public Filter In(IEnumerable<T[]> values)
        {
            var name = Operator.In.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        /// <summary>
        /// Returns a new filter that is <b>not in</b> <paramref name="values"/>.
        /// </summary>
        public Filter NotIn(IEnumerable<T> values)
        {
            var name = Operator.NotIn.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        /// <summary>
        /// Returns a new filter that is <b>in</b> <paramref name="values"/>.
        /// </summary>
        public Filter In(params T[] values)
        {
            var name = Operator.In.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        /// <summary>
        /// Returns a new filter that is <b>not in</b> <paramref name="values"/>.
        /// </summary>
        public Filter NotIn(params T[] values)
        {
            var name = Operator.NotIn.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        /// <summary>
        /// Returns a new filter that is <b>less than</b> <paramref name="value"/>.
        /// </summary>
        public Filter LessThan(T value)
        {
            var name = Operator.LessThan.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }

        /// <summary>
        /// Returns a new filter that is <b>less or equal</b> to <paramref name="value"/>.
        /// </summary>
        public Filter LessOrEqual(T value)
        {
            var name = Operator.LessOrEqual.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }

        /// <summary>
        /// Returns a new filter that is <b>greater than</b> <paramref name="value"/>.
        /// </summary>
        public Filter GreaterThan(T value)
        {
            var name = Operator.GreaterThan.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }

        /// <summary>
        /// Returns a new filter that is <b>greater or equal</b> to <paramref name="value"/>.
        /// </summary>
        public Filter GreaterOrEqual(T value)
        {
            var name = Operator.GreaterOrEqual.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }

        /// <summary>
        /// Returns a new filter that <b>bitwise and</b> checks to <paramref name="value"/>.
        /// </summary>
        public Filter BitwiseAnd(T value)
        {
            var name = Operator.BitwiseAnd.ToName(Field);
            return new Filter(name, value?.ToString()!);
        }
    }

    /// <summary>
    /// Specialized field for the fulltext filter.
    /// </summary>
    public sealed class FullTextField : FilterField
    {
        internal FullTextField() : base("_q") { }

        /// <summary>
        /// Returns a new filter that is a lenient search filter that is only available
        /// if the endpoint you are querying contains a <c>name</c> column.
        /// </summary>
        public Filter Eq(string value)
        {
            var name = Operator.Equal.ToName(Field);
            return new Filter(name, value);
        }
    }

    /// <summary>
    /// Specialized field for text filters.
    /// </summary>
    public sealed class TextField : FilterField
    {
        internal TextField(string field) : base(field) { }

        /// <inheritdoc/>
        public new Filter Asc()
        {
            return base.Asc();
        }

        /// <inheritdoc/>
        public new Filter Desc()
        {
            return base.Desc();
        }

        /// <summary>
        /// Returns a new filter that <b>equals</b> to <paramref name="value"/>.
        /// </summary>
        public Filter Eq(string value)
        {
            var name = Operator.Equal.ToName(Field);
            return new Filter(name, value);
        }

        /// <summary>
        /// Returns a new filter that is <b>not</b> <paramref name="value"/>.
        /// </summary>
        public Filter Not(string value)
        {
            var name = Operator.NotEqual.ToName(Field);
            return new Filter(name, value);
        }

        /// <summary>
        /// Returns a new filter that is <b>like</b> <paramref name="value"/>.
        /// </summary>
        public Filter Like(string value)
        {
            var name = Operator.Like.ToName(Field);
            return new Filter(name, value);
        }

        /// <summary>
        /// Returns a new filter that is <b>not like</b> <paramref name="value"/>.
        /// </summary>
        public Filter NotLike(string value)
        {
            var name = Operator.NotLike.ToName(Field);
            return new Filter(name, value);
        }

        /// <summary>
        /// Returns a new filter that is <b>in</b> <paramref name="values"/>.
        /// </summary>
        public Filter In(IEnumerable<string> values)
        {
            var name = Operator.In.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        /// <summary>
        /// Returns a new filter that is <b>not in</b> <paramref name="values"/>.
        /// </summary>
        public Filter NotIn(IEnumerable<string> values)
        {
            var name = Operator.NotIn.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        /// <summary>
        /// Returns a new filter that is <b>in</b> <paramref name="values"/>.
        /// </summary>
        public Filter In(params string[] values)
        {
            var name = Operator.In.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        /// <summary>
        /// Returns a new filter that is <b>not in</b> <paramref name="values"/>.
        /// </summary>
        public Filter NotIn(params string[] values)
        {
            var name = Operator.NotIn.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }
    }

    /// <summary>
    /// Specialized field for generic text filters.
    /// </summary>
    public class GenericTextField<T> : FilterField
        where T : notnull
    {
        internal GenericTextField(string field) : base(field) { }

        /// <summary>
        /// Returns a new filter that <b>equals</b> to <paramref name="value"/>.
        /// </summary>
        public Filter Eq(T value)
        {
            var name = Operator.Equal.ToName(Field);
            return new Filter(name, value.ToString()!);
        }

        /// <summary>
        /// Returns a new filter that is <b>not</b> <paramref name="value"/>.
        /// </summary>
        public Filter Not(T value)
        {
            var name = Operator.NotEqual.ToName(Field);
            return new Filter(name, value.ToString()!);
        }

        /// <summary>
        /// Returns a new filter that is <b>like</b> <paramref name="value"/>.
        /// </summary>
        public Filter Like(T value)
        {
            var name = Operator.Like.ToName(Field);
            return new Filter(name, value.ToString()!);
        }

        /// <summary>
        /// Returns a new filter that is <b>not like</b> <paramref name="value"/>.
        /// </summary>
        public Filter NotLike(T value)
        {
            var name = Operator.NotLike.ToName(Field);
            return new Filter(name, value.ToString()!);
        }

        /// <summary>
        /// Returns a new filter that is <b>in</b> <paramref name="values"/>.
        /// </summary>
        public Filter In(IEnumerable<T> values)
        {
            var name = Operator.In.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        /// <summary>
        /// Returns a new filter that is <b>in not</b> <paramref name="values"/>.
        /// </summary>
        public Filter NotIn(IEnumerable<T> values)
        {
            var name = Operator.NotIn.ToName(Field);
            return new Filter(name, string.Join(",", values));
        }

        /// <summary>
        /// Returns a new filter that is <b>in</b> <paramref name="values"/>.
        /// </summary>
        public Filter In(params T[] values)
        {
            var name = Operator.In.ToName(Field);
            return new Filter(name, string.Join(",", new List<T>(values)));
        }

        /// <summary>
        /// Returns a new filter that is <b>not in</b> <paramref name="values"/>.
        /// </summary>
        public Filter NotIn(params T[] values)
        {
            var name = Operator.NotIn.ToName(Field);
            return new Filter(name, string.Join(",", new List<T>(values)));
        }
    }

    /// <summary>
    /// Filter operators of mod.io
    /// </summary>
    ///
    /// <seealso>https://docs.mod.io/#filtering</seealso>
    public enum Operator
    {
        /// <summary>
        /// Equal to (`id=1`)
        /// </summary>
        Equal,
        /// <summary>
        /// Equal to (`id-not=1`)
        /// </summary>
        NotEqual,
        /// <summary>
        /// Equivalent to SQL's `LIKE`. `*` is equivalent to SQL's `%`. (`name-lk=foo*`)
        /// </summary>
        Like,
        /// <summary>
        /// Equivalent to SQL's `NOT LIKE` (`name-not-lk=foo*`)
        /// </summary>
        NotLike,
        /// <summary>
        /// Equivalent to SQL's `IN` (`id-in=1,3,5`)
        /// </summary>
        In,
        /// <summary>
        /// Equivalent to SQL's `NOT IN` (`id-not-in=1,3,5`)
        /// </summary>
        NotIn,
        /// <summary>
        /// Less than (`id-st=10`)
        /// </summary>
        LessThan,
        /// <summary>
        /// Less than or equal to (`id-max=10`)
        /// </summary>
        LessOrEqual,
        /// <summary>
        /// Greater than (`id-gt=5`)
        /// </summary>
        GreaterThan,
        /// <summary>
        /// Greater than or equal to (`id-min=5`)
        /// </summary>
        GreaterOrEqual,
        /// <summary>
        /// Match bits (`maturity_option-bitwise-and=5`)
        /// </summary>
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
