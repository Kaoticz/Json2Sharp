namespace Json2SharpTests.JavaTests.Models.Answers;

internal static class WeirdNameTypes
{
    public const string Input = """
        {
            "1-weird-name": "hello",
            "class": "world",
            "for": "!"
        }
        """;

    public const string NoAnnotationOutput = """
        public class Root {
            private String json2sharp1WeirdName;

            private String json2sharpClass;

            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    // Class variations
    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public class Root {
            @JsonProperty("1-weird-name")
            private String json2sharp1WeirdName;

            @JsonProperty("class")
            private String json2sharpClass;

            @JsonProperty("for")
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string JacksonJakartaOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @JsonProperty("1-weird-name")
            @NotNull
            private String json2sharp1WeirdName;

            @JsonProperty("class")
            @NotNull
            private String json2sharpClass;

            @JsonProperty("for")
            @NotNull
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string JacksonJSpecifyOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @JsonProperty("1-weird-name")
            @NonNull
            private String json2sharp1WeirdName;

            @JsonProperty("class")
            @NonNull
            private String json2sharpClass;

            @JsonProperty("for")
            @NonNull
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string JacksonJetBrainsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @JsonProperty("1-weird-name")
            @NotNull
            private String json2sharp1WeirdName;

            @JsonProperty("class")
            @NotNull
            private String json2sharpClass;

            @JsonProperty("for")
            @NotNull
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string JacksonLombokOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @JsonProperty("1-weird-name")
            @NonNull
            private String json2sharp1WeirdName;

            @JsonProperty("class")
            @NonNull
            private String json2sharpClass;

            @JsonProperty("for")
            @NonNull
            private String json2sharpFor;
        }
        """;

    public const string JacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @JsonProperty("1-weird-name")
            @Nonnull
            private String json2sharp1WeirdName;

            @JsonProperty("class")
            @Nonnull
            private String json2sharpClass;

            @JsonProperty("for")
            @Nonnull
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName;

        public class Root {
            @SerializedName("1-weird-name")
            private String json2sharp1WeirdName;

            @SerializedName("class")
            private String json2sharpClass;

            @SerializedName("for")
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string GsonJakartaOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @SerializedName("1-weird-name")
            @NotNull
            private String json2sharp1WeirdName;

            @SerializedName("class")
            @NotNull
            private String json2sharpClass;

            @SerializedName("for")
            @NotNull
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string GsonJSpecifyOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @SerializedName("1-weird-name")
            @NonNull
            private String json2sharp1WeirdName;

            @SerializedName("class")
            @NonNull
            private String json2sharpClass;

            @SerializedName("for")
            @NonNull
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string GsonJetBrainsOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @SerializedName("1-weird-name")
            @NotNull
            private String json2sharp1WeirdName;

            @SerializedName("class")
            @NotNull
            private String json2sharpClass;

            @SerializedName("for")
            @NotNull
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string GsonLombokOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @SerializedName("1-weird-name")
            @NonNull
            private String json2sharp1WeirdName;

            @SerializedName("class")
            @NonNull
            private String json2sharpClass;

            @SerializedName("for")
            @NonNull
            private String json2sharpFor;
        }
        """;

    public const string GsonFindBugsOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @SerializedName("1-weird-name")
            @Nonnull
            private String json2sharp1WeirdName;

            @SerializedName("class")
            @Nonnull
            private String json2sharpClass;

            @SerializedName("for")
            @Nonnull
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json;

        public class Root {
            @Json(name = "1-weird-name")
            private String json2sharp1WeirdName;

            @Json(name = "class")
            private String json2sharpClass;

            @Json(name = "for")
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string MoshiJakartaOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @Json(name = "1-weird-name")
            @NotNull
            private String json2sharp1WeirdName;

            @Json(name = "class")
            @NotNull
            private String json2sharpClass;

            @Json(name = "for")
            @NotNull
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string MoshiJSpecifyOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @Json(name = "1-weird-name")
            @NonNull
            private String json2sharp1WeirdName;

            @Json(name = "class")
            @NonNull
            private String json2sharpClass;

            @Json(name = "for")
            @NonNull
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string MoshiJetBrainsOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @Json(name = "1-weird-name")
            @NotNull
            private String json2sharp1WeirdName;

            @Json(name = "class")
            @NotNull
            private String json2sharpClass;

            @Json(name = "for")
            @NotNull
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    public const string MoshiLombokOutput = """
        import com.squareup.moshi.Json;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @Json(name = "1-weird-name")
            @NonNull
            private String json2sharp1WeirdName;

            @Json(name = "class")
            @NonNull
            private String json2sharpClass;

