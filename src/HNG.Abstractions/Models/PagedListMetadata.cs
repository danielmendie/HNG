﻿namespace HNG.Abstractions.Models
{
    public class PagedListMetadata
    {
        public int? TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int? TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool? HasNext => (TotalPages == null) ? null: CurrentPage < TotalPages;
    }
}
