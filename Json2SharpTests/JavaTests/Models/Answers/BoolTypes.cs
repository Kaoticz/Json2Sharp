namespace Json2SharpTests.JavaTests.Models.Answers;

internal static class BoolTypes
{
    public const string Input = """
        {
            "bool": true,
            "nullable_bool": null
        }
        """;

    public const string NoAnnotationOutput = """
        public class Root {
            private Boolean bool;

            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    // Class variations
    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public class Root {
            @JsonProperty("bool")
            private Boolean bool;

            @JsonProperty("nullable_bool")
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string JacksonJakartaOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @JsonProperty("bool")
            @NotNull
            private Boolean bool;

            @JsonProperty("nullable_bool")
            @Nullable
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string JacksonJSpecifyOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @JsonProperty("bool")
            @NonNull
            private Boolean bool;

            @JsonProperty("nullable_bool")
            @Nullable
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string JacksonJetBrainsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @JsonProperty("bool")
            @NotNull
            private Boolean bool;

            @JsonProperty("nullable_bool")
            @Nullable
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string JacksonLombokOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @JsonProperty("bool")
            @NonNull
            private Boolean bool;

            @JsonProperty("nullable_bool")
            private Object nullableBool;
        }
        """;

    public const string JacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @JsonProperty("bool")
            @Nonnull
            private Boolean bool;

            @JsonProperty("nullable_bool")
            @Nullable
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName;

        public class Root {
            @SerializedName("bool")
            private Boolean bool;

            @SerializedName("nullable_bool")
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string GsonJakartaOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @SerializedName("bool")
            @NotNull
            private Boolean bool;

            @SerializedName("nullable_bool")
            @Nullable
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string GsonJSpecifyOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @SerializedName("bool")
            @NonNull
            private Boolean bool;

            @SerializedName("nullable_bool")
            @Nullable
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string GsonJetBrainsOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @SerializedName("bool")
            @NotNull
            private Boolean bool;

            @SerializedName("nullable_bool")
            @Nullable
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string GsonLombokOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @SerializedName("bool")
            @NonNull
            private Boolean bool;

            @SerializedName("nullable_bool")
            private Object nullableBool;
        }
        """;

    public const string GsonFindBugsOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @SerializedName("bool")
            @Nonnull
            private Boolean bool;

            @SerializedName("nullable_bool")
            @Nullable
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json;

        public class Root {
            @Json(name = "bool")
            private Boolean bool;

            @Json(name = "nullable_bool")
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string MoshiJakartaOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @Json(name = "bool")
            @NotNull
            private Boolean bool;

            @Json(name = "nullable_bool")
            @Nullable
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string MoshiJSpecifyOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @Json(name = "bool")
            @NonNull
            private Boolean bool;

            @Json(name = "nullable_bool")
            @Nullable
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string MoshiJetBrainsOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @Json(name = "bool")
            @NotNull
            private Boolean bool;

            @Json(name = "nullable_bool")
            @Nullable
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    public const string MoshiLombokOutput = """
        import com.squareup.moshi.Json;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @Json(name = "bool")
            @NonNull
            private Boolean bool;

            @Json(name = "nullable_bool")
            private Object nullableBool;
        }
        """;

    public const string MoshiFindBugsOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @Json(name = "bool")
            @Nonnull
            private Boolean bool;

            @Json(name = "nullable_bool")
            @Nullable
            private Object nullableBool;

            public Boolean getBool() {
                return bool;
            }

            public void setBool(Boolean bool) {
                this.bool = bool;
            }

            public Object getNullableBool() {
                return nullableBool;
            }

            public void setNullableBool(Object nullableBool) {
                this.nullableBool = nullableBool;
            }
        }
        """;

    // Record variations
    public const string NoAnnotationRecordOutput = """
        public record Root(
            Boolean bool,
            Object nullableBool
        ) {}
        """;

    public const string JacksonRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public record Root(
            @JsonProperty("bool") Boolean bool,
            @JsonProperty("nullable_bool") Object nullableBool
        ) {}
        """;

    public const string JacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @JsonProperty("bool") @NotNull Boolean bool,
            @JsonProperty("nullable_bool") @Nullable Object nullableBool
        ) {}
        """;

    public const string JacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @JsonProperty("bool") @NonNull Boolean bool,
            @JsonProperty("nullable_bool") @Nullable Object nullableBool
        ) {}
        """;

    public const string JacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @JsonProperty("bool") @NotNull Boolean bool,
            @JsonProperty("nullable_bool") @Nullable Object nullableBool
        ) {}
        """;

    public const string JacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.NonNull;

        public record Root(
            @JsonProperty("bool") @NonNull Boolean bool,
            @JsonProperty("nullable_bool") Object nullableBool
        ) {}
        """;

    public const string JacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @JsonProperty("bool") @Nonnull Boolean bool,
            @JsonProperty("nullable_bool") @Nullable Object nullableBool
        ) {}
        """;

    public const string GsonRecordOutput = """
        import com.google.gson.annotations.SerializedName;

        public record Root(
            @SerializedName("bool") Boolean bool,
            @SerializedName("nullable_bool") Object nullableBool
        ) {}
        """;

    public const string GsonJakartaRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @SerializedName("bool") @NotNull Boolean bool,
            @SerializedName("nullable_bool") @Nullable Object nullableBool
        ) {}
        """;

    public const string GsonJSpecifyRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @SerializedName("bool") @NonNull Boolean bool,
            @SerializedName("nullable_bool") @Nullable Object nullableBool
        ) {}
        """;

    public const string GsonJetBrainsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @SerializedName("bool") @NotNull Boolean bool,
            @SerializedName("nullable_bool") @Nullable Object nullableBool
        ) {}
        """;

    public const string GsonLombokRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.NonNull;

        public record Root(
            @SerializedName("bool") @NonNull Boolean bool,
            @SerializedName("nullable_bool") Object nullableBool
        ) {}
        """;

    public const string GsonFindBugsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @SerializedName("bool") @Nonnull Boolean bool,
            @SerializedName("nullable_bool") @Nullable Object nullableBool
        ) {}
        """;

    public const string MoshiRecordOutput = """
        import com.squareup.moshi.Json;

        public record Root(
            @Json(name = "bool") Boolean bool,
            @Json(name = "nullable_bool") Object nullableBool
        ) {}
        """;

    public const string MoshiJakartaRecordOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @Json(name = "bool") @NotNull Boolean bool,
            @Json(name = "nullable_bool") @Nullable Object nullableBool
        ) {}
        """;

    public const string MoshiJSpecifyRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @Json(name = "bool") @NonNull Boolean bool,
            @Json(name = "nullable_bool") @Nullable Object nullableBool
        ) {}
        """;

    public const string MoshiJetBrainsRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @Json(name = "bool") @NotNull Boolean bool,
            @Json(name = "nullable_bool") @Nullable Object nullableBool
        ) {}
        """;

    public const string MoshiLombokRecordOutput = """
        import com.squareup.moshi.Json;
        import lombok.NonNull;

        public record Root(
            @Json(name = "bool") @NonNull Boolean bool,
            @Json(name = "nullable_bool") Object nullableBool
        ) {}
        """;

    public const string MoshiFindBugsRecordOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @Json(name = "bool") @Nonnull Boolean bool,
            @Json(name = "nullable_bool") @Nullable Object nullableBool
        ) {}
        """;
}