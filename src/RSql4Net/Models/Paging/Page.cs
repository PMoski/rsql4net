﻿using System.Collections.Generic;

namespace RSql4Net.Models.Paging
{
    /// <summary>
    ///     Default implementation of IPage
    /// </summary>
    public class Page<T> : IPage<T> where T : class
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:RSql4Net.Models.Paging.Page`1" /> class.
        /// </summary>
        public Page() : this(new List<T>()) { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:RSql4Net.Models.Paging.Page`1" /> class.
        /// </summary>
        /// <param name="content">Content.</param>
        /// <param name="pageable">Pageable.</param>
        /// <param name="total">Total.</param>
        public Page(List<T> content, IPageable<T> pageable = null, long? total = null)
        {
            Content = content ?? new List<T>();
            if (total == null)
            {
                TotalElements = Content.Count;
            }
            else
            {
                TotalElements = total.Value < Content.Count ? Content.Count : total.Value;
            }

            HasContent = Content.Count > 0;
            if (HasContent)
            {
                NumberOfElements = Content.Count;
            }

            if (pageable == null)
            {
                return;
            }

            Number = pageable.PageNumber();
            HasPrevious = pageable.PageNumber() > 0;
            HasNext = TotalElements > NumberOfElements + (Number * pageable.PageSize());
            if (TotalElements <= 0)
            {
                return;
            }

            var mod = (int)TotalElements % pageable.PageSize();
            var quo = (int)TotalElements - mod;
            TotalPages = (quo / pageable.PageSize()) + (mod > 0 ? 1 : 0);
        }

        /// <summary>
        ///     Gets the total elements.
        /// </summary>
        /// <value>The total elements.</value>
        public long TotalElements { get; }

        /// <summary>
        ///     Gets the number.
        /// </summary>
        /// <value>The number.</value>
        public int Number { get; }

        /// <summary>
        ///     Gets the number of elements.
        /// </summary>
        /// <value>The number of elements.</value>
        public int NumberOfElements { get; }

        /// <summary>
        ///     Gets the total pages.
        /// </summary>
        /// <value>The total pages.</value>
        public int TotalPages { get; }

        /// <summary>
        ///     Gets a value indicating whether this <see cref="T:RSql4Net.Models.Paging.Page`1" /> has content.
        /// </summary>
        /// <value><c>true</c> if has content; otherwise, <c>false</c>.</value>
        public bool HasContent { get; }

        /// <summary>
        ///     Gets a value indicating whether this <see cref="T:RSql4Net.Mvc.Models.Paginations.Page`1" /> has next.
        /// </summary>
        /// <value><c>true</c> if has next; otherwise, <c>false</c>.</value>
        public bool HasNext { get; }

        /// <summary>
        ///     Gets a value indicating whether this <see cref="T:RSql4Net.Models.Paging.Page`1" /> has previous.
        /// </summary>
        /// <value><c>true</c> if has previous; otherwise, <c>false</c>.</value>
        public bool HasPrevious { get; }

        /// <summary>
        ///     Gets the content.
        /// </summary>
        /// <value>The content.</value>
        public IList<T> Content { get; }
    }
}