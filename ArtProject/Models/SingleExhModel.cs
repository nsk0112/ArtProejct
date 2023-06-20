using static ArtProject.Models.ExhibitionModel;
using static ArtProject.Models.PaintModel;

namespace ArtProject.Models
{
    public class SingleExhModel
    {
        public Data data { get; set; }
        public Info info { get; set; }
        public Config config { get; set; }

        public class Config
        {
            public string iiif_url { get; set; }
            public string website_url { get; set; }
        }

        public class Contexts
        {
            public List<string> groupings { get; set; }
        }

        public class Data
        {
            public int id { get; set; }
            public string api_model { get; set; }
            public string api_link { get; set; }
            public string title { get; set; }
            public bool is_featured { get; set; }
            public string short_description { get; set; }
            public string web_url { get; set; }
            public string image_url { get; set; }
            public string status { get; set; }
            public DateTime aic_start_at { get; set; }
            public DateTime aic_end_at { get; set; }
            public Nullable<int> gallery_id { get; set; }
            public string gallery_title { get; set; }
            public List<object> artwork_ids { get; set; }
            public List<object> artwork_titles { get; set; }
            public List<object> artist_ids { get; set; }
            public List<object> site_ids { get; set; }
            public object image_id { get; set; }
            public List<object> alt_image_ids { get; set; }
            public List<object> document_ids { get; set; }
            public string suggest_autocomplete_boosted { get; set; }
            public SuggestAutocompleteAll suggest_autocomplete_all { get; set; }
            public DateTime source_updated_at { get; set; }
            public DateTime updated_at { get; set; }
            public DateTime timestamp { get; set; }
        }

        public class Info
        {
            public string license_text { get; set; }
            public List<string> license_links { get; set; }
            public string version { get; set; }
        }

        public class SuggestAutocompleteAll
        {
            public List<string> input { get; set; }
            public Contexts contexts { get; set; }
        }

    }
}
