namespace Json2SharpTests.JavaTests.Models.Answers;

internal static class CustomHandleTypes
{
    public const string Input = """
        {
            "id": "550e8400-e29b-41d4-a716-446655440000",
            "date": "2021-01-01T00:00:00Z",
            "duration": "00:00:01"
        }
        """;

    public const string NoAnnotationOutput = """
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public class custom_handle_types {
            private UUID id;

            private OffsetDateTime date;

            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    // Class variations
    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public class custom_handle_types {
            @JsonProperty("id")
            private UUID id;

            @JsonProperty("date")
            private OffsetDateTime date;

            @JsonProperty("duration")
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string JacksonJakartaOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public class custom_handle_types {
            @JsonProperty("id")
            @NotNull
            private UUID id;

            @JsonProperty("date")
            @NotNull
            private OffsetDateTime date;

            @JsonProperty("duration")
            @NotNull
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string JacksonJSpecifyOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class custom_handle_types {
            @JsonProperty("id")
            @NonNull
            private UUID id;

            @JsonProperty("date")
            @NonNull
            private OffsetDateTime date;

            @JsonProperty("duration")
            @NonNull
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string JacksonJetBrainsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class custom_handle_types {
            @JsonProperty("id")
            @NotNull
            private UUID id;

            @JsonProperty("date")
            @NotNull
            private OffsetDateTime date;

            @JsonProperty("duration")
            @NotNull
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string JacksonLombokOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class custom_handle_types {
            @JsonProperty("id")
            @NonNull
            private UUID id;

            @JsonProperty("date")
            @NonNull
            private OffsetDateTime date;

            @JsonProperty("duration")
            @NonNull
            private Duration duration;
        }
        """;

