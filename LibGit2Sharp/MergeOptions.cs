using System;

namespace LibGit2Sharp
{
    /// <summary>
    /// Options controlling Merge behavior.
    /// </summary>
    public sealed class MergeOptions : MergeAndCheckoutOptionsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MergeOptions"/> class.
        /// <para>
        ///   Default behavior:
        ///     A fast-forward merge will be performed if possible, unless the merge.ff configuration option is set.
        ///     A merge commit will be committed, if one was created.
        ///     Merge will attempt to find renames.
        /// </para>
        /// </summary>
        public MergeOptions()
        { }

        /// <summary>
        /// The type of merge to perform.
        /// </summary>
        public FastForwardStrategy FastForwardStrategy { get; set; }

        /// <summary>
        /// The file merge options to use.
        /// </summary>
        public MergeFileFlags FileFlags { get; set; }
    }

    /// <summary>
    /// Strategy used for merging.
    /// </summary>
    public enum FastForwardStrategy
    {
        /// <summary>
        /// Default fast-forward strategy.  If the merge.ff configuration option is set,
        /// it will be used.  If it is not set, this will perform a fast-forward merge if
        /// possible, otherwise a non-fast-forward merge that results in a merge commit.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Do not fast-forward. Always creates a merge commit.
        /// </summary>
        NoFastForward = 1, /* GIT_MERGE_NO_FASTFORWARD */

        /// <summary>
        /// Only perform fast-forward merges.
        /// </summary>
        FastForwardOnly = 2, /* GIT_MERGE_FASTFORWARD_ONLY */
    }

    /// <summary>
    /// File options.
    /// </summary>
    [Flags]
    public enum MergeFileFlags
    {
        /// <summary>
        /// Default.
        /// </summary>
        Default = 0, /* GIT_MERGE_FILE_DEFAULT */

        /// <summary>
        /// Create standard conflicted merge files.
        /// </summary>
        StyleMerge = (1 << 0), /* GIT_MERGE_FILE_STYLE_MERGE */

        /// <summary>
        /// Create diff3-style files.
        /// </summary>
        StyleDiff3 = (1 << 1), /* GIT_MERGE_FILE_STYLE_DIFF3 */

        /// <summary>
        /// Condense non-alphanumeric regions for simplified diff file.
        /// </summary>
        SimplifyAlphaNumeric = (1 << 2), /* GIT_MERGE_FILE_SIMPLIFY_ALNUM */

        /// <summary>
        /// Ignore whitespace when comparing lines.
        /// This ignores differences even if one line has whitespace where the other line has none.
        /// </summary>
        IgnoreAllWhitespace = (1 << 3), /* GIT_MERGE_FILE_IGNORE_WHITESPACE */

        /// <summary>
        /// Ignore changes in amount of whitespace.
        /// This ignores whitespace at line end, and considers all other sequences of one or more whitespace characters to be equivalent.
        /// </summary>
        IgnoreWhitespaceChange = (1 << 4), /* GIT_MERGE_FILE_IGNORE_WHITESPACE_CHANGE */

        /// <summary>
        /// Ignore whitespace at end of line.
        /// </summary>
        IgnoreEndOfLineWhitespace = (1 << 5), /* GIT_MERGE_FILE_IGNORE_WHITESPACE_EOL */

        /// <summary>
        /// Use the "patience diff" algorithm.
        /// </summary>
        PatienceDiff = (1 << 6), /* GIT_MERGE_FILE_DIFF_PATIENCE */

        /// <summary>
        /// Take extra time to find minimal difference.
        /// </summary>
        MinimalDiff = (1 << 7), /* GIT_MERGE_FILE_DIFF_MINIMAL */
    }
}
