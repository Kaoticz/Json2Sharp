namespace Json2SharpTests.JavaTests.Models.Answers;

internal static class FloatTypes
{
    public const string Input = """
        {
            "float": 1.1,
            "double": 1.1,
            "decimal": 1.1,
            "nullable_float": null
        }
        """;

    public const string NoAnnotationOutput = """
        public class Root {
            private Float floatValue;

            private Float doubleValue;

            private Float decimal;

            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    // Class variations
    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public class Root {
            @JsonProperty("float")
            private Float floatValue;

            @JsonProperty("double")
            private Float doubleValue;

            @JsonProperty("decimal")
            private Float decimal;

            @JsonProperty("nullable_float")
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string JacksonJakartaOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @JsonProperty("float")
            @NotNull
            private Float floatValue;

            @JsonProperty("double")
            @NotNull
            private Float doubleValue;

            @JsonProperty("decimal")
            @NotNull
            private Float decimal;

            @JsonProperty("nullable_float")
            @Nullable
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string JacksonJSpecifyOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @JsonProperty("float")
            @NonNull
            private Float floatValue;

            @JsonProperty("double")
            @NonNull
            private Float doubleValue;

            @JsonProperty("decimal")
            @NonNull
            private Float decimal;

            @JsonProperty("nullable_float")
            @Nullable
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string JacksonJetBrainsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @JsonProperty("float")
            @NotNull
            private Float floatValue;

            @JsonProperty("double")
            @NotNull
            private Float doubleValue;

            @JsonProperty("decimal")
            @NotNull
            private Float decimal;

            @JsonProperty("nullable_float")
            @Nullable
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string JacksonLombokOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @JsonProperty("float")
            @NonNull
            private Float floatValue;

            @JsonProperty("double")
            @NonNull
            private Float doubleValue;

            @JsonProperty("decimal")
            @NonNull
            private Float decimal;

            @JsonProperty("nullable_float")
            private Object nullableFloat;
        }
        """;

    public const string JacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @JsonProperty("float")
            @Nonnull
            private Float floatValue;

            @JsonProperty("double")
            @Nonnull
            private Float doubleValue;

            @JsonProperty("decimal")
            @Nonnull
            private Float decimal;

            @JsonProperty("nullable_float")
            @Nullable
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName;

        public class Root {
            @SerializedName("float")
            private Float floatValue;

            @SerializedName("double")
            private Float doubleValue;

            @SerializedName("decimal")
            private Float decimal;

            @SerializedName("nullable_float")
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string GsonJakartaOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @SerializedName("float")
            @NotNull
            private Float floatValue;

            @SerializedName("double")
            @NotNull
            private Float doubleValue;

            @SerializedName("decimal")
            @NotNull
            private Float decimal;

            @SerializedName("nullable_float")
            @Nullable
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string GsonJSpecifyOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @SerializedName("float")
            @NonNull
            private Float floatValue;

            @SerializedName("double")
            @NonNull
            private Float doubleValue;

            @SerializedName("decimal")
            @NonNull
            private Float decimal;

            @SerializedName("nullable_float")
            @Nullable
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string GsonJetBrainsOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @SerializedName("float")
            @NotNull
            private Float floatValue;

            @SerializedName("double")
            @NotNull
            private Float doubleValue;

            @SerializedName("decimal")
            @NotNull
            private Float decimal;

            @SerializedName("nullable_float")
            @Nullable
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string GsonLombokOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @SerializedName("float")
            @NonNull
            private Float floatValue;

            @SerializedName("double")
            @NonNull
            private Float doubleValue;

            @SerializedName("decimal")
            @NonNull
            private Float decimal;