    public const string JacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class custom_handle_types {
            @JsonProperty("id")
            @Nonnull
            private UUID id;

            @JsonProperty("date")
            @Nonnull
            private OffsetDateTime date;

            @JsonProperty("duration")
            @Nonnull
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public class custom_handle_types {
            @SerializedName("id")
            private UUID id;

            @SerializedName("date")
            private OffsetDateTime date;

            @SerializedName("duration")
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string GsonJakartaOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public class custom_handle_types {
            @SerializedName("id")
            @NotNull
            private UUID id;

            @SerializedName("date")
            @NotNull
            private OffsetDateTime date;

            @SerializedName("duration")
            @NotNull
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string GsonJSpecifyOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class custom_handle_types {
            @SerializedName("id")
            @NonNull
            private UUID id;

            @SerializedName("date")
            @NonNull
            private OffsetDateTime date;

            @SerializedName("duration")
            @NonNull
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string GsonJetBrainsOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class custom_handle_types {
            @SerializedName("id")
            @NotNull
            private UUID id;

            @SerializedName("date")
            @NotNull
            private OffsetDateTime date;

            @SerializedName("duration")
            @NotNull
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string GsonLombokOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class custom_handle_types {
            @SerializedName("id")
            @NonNull
            private UUID id;

            @SerializedName("date")
            @NonNull
            private OffsetDateTime date;

            @SerializedName("duration")
            @NonNull
            private Duration duration;
        }
        """;

    public const string GsonFindBugsOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class custom_handle_types {
            @SerializedName("id")
            @Nonnull
            private UUID id;

            @SerializedName("date")
            @Nonnull
            private OffsetDateTime date;

            @SerializedName("duration")
            @Nonnull
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public class custom_handle_types {
            @Json(name = "id")
            private UUID id;

            @Json(name = "date")
            private OffsetDateTime date;

            @Json(name = "duration")
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string MoshiJakartaOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public class custom_handle_types {
            @Json(name = "id")
            @NotNull
            private UUID id;

            @Json(name = "date")
            @NotNull
            private OffsetDateTime date;

            @Json(name = "duration")
            @NotNull
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string MoshiJSpecifyOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class custom_handle_types {
            @Json(name = "id")
            @NonNull
            private UUID id;

            @Json(name = "date")
            @NonNull
            private OffsetDateTime date;

            @Json(name = "duration")
            @NonNull
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string MoshiJetBrainsOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class custom_handle_types {
            @Json(name = "id")
            @NotNull
            private UUID id;

            @Json(name = "date")
            @NotNull
            private OffsetDateTime date;

            @Json(name = "duration")
            @NotNull
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    public const string MoshiLombokOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class custom_handle_types {
            @Json(name = "id")
            @NonNull
            private UUID id;

            @Json(name = "date")
            @NonNull
            private OffsetDateTime date;

            @Json(name = "duration")
            @NonNull
            private Duration duration;
        }
        """;

    public const string MoshiFindBugsOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class custom_handle_types {
            @Json(name = "id")
            @Nonnull
            private UUID id;

            @Json(name = "date")
            @Nonnull
            private OffsetDateTime date;

            @Json(name = "duration")
            @Nonnull
            private Duration duration;

            public UUID getId() {
                return id;
            }

            public void setId(UUID id) {
                this.id = id;
            }

            public OffsetDateTime getDate() {
                return date;
            }

            public void setDate(OffsetDateTime date) {
                this.date = date;
            }

            public Duration getDuration() {
                return duration;
            }

            public void setDuration(Duration duration) {
                this.duration = duration;
            }
        }
        """;

    // Record variations
    public const string NoAnnotationRecordOutput = """
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public record custom_handle_types(
            UUID id,
            OffsetDateTime date,
            Duration duration
        ) {}
        """;

    public const string JacksonRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public record custom_handle_types(
            @JsonProperty("id") UUID id,
            @JsonProperty("date") OffsetDateTime date,
            @JsonProperty("duration") Duration duration
        ) {}
        """;

    public const string JacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public record custom_handle_types(
            @JsonProperty("id") @NotNull UUID id,
            @JsonProperty("date") @NotNull OffsetDateTime date,
            @JsonProperty("duration") @NotNull Duration duration
        ) {}
        """;

    public const string JacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record custom_handle_types(
            @JsonProperty("id") @NonNull UUID id,
            @JsonProperty("date") @NonNull OffsetDateTime date,
            @JsonProperty("duration") @NonNull Duration duration
        ) {}
        """;

    public const string JacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record custom_handle_types(
            @JsonProperty("id") @NotNull UUID id,
            @JsonProperty("date") @NotNull OffsetDateTime date,
            @JsonProperty("duration") @NotNull Duration duration
        ) {}
        """;

    public const string JacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import lombok.NonNull;

        public record custom_handle_types(
            @JsonProperty("id") @NonNull UUID id,
            @JsonProperty("date") @NonNull OffsetDateTime date,
            @JsonProperty("duration") @NonNull Duration duration
        ) {}
        """;

    public const string JacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record custom_handle_types(
            @JsonProperty("id") @Nonnull UUID id,
            @JsonProperty("date") @Nonnull OffsetDateTime date,
            @JsonProperty("duration") @Nonnull Duration duration
        ) {}
        """;

    public const string GsonRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public record custom_handle_types(
            @SerializedName("id") UUID id,
            @SerializedName("date") OffsetDateTime date,
            @SerializedName("duration") Duration duration
        ) {}
        """;

    public const string GsonJakartaRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public record custom_handle_types(
            @SerializedName("id") @NotNull UUID id,
            @SerializedName("date") @NotNull OffsetDateTime date,
            @SerializedName("duration") @NotNull Duration duration
        ) {}
        """;

    public const string GsonJSpecifyRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record custom_handle_types(
            @SerializedName("id") @NonNull UUID id,
            @SerializedName("date") @NonNull OffsetDateTime date,
            @SerializedName("duration") @NonNull Duration duration
        ) {}
        """;

    public const string GsonJetBrainsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record custom_handle_types(
            @SerializedName("id") @NotNull UUID id,
            @SerializedName("date") @NotNull OffsetDateTime date,
            @SerializedName("duration") @NotNull Duration duration
        ) {}
        """;

    public const string GsonLombokRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import lombok.NonNull;

        public record custom_handle_types(
            @SerializedName("id") @NonNull UUID id,
            @SerializedName("date") @NonNull OffsetDateTime date,
            @SerializedName("duration") @NonNull Duration duration
        ) {}
        """;

    public const string GsonFindBugsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record custom_handle_types(
            @SerializedName("id") @Nonnull UUID id,
            @SerializedName("date") @Nonnull OffsetDateTime date,
            @SerializedName("duration") @Nonnull Duration duration
        ) {}
        """;

    public const string MoshiRecordOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public record custom_handle_types(
            @Json(name = "id") UUID id,
            @Json(name = "date") OffsetDateTime date,
            @Json(name = "duration") Duration duration
        ) {}
        """;

    public const string MoshiJakartaRecordOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;

        public record custom_handle_types(
            @Json(name = "id") @NotNull UUID id,
            @Json(name = "date") @NotNull OffsetDateTime date,
            @Json(name = "duration") @NotNull Duration duration
        ) {}
        """;

    public const string MoshiJSpecifyRecordOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record custom_handle_types(
            @Json(name = "id") @NonNull UUID id,
            @Json(name = "date") @NonNull OffsetDateTime date,
            @Json(name = "duration") @NonNull Duration duration
        ) {}
        """;

    public const string MoshiJetBrainsRecordOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record custom_handle_types(
            @Json(name = "id") @NotNull UUID id,
            @Json(name = "date") @NotNull OffsetDateTime date,
            @Json(name = "duration") @NotNull Duration duration
        ) {}
        """;

    public const string MoshiLombokRecordOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import lombok.NonNull;

        public record custom_handle_types(
            @Json(name = "id") @NonNull UUID id,
            @Json(name = "date") @NonNull OffsetDateTime date,
            @Json(name = "duration") @NonNull Duration duration
        ) {}
        """;

    public const string MoshiFindBugsRecordOutput = """
        import com.squareup.moshi.Json;
        import java.time.Duration;
        import java.time.OffsetDateTime;
        import java.util.UUID;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record custom_handle_types(
            @Json(name = "id") @Nonnull UUID id,
            @Json(name = "date") @Nonnull OffsetDateTime date,
            @Json(name = "duration") @Nonnull Duration duration
        ) {}
        """;
}