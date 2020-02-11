using System;
using System.Collections.Generic;
using GenericsDemo.Interfaces;

namespace GenericsDemo
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Filters array by filter.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The filter.</param>
        /// <returns>Filtered array.</returns>
        public static TSource[] FilterBy<TSource>(this TSource[] source, IPredicate<TSource> predicate)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.Length is 0)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            if (predicate is null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} cannot be null.");
            }

            var filteredSource = new List<TSource>();

            foreach (var item in source)
            {
                if (predicate.IsMatch(item))
                {
                    filteredSource.Add(item);
                }
            }

            return filteredSource.ToArray();
        }

        public static TResult[] Transform<TSource, TResult>(this TSource[] source, ITransformer<TSource, TResult> transformer)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.Length is 0)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            if (transformer is null)
            {
                throw new ArgumentNullException($"{nameof(transformer)} cannot be null.");
            }

            TResult[] resultArray = new TResult[source.Length];
            int i = 0;

            foreach (var item in source)
            {
                resultArray[i++] = transformer.Transform(item);
            }

            return resultArray;
        }

        public static TSource[] OrderAccordingTo<TSource>(this TSource[] source, System.Collections.Generic.IComparer<TSource> comparer)
        {
            // написать любую сортировку
        }
    }
}