            @SerializedName("nullable_float")
            private Object nullableFloat;
        }
        """;

    public const string GsonFindBugsOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @SerializedName("float")
            @Nonnull
            private Float floatValue;

            @SerializedName("double")
            @Nonnull
            private Float doubleValue;

            @SerializedName("decimal")
            @Nonnull
            private Float decimal;

            @SerializedName("nullable_float")
            @Nullable
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json;

        public class Root {
            @Json(name = "float")
            private Float floatValue;

            @Json(name = "double")
            private Float doubleValue;

            @Json(name = "decimal")
            private Float decimal;

            @Json(name = "nullable_float")
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string MoshiJakartaOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @Json(name = "float")
            @NotNull
            private Float floatValue;

            @Json(name = "double")
            @NotNull
            private Float doubleValue;

            @Json(name = "decimal")
            @NotNull
            private Float decimal;

            @Json(name = "nullable_float")
            @Nullable
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string MoshiJSpecifyOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @Json(name = "float")
            @NonNull
            private Float floatValue;

            @Json(name = "double")
            @NonNull
            private Float doubleValue;

            @Json(name = "decimal")
            @NonNull
            private Float decimal;

            @Json(name = "nullable_float")
            @Nullable
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string MoshiJetBrainsOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @Json(name = "float")
            @NotNull
            private Float floatValue;

            @Json(name = "double")
            @NotNull
            private Float doubleValue;

            @Json(name = "decimal")
            @NotNull
            private Float decimal;

            @Json(name = "nullable_float")
            @Nullable
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    public const string MoshiLombokOutput = """
        import com.squareup.moshi.Json;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @Json(name = "float")
            @NonNull
            private Float floatValue;

            @Json(name = "double")
            @NonNull
            private Float doubleValue;

            @Json(name = "decimal")
            @NonNull
            private Float decimal;

