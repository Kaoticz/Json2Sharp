namespace Json2SharpTests.JavaTests.Models.Answers;

internal static class ArrayRoot
{
    public const string Input = """
        [
            { "id": 1 },
            { "id": 2 },
            { "id": 3 },
            { "id": 4 },
            { "id": 5 }
        ]
        """;

    public const string NoAnnotationOutput = """
        public class Root {
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    // Class variations
    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public class Root {
            @JsonProperty("id")
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string JacksonJakartaOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @JsonProperty("id")
            @NotNull
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string JacksonJSpecifyOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @JsonProperty("id")
            @NonNull
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string JacksonJetBrainsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @JsonProperty("id")
            @NotNull
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string JacksonLombokOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @JsonProperty("id")
            @NonNull
            private Integer id;
        }
        """;

    public const string JacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @JsonProperty("id")
            @Nonnull
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName;

        public class Root {
            @SerializedName("id")
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string GsonJakartaOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @SerializedName("id")
            @NotNull
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string GsonJSpecifyOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @SerializedName("id")
            @NonNull
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string GsonJetBrainsOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @SerializedName("id")
            @NotNull
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string GsonLombokOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @SerializedName("id")
            @NonNull
            private Integer id;
        }
        """;

    public const string GsonFindBugsOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @SerializedName("id")
            @Nonnull
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json;

        public class Root {
            @Json(name = "id")
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string MoshiJakartaOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @Json(name = "id")
            @NotNull
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string MoshiJSpecifyOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @Json(name = "id")
            @NonNull
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string MoshiJetBrainsOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @Json(name = "id")
            @NotNull
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    public const string MoshiLombokOutput = """
        import com.squareup.moshi.Json;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @Json(name = "id")
            @NonNull
            private Integer id;
        }
        """;

    public const string MoshiFindBugsOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @Json(name = "id")
            @Nonnull
            private Integer id;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }
        }
        """;

    // Record variations
    public const string NoAnnotationRecordOutput = """
        public record Root(
            Integer id
        ) {}
        """;

    public const string JacksonRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public record Root(
            @JsonProperty("id") Integer id
        ) {}
        """;

    public const string JacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @JsonProperty("id") @NotNull Integer id
        ) {}
        """;

    public const string JacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @JsonProperty("id") @NonNull Integer id
        ) {}
        """;

    public const string JacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @JsonProperty("id") @NotNull Integer id
        ) {}
        """;

    public const string JacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.NonNull;

        public record Root(
            @JsonProperty("id") @NonNull Integer id
        ) {}
        """;

    public const string JacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @JsonProperty("id") @Nonnull Integer id
        ) {}
        """;

    public const string GsonRecordOutput = """
        import com.google.gson.annotations.SerializedName;

        public record Root(
            @SerializedName("id") Integer id
        ) {}
        """;

    public const string GsonJakartaRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @SerializedName("id") @NotNull Integer id
        ) {}
        """;

    public const string GsonJSpecifyRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @SerializedName("id") @NonNull Integer id
        ) {}
        """;

    public const string GsonJetBrainsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @SerializedName("id") @NotNull Integer id
        ) {}
        """;

    public const string GsonLombokRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.NonNull;

        public record Root(
            @SerializedName("id") @NonNull Integer id
        ) {}
        """;

    public const string GsonFindBugsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @SerializedName("id") @Nonnull Integer id
        ) {}
        """;

    public const string MoshiRecordOutput = """
        import com.squareup.moshi.Json;

        public record Root(
            @Json(name = "id") Integer id
        ) {}
        """;

    public const string MoshiJakartaRecordOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @Json(name = "id") @NotNull Integer id
        ) {}
        """;

    public const string MoshiJSpecifyRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @Json(name = "id") @NonNull Integer id
        ) {}
        """;

    public const string MoshiJetBrainsRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @Json(name = "id") @NotNull Integer id
        ) {}
        """;

    public const string MoshiLombokRecordOutput = """
        import com.squareup.moshi.Json;
        import lombok.NonNull;

        public record Root(
            @Json(name = "id") @NonNull Integer id
        ) {}
        """;

    public const string MoshiFindBugsRecordOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @Json(name = "id") @Nonnull Integer id
        ) {}
        """;
}