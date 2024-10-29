using Newtonsoft.Json;

using System.Collections.Generic;

namespace AIBAM.Classes
{
    public class GeminiChunk
    {
        [JsonProperty("done")]
        public bool Done { get; set; }

        [JsonProperty("candidates")]
        public List<Candidate> Candidates { get; set; }

        [JsonProperty("usage_metadata")]
        public UsageMetadata UsageMetadata { get; set; }
    }

    public class Candidate
    {
        [JsonProperty("content")]
        public Content Content { get; set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("safety_ratings")]
        public List<SafetyRating> SafetyRatings { get; set; }
    }

    public class Content
    {
        [JsonProperty("parts")]
        public List<Part> Parts { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public class Part
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class SafetyRating
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("probability")]
        public string Probability { get; set; }
    }

    public class UsageMetadata
    {
        [JsonProperty("prompt_token_count")]
        public int PromptTokenCount { get; set; }

        [JsonProperty("candidates_token_count")]
        public int CandidatesTokenCount { get; set; }

        [JsonProperty("total_token_count")]
        public int TotalTokenCount { get; set; }
    }
}
