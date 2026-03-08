namespace Json2SharpTests.KotlinTests.Models.Answers;

internal static class TextTypes
{
    public const string Input = """
        {
            "text": "hello world",
            "empty_text": "",
            "timespan": "00:00:01",
            "timespans": ["00:00:01"],
            "nullable_timespans": ["00:00:01", null],
            "date_time_offset": "2024-05-19T01:23:10.000Z",
            "date_time_offset_array": ["2024-05-19T01:23:10.000Z"],
            "date_time_offset_nullable_array": ["2024-05-19T01:23:10.000Z", null],
            "id": "6c33ac26-953b-46bf-8a5d-a34e1b99e5df",
            "ids": ["6c33ac26-953b-46bf-8a5d-a34e1b99e5df"],
            "nullable_ids": ["6c33ac26-953b-46bf-8a5d-a34e1b99e5df", null]
        }
        """;

    public const string NoAnnotationOutput = """
        import java.time.Duration
        import java.time.OffsetDateTime
        import java.util.UUID

        data class Root(
            val text: String,
            val emptyText: String,
            val timespan: Duration,
            val timespans: List<Duration>,
            val nullableTimespans: List<Duration?>,
            val dateTimeOffset: OffsetDateTime,
            val dateTimeOffsetArray: List<OffsetDateTime>,
            val dateTimeOffsetNullableArray: List<OffsetDateTime?>,
            val id: UUID,
            val ids: List<UUID>,
            val nullableIds: List<UUID?>
        )
        """;

    public const string KotlinxOutput = """
        import java.time.Duration
        import java.time.OffsetDateTime
        import java.util.UUID
        import kotlinx.serialization.Serializable
        import kotlinx.serialization.SerialName

        @Serializable
        data class Root(
            @SerialName("text") val text: String,
            @SerialName("empty_text") val emptyText: String,
            @SerialName("timespan") val timespan: Duration,
            @SerialName("timespans") val timespans: List<Duration>,
            @SerialName("nullable_timespans") val nullableTimespans: List<Duration?>,
            @SerialName("date_time_offset") val dateTimeOffset: OffsetDateTime,
            @SerialName("date_time_offset_array") val dateTimeOffsetArray: List<OffsetDateTime>,
            @SerialName("date_time_offset_nullable_array") val dateTimeOffsetNullableArray: List<OffsetDateTime?>,
            @SerialName("id") val id: UUID,
            @SerialName("ids") val ids: List<UUID>,
            @SerialName("nullable_ids") val nullableIds: List<UUID?>
        )
        """;

    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty
        import java.time.Duration
        import java.time.OffsetDateTime
        import java.util.UUID

        data class Root(
            @JsonProperty("text") val text: String,
            @JsonProperty("empty_text") val emptyText: String,
            @JsonProperty("timespan") val timespan: Duration,
            @JsonProperty("timespans") val timespans: List<Duration>,
            @JsonProperty("nullable_timespans") val nullableTimespans: List<Duration?>,
            @JsonProperty("date_time_offset") val dateTimeOffset: OffsetDateTime,
            @JsonProperty("date_time_offset_array") val dateTimeOffsetArray: List<OffsetDateTime>,
            @JsonProperty("date_time_offset_nullable_array") val dateTimeOffsetNullableArray: List<OffsetDateTime?>,
            @JsonProperty("id") val id: UUID,
            @JsonProperty("ids") val ids: List<UUID>,
            @JsonProperty("nullable_ids") val nullableIds: List<UUID?>
        )
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName
        import java.time.Duration
        import java.time.OffsetDateTime
        import java.util.UUID

        data class Root(
            @SerializedName("text") val text: String,
            @SerializedName("empty_text") val emptyText: String,
            @SerializedName("timespan") val timespan: Duration,
            @SerializedName("timespans") val timespans: List<Duration>,
            @SerializedName("nullable_timespans") val nullableTimespans: List<Duration?>,
            @SerializedName("date_time_offset") val dateTimeOffset: OffsetDateTime,
            @SerializedName("date_time_offset_array") val dateTimeOffsetArray: List<OffsetDateTime>,
            @SerializedName("date_time_offset_nullable_array") val dateTimeOffsetNullableArray: List<OffsetDateTime?>,
            @SerializedName("id") val id: UUID,
            @SerializedName("ids") val ids: List<UUID>,
            @SerializedName("nullable_ids") val nullableIds: List<UUID?>
        )
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json
        import com.squareup.moshi.JsonClass
        import java.time.Duration
        import java.time.OffsetDateTime
        import java.util.UUID

        @JsonClass(generateAdapter = true)
        data class Root(
            @Json(name = "text") val text: String,
            @Json(name = "empty_text") val emptyText: String,
            @Json(name = "timespan") val timespan: Duration,
            @Json(name = "timespans") val timespans: List<Duration>,
            @Json(name = "nullable_timespans") val nullableTimespans: List<Duration?>,
            @Json(name = "date_time_offset") val dateTimeOffset: OffsetDateTime,
            @Json(name = "date_time_offset_array") val dateTimeOffsetArray: List<OffsetDateTime>,
            @Json(name = "date_time_offset_nullable_array") val dateTimeOffsetNullableArray: List<OffsetDateTime?>,
            @Json(name = "id") val id: UUID,
            @Json(name = "ids") val ids: List<UUID>,
            @Json(name = "nullable_ids") val nullableIds: List<UUID?>
        )
        """;
}
