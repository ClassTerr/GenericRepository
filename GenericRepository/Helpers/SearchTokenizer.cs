namespace GenericRepository.Helpers;

public static class SearchInputTokenizer
{
    public static List<string> TokenizeSearch(string query, string delimiter = " ")
    {
        if (string.IsNullOrWhiteSpace(query)) return new();

        var searchTokens = query
            .Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .Distinct(StringComparer.InvariantCultureIgnoreCase)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList();

        return searchTokens;
    }
}