            @Json(name = "nullable_float")
            private Object nullableFloat;
        }
        """;

    public const string MoshiFindBugsOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @Json(name = "float")
            @Nonnull
            private Float floatValue;

            @Json(name = "double")
            @Nonnull
            private Float doubleValue;

            @Json(name = "decimal")
            @Nonnull
            private Float decimal;

            @Json(name = "nullable_float")
            @Nullable
            private Object nullableFloat;

            public Float getFloatValue() {
                return floatValue;
            }

            public void setFloatValue(Float floatValue) {
                this.floatValue = floatValue;
            }

            public Float getDoubleValue() {
                return doubleValue;
            }

            public void setDoubleValue(Float doubleValue) {
                this.doubleValue = doubleValue;
            }

            public Float getDecimal() {
                return decimal;
            }

            public void setDecimal(Float decimal) {
                this.decimal = decimal;
            }

            public Object getNullableFloat() {
                return nullableFloat;
            }

            public void setNullableFloat(Object nullableFloat) {
                this.nullableFloat = nullableFloat;
            }
        }
        """;

    // Record variations
    public const string NoAnnotationRecordOutput = """
        public record Root(
            Float floatValue,
            Float doubleValue,
            Float decimal,
            Object nullableFloat
        ) {}
        """;

    public const string JacksonRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public record Root(
            @JsonProperty("float") Float floatValue,
            @JsonProperty("double") Float doubleValue,
            @JsonProperty("decimal") Float decimal,
            @JsonProperty("nullable_float") Object nullableFloat
        ) {}
        """;

    public const string JacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @JsonProperty("float") @NotNull Float floatValue,
            @JsonProperty("double") @NotNull Float doubleValue,
            @JsonProperty("decimal") @NotNull Float decimal,
            @JsonProperty("nullable_float") @Nullable Object nullableFloat
        ) {}
        """;

    public const string JacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @JsonProperty("float") @NonNull Float floatValue,
            @JsonProperty("double") @NonNull Float doubleValue,
            @JsonProperty("decimal") @NonNull Float decimal,
            @JsonProperty("nullable_float") @Nullable Object nullableFloat
        ) {}
        """;

    public const string JacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @JsonProperty("float") @NotNull Float floatValue,
            @JsonProperty("double") @NotNull Float doubleValue,
            @JsonProperty("decimal") @NotNull Float decimal,
            @JsonProperty("nullable_float") @Nullable Object nullableFloat
        ) {}
        """;

    public const string JacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.NonNull;

        public record Root(
            @JsonProperty("float") @NonNull Float floatValue,
            @JsonProperty("double") @NonNull Float doubleValue,
            @JsonProperty("decimal") @NonNull Float decimal,
            @JsonProperty("nullable_float") Object nullableFloat
        ) {}
        """;

    public const string JacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @JsonProperty("float") @Nonnull Float floatValue,
            @JsonProperty("double") @Nonnull Float doubleValue,
            @JsonProperty("decimal") @Nonnull Float decimal,
            @JsonProperty("nullable_float") @Nullable Object nullableFloat
        ) {}
        """;

    public const string GsonRecordOutput = """
        import com.google.gson.annotations.SerializedName;

        public record Root(
            @SerializedName("float") Float floatValue,
            @SerializedName("double") Float doubleValue,
            @SerializedName("decimal") Float decimal,
            @SerializedName("nullable_float") Object nullableFloat
        ) {}
        """;

    public const string GsonJakartaRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @SerializedName("float") @NotNull Float floatValue,
            @SerializedName("double") @NotNull Float doubleValue,
            @SerializedName("decimal") @NotNull Float decimal,
            @SerializedName("nullable_float") @Nullable Object nullableFloat
        ) {}
        """;

    public const string GsonJSpecifyRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @SerializedName("float") @NonNull Float floatValue,
            @SerializedName("double") @NonNull Float doubleValue,
            @SerializedName("decimal") @NonNull Float decimal,
            @SerializedName("nullable_float") @Nullable Object nullableFloat
        ) {}
        """;

    public const string GsonJetBrainsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @SerializedName("float") @NotNull Float floatValue,
            @SerializedName("double") @NotNull Float doubleValue,
            @SerializedName("decimal") @NotNull Float decimal,
            @SerializedName("nullable_float") @Nullable Object nullableFloat
        ) {}
        """;

    public const string GsonLombokRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.NonNull;

        public record Root(
            @SerializedName("float") @NonNull Float floatValue,
            @SerializedName("double") @NonNull Float doubleValue,
            @SerializedName("decimal") @NonNull Float decimal,
            @SerializedName("nullable_float") Object nullableFloat
        ) {}
        """;

    public const string GsonFindBugsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @SerializedName("float") @Nonnull Float floatValue,
            @SerializedName("double") @Nonnull Float doubleValue,
            @SerializedName("decimal") @Nonnull Float decimal,
            @SerializedName("nullable_float") @Nullable Object nullableFloat
        ) {}
        """;

    public const string MoshiRecordOutput = """
        import com.squareup.moshi.Json;

        public record Root(
            @Json(name = "float") Float floatValue,
            @Json(name = "double") Float doubleValue,
            @Json(name = "decimal") Float decimal,
            @Json(name = "nullable_float") Object nullableFloat
        ) {}
        """;

    public const string MoshiJakartaRecordOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @Json(name = "float") @NotNull Float floatValue,
            @Json(name = "double") @NotNull Float doubleValue,
            @Json(name = "decimal") @NotNull Float decimal,
            @Json(name = "nullable_float") @Nullable Object nullableFloat
        ) {}
        """;

    public const string MoshiJSpecifyRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @Json(name = "float") @NonNull Float floatValue,
            @Json(name = "double") @NonNull Float doubleValue,
            @Json(name = "decimal") @NonNull Float decimal,
            @Json(name = "nullable_float") @Nullable Object nullableFloat
        ) {}
        """;

    public const string MoshiJetBrainsRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @Json(name = "float") @NotNull Float floatValue,
            @Json(name = "double") @NotNull Float doubleValue,
            @Json(name = "decimal") @NotNull Float decimal,
            @Json(name = "nullable_float") @Nullable Object nullableFloat
        ) {}
        """;

    public const string MoshiLombokRecordOutput = """
        import com.squareup.moshi.Json;
        import lombok.NonNull;

        public record Root(
            @Json(name = "float") @NonNull Float floatValue,
            @Json(name = "double") @NonNull Float doubleValue,
            @Json(name = "decimal") @NonNull Float decimal,
            @Json(name = "nullable_float") Object nullableFloat
        ) {}
        """;

    public const string MoshiFindBugsRecordOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @Json(name = "float") @Nonnull Float floatValue,
            @Json(name = "double") @Nonnull Float doubleValue,
            @Json(name = "decimal") @Nonnull Float decimal,
            @Json(name = "nullable_float") @Nullable Object nullableFloat
        ) {}
        """;
}