            @Json(name = "for")
            @NonNull
            private String json2sharpFor;
        }
        """;

    public const string MoshiFindBugsOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @Json(name = "1-weird-name")
            @Nonnull
            private String json2sharp1WeirdName;

            @Json(name = "class")
            @Nonnull
            private String json2sharpClass;

            @Json(name = "for")
            @Nonnull
            private String json2sharpFor;

            public String getJson2sharp1WeirdName() {
                return json2sharp1WeirdName;
            }

            public void setJson2sharp1WeirdName(String json2sharp1WeirdName) {
                this.json2sharp1WeirdName = json2sharp1WeirdName;
            }

            public String getJson2sharpClass() {
                return json2sharpClass;
            }

            public void setJson2sharpClass(String json2sharpClass) {
                this.json2sharpClass = json2sharpClass;
            }

            public String getJson2sharpFor() {
                return json2sharpFor;
            }

            public void setJson2sharpFor(String json2sharpFor) {
                this.json2sharpFor = json2sharpFor;
            }
        }
        """;

    // Record variations
    public const string NoAnnotationRecordOutput = """
        public record Root(
            String json2sharp1WeirdName,
            String json2sharpClass,
            String json2sharpFor
        ) {}
        """;

    public const string JacksonRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public record Root(
            @JsonProperty("1-weird-name") String json2sharp1WeirdName,
            @JsonProperty("class") String json2sharpClass,
            @JsonProperty("for") String json2sharpFor
        ) {}
        """;

    public const string JacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @JsonProperty("1-weird-name") @NotNull String json2sharp1WeirdName,
            @JsonProperty("class") @NotNull String json2sharpClass,
            @JsonProperty("for") @NotNull String json2sharpFor
        ) {}
        """;

    public const string JacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @JsonProperty("1-weird-name") @NonNull String json2sharp1WeirdName,
            @JsonProperty("class") @NonNull String json2sharpClass,
            @JsonProperty("for") @NonNull String json2sharpFor
        ) {}
        """;

    public const string JacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @JsonProperty("1-weird-name") @NotNull String json2sharp1WeirdName,
            @JsonProperty("class") @NotNull String json2sharpClass,
            @JsonProperty("for") @NotNull String json2sharpFor
        ) {}
        """;

    public const string JacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.NonNull;

        public record Root(
            @JsonProperty("1-weird-name") @NonNull String json2sharp1WeirdName,
            @JsonProperty("class") @NonNull String json2sharpClass,
            @JsonProperty("for") @NonNull String json2sharpFor
        ) {}
        """;

    public const string JacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @JsonProperty("1-weird-name") @Nonnull String json2sharp1WeirdName,
            @JsonProperty("class") @Nonnull String json2sharpClass,
            @JsonProperty("for") @Nonnull String json2sharpFor
        ) {}
        """;

    public const string GsonRecordOutput = """
        import com.google.gson.annotations.SerializedName;

        public record Root(
            @SerializedName("1-weird-name") String json2sharp1WeirdName,
            @SerializedName("class") String json2sharpClass,
            @SerializedName("for") String json2sharpFor
        ) {}
        """;

    public const string GsonJakartaRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @SerializedName("1-weird-name") @NotNull String json2sharp1WeirdName,
            @SerializedName("class") @NotNull String json2sharpClass,
            @SerializedName("for") @NotNull String json2sharpFor
        ) {}
        """;

    public const string GsonJSpecifyRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @SerializedName("1-weird-name") @NonNull String json2sharp1WeirdName,
            @SerializedName("class") @NonNull String json2sharpClass,
            @SerializedName("for") @NonNull String json2sharpFor
        ) {}
        """;

    public const string GsonJetBrainsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @SerializedName("1-weird-name") @NotNull String json2sharp1WeirdName,
            @SerializedName("class") @NotNull String json2sharpClass,
            @SerializedName("for") @NotNull String json2sharpFor
        ) {}
        """;

    public const string GsonLombokRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.NonNull;

        public record Root(
            @SerializedName("1-weird-name") @NonNull String json2sharp1WeirdName,
            @SerializedName("class") @NonNull String json2sharpClass,
            @SerializedName("for") @NonNull String json2sharpFor
        ) {}
        """;

    public const string GsonFindBugsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @SerializedName("1-weird-name") @Nonnull String json2sharp1WeirdName,
            @SerializedName("class") @Nonnull String json2sharpClass,
            @SerializedName("for") @Nonnull String json2sharpFor
        ) {}
        """;

    public const string MoshiRecordOutput = """
        import com.squareup.moshi.Json;

        public record Root(
            @Json(name = "1-weird-name") String json2sharp1WeirdName,
            @Json(name = "class") String json2sharpClass,
            @Json(name = "for") String json2sharpFor
        ) {}
        """;

    public const string MoshiJakartaRecordOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @Json(name = "1-weird-name") @NotNull String json2sharp1WeirdName,
            @Json(name = "class") @NotNull String json2sharpClass,
            @Json(name = "for") @NotNull String json2sharpFor
        ) {}
        """;

    public const string MoshiJSpecifyRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @Json(name = "1-weird-name") @NonNull String json2sharp1WeirdName,
            @Json(name = "class") @NonNull String json2sharpClass,
            @Json(name = "for") @NonNull String json2sharpFor
        ) {}
        """;

    public const string MoshiJetBrainsRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @Json(name = "1-weird-name") @NotNull String json2sharp1WeirdName,
            @Json(name = "class") @NotNull String json2sharpClass,
            @Json(name = "for") @NotNull String json2sharpFor
        ) {}
        """;

    public const string MoshiLombokRecordOutput = """
        import com.squareup.moshi.Json;
        import lombok.NonNull;

        public record Root(
            @Json(name = "1-weird-name") @NonNull String json2sharp1WeirdName,
            @Json(name = "class") @NonNull String json2sharpClass,
            @Json(name = "for") @NonNull String json2sharpFor
        ) {}
        """;

    public const string MoshiFindBugsRecordOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @Json(name = "1-weird-name") @Nonnull String json2sharp1WeirdName,
            @Json(name = "class") @Nonnull String json2sharpClass,
            @Json(name = "for") @Nonnull String json2sharpFor
        ) {}
        """;
}