﻿using System;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Serialization;

namespace RSql4Net.Configurations
{
    /// <summary>
    ///     RSql4 net settings.
    /// </summary>
    public class Settings
    {
        /// <summary>
        ///     The name of the Default page size field.
        /// </summary>
        public const string CDefaultPageSizeFieldName = "PageSize";

        /// <summary>
        ///     The size of the Default page.
        /// </summary>
        public const int CDefaultPageSize = 100;

        /// <summary>
        ///     The name of the Default page number field.
        /// </summary>
        public const string CDefaultPageNumberFieldName = "PageNumber";

        /// <summary>
        ///     The name of the Default query field.
        /// </summary>
        public const string CDefaultQueryFieldName = "Query";

        /// <summary>
        ///     The name of the Default sort field.
        /// </summary>
        public const string CDefaultSortFieldName = "Sort";

        /// <summary>
        /// </summary>
        public Settings() : this(new DefaultNamingStrategy())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="namingStrategy"></param>
        public Settings(NamingStrategy namingStrategy)
        {
            PageSizeField = CDefaultPageSizeFieldName;
            PageNumberField = CDefaultPageNumberFieldName;
            PageSize = CDefaultPageSize;
            SortField = CDefaultSortFieldName;
            QueryField = CDefaultQueryFieldName;
            NamingStrategy = namingStrategy ?? throw new ArgumentNullException(nameof(namingStrategy));
        }

        /// <summary>
        ///     Gets or sets the page size field.
        /// </summary>
        /// <value>The page size field.</value>
        public string PageSizeField { get; set; }

        /// <summary>
        ///     Gets or sets the sort field.
        /// </summary>
        /// <value>The sort field.</value>
        public string SortField { get; set; }

        /// <summary>
        ///     Gets or sets the page number field.
        /// </summary>
        /// <value>The page number field.</value>
        public string PageNumberField { get; set; }

        /// <summary>
        ///     Gets or sets the query field.
        /// </summary>
        /// <value>The query field.</value>
        public string QueryField { get; set; }

        /// <summary>
        ///     Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize { get; set; }

        /// <summary>
        ///     Gets or sets the naming strategy.
        /// </summary>
        /// <value>The naming strategy.</value>
        public NamingStrategy NamingStrategy { get; }
        
        /// <summary>
        ///     Gets or sets the query cache.
        /// </summary>
        /// <value>The memory case of the query.</value>
        public IMemoryCache QueryCache { get; set; }
        
        /// <summary>
        ///  
        /// </summary>
        public Action<MemoryCacheEntryOptions> OnCreateCacheEntry { get; set; }
    }
}