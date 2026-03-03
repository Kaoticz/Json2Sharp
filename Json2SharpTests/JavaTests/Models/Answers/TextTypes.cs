namespace Json2SharpTests.JavaTests.Models.Answers;

internal static class TextTypes
{
    public const string Input = """
        {
            "text": "hello world",
            "nullable_text": null
        }
        """;

    public const string NoAnnotationOutput = """
        public class Root {
            private String text;

            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    // Class variations
    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public class Root {
            @JsonProperty("text")
            private String text;

            @JsonProperty("nullable_text")
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string JacksonJakartaOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @JsonProperty("text")
            @NotNull
            private String text;

            @JsonProperty("nullable_text")
            @Nullable
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string JacksonJSpecifyOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @JsonProperty("text")
            @NonNull
            private String text;

            @JsonProperty("nullable_text")
            @Nullable
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string JacksonJetBrainsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @JsonProperty("text")
            @NotNull
            private String text;

            @JsonProperty("nullable_text")
            @Nullable
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string JacksonLombokOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.NonNull;

        public class Root {
            @JsonProperty("text")
            @NonNull
            private String text;

            @JsonProperty("nullable_text")
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string JacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @JsonProperty("text")
            @Nonnull
            private String text;

            @JsonProperty("nullable_text")
            @Nullable
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName;

        public class Root {
            @SerializedName("text")
            private String text;

            @SerializedName("nullable_text")
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string GsonJakartaOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @SerializedName("text")
            @NotNull
            private String text;

            @SerializedName("nullable_text")
            @Nullable
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string GsonJSpecifyOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @SerializedName("text")
            @NonNull
            private String text;

            @SerializedName("nullable_text")
            @Nullable
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string GsonJetBrainsOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @SerializedName("text")
            @NotNull
            private String text;

            @SerializedName("nullable_text")
            @Nullable
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string GsonLombokOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.NonNull;

        public class Root {
            @SerializedName("text")
            @NonNull
            private String text;

            @SerializedName("nullable_text")
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string GsonFindBugsOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @SerializedName("text")
            @Nonnull
            private String text;

            @SerializedName("nullable_text")
            @Nullable
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json;

        public class Root {
            @Json(name = "text")
            private String text;

            @Json(name = "nullable_text")
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string MoshiJakartaOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @Json(name = "text")
            @NotNull
            private String text;

            @Json(name = "nullable_text")
            @Nullable
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string MoshiJSpecifyOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @Json(name = "text")
            @NonNull
            private String text;

            @Json(name = "nullable_text")
            @Nullable
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string MoshiJetBrainsOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @Json(name = "text")
            @NotNull
            private String text;

            @Json(name = "nullable_text")
            @Nullable
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string MoshiLombokOutput = """
        import com.squareup.moshi.Json;
        import lombok.NonNull;

        public class Root {
            @Json(name = "text")
            @NonNull
            private String text;

            @Json(name = "nullable_text")
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    public const string MoshiFindBugsOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @Json(name = "text")
            @Nonnull
            private String text;

            @Json(name = "nullable_text")
            @Nullable
            private Object nullableText;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }

            public Object getNullableText() {
                return nullableText;
            }

            public void setNullableText(Object nullableText) {
                this.nullableText = nullableText;
            }
        }
        """;

    // Record variations
    public const string NoAnnotationRecordOutput = """
        public record Root(
            String text,
            Object nullableText
        ) {}
        """;

    public const string JacksonRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public record Root(
            @JsonProperty("text") String text,
            @JsonProperty("nullable_text") Object nullableText
        ) {}
        """;

    public const string JacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @JsonProperty("text") @NotNull String text,
            @JsonProperty("nullable_text") @Nullable Object nullableText
        ) {}
        """;

    public const string JacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @JsonProperty("text") @NonNull String text,
            @JsonProperty("nullable_text") @Nullable Object nullableText
        ) {}
        """;

    public const string JacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @JsonProperty("text") @NotNull String text,
            @JsonProperty("nullable_text") @Nullable Object nullableText
        ) {}
        """;

    public const string JacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.NonNull;

        public record Root(
            @JsonProperty("text") @NonNull String text,
            @JsonProperty("nullable_text") Object nullableText
        ) {}
        """;

    public const string JacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @JsonProperty("text") @Nonnull String text,
            @JsonProperty("nullable_text") @Nullable Object nullableText
        ) {}
        """;

    public const string GsonRecordOutput = """
        import com.google.gson.annotations.SerializedName;

        public record Root(
            @SerializedName("text") String text,
            @SerializedName("nullable_text") Object nullableText
        ) {}
        """;

    public const string GsonJakartaRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @SerializedName("text") @NotNull String text,
            @SerializedName("nullable_text") @Nullable Object nullableText
        ) {}
        """;

    public const string GsonJSpecifyRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @SerializedName("text") @NonNull String text,
            @SerializedName("nullable_text") @Nullable Object nullableText
        ) {}
        """;

    public const string GsonJetBrainsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @SerializedName("text") @NotNull String text,
            @SerializedName("nullable_text") @Nullable Object nullableText
        ) {}
        """;

    public const string GsonLombokRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.NonNull;

        public record Root(
            @SerializedName("text") @NonNull String text,
            @SerializedName("nullable_text") Object nullableText
        ) {}
        """;

    public const string GsonFindBugsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @SerializedName("text") @Nonnull String text,
            @SerializedName("nullable_text") @Nullable Object nullableText
        ) {}
        """;

    public const string MoshiRecordOutput = """
        import com.squareup.moshi.Json;

        public record Root(
            @Json(name = "text") String text,
            @Json(name = "nullable_text") Object nullableText
        ) {}
        """;

    public const string MoshiJakartaRecordOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @Json(name = "text") @NotNull String text,
            @Json(name = "nullable_text") @Nullable Object nullableText
        ) {}
        """;

    public const string MoshiJSpecifyRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @Json(name = "text") @NonNull String text,
            @Json(name = "nullable_text") @Nullable Object nullableText
        ) {}
        """;

    public const string MoshiJetBrainsRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @Json(name = "text") @NotNull String text,
            @Json(name = "nullable_text") @Nullable Object nullableText
        ) {}
        """;

    public const string MoshiLombokRecordOutput = """
        import com.squareup.moshi.Json;
        import lombok.NonNull;

        public record Root(
            @Json(name = "text") @NonNull String text,
            @Json(name = "nullable_text") Object nullableText
        ) {}
        """;

    public const string MoshiFindBugsRecordOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @Json(name = "text") @Nonnull String text,
            @Json(name = "nullable_text") @Nullable Object nullableText
        ) {}
        """;
}