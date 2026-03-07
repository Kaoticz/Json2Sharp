namespace Json2SharpTests.JavaTests.Models.Answers;

internal static class IntegerTypes
{
    public const string Input = """
        {
            "int": 1,
            "long": 2147483648,
            "nullable_int": null
        }
        """;

    public const string NoAnnotationOutput = """
        public class Root {
            private Integer intValue;

            private Long longValue;

            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    // Class variations
    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public class Root {
            @JsonProperty("int")
            private Integer intValue;

            @JsonProperty("long")
            private Long longValue;

            @JsonProperty("nullable_int")
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string JacksonJakartaOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @JsonProperty("int")
            @NotNull
            private Integer intValue;

            @JsonProperty("long")
            @NotNull
            private Long longValue;

            @JsonProperty("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string JacksonJSpecifyOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @JsonProperty("int")
            @NonNull
            private Integer intValue;

            @JsonProperty("long")
            @NonNull
            private Long longValue;

            @JsonProperty("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string JacksonJetBrainsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @JsonProperty("int")
            @NotNull
            private Integer intValue;

            @JsonProperty("long")
            @NotNull
            private Long longValue;

            @JsonProperty("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string JacksonLombokOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @JsonProperty("int")
            @NonNull
            private Integer intValue;

            @JsonProperty("long")
            @NonNull
            private Long longValue;

            @JsonProperty("nullable_int")
            private Object nullableInt;
        }
        """;

    public const string JacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @JsonProperty("int")
            @Nonnull
            private Integer intValue;

            @JsonProperty("long")
            @Nonnull
            private Long longValue;

            @JsonProperty("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName;

        public class Root {
            @SerializedName("int")
            private Integer intValue;

            @SerializedName("long")
            private Long longValue;

            @SerializedName("nullable_int")
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string GsonJakartaOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @SerializedName("int")
            @NotNull
            private Integer intValue;

            @SerializedName("long")
            @NotNull
            private Long longValue;

            @SerializedName("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string GsonJSpecifyOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @SerializedName("int")
            @NonNull
            private Integer intValue;

            @SerializedName("long")
            @NonNull
            private Long longValue;

            @SerializedName("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string GsonJetBrainsOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @SerializedName("int")
            @NotNull
            private Integer intValue;

            @SerializedName("long")
            @NotNull
            private Long longValue;

            @SerializedName("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string GsonLombokOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @SerializedName("int")
            @NonNull
            private Integer intValue;

            @SerializedName("long")
            @NonNull
            private Long longValue;

            @SerializedName("nullable_int")
            private Object nullableInt;
        }
        """;

    public const string GsonFindBugsOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @SerializedName("int")
            @Nonnull
            private Integer intValue;

            @SerializedName("long")
            @Nonnull
            private Long longValue;

            @SerializedName("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json;

        public class Root {
            @Json(name = "int")
            private Integer intValue;

            @Json(name = "long")
            private Long longValue;

            @Json(name = "nullable_int")
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string MoshiJakartaOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @Json(name = "int")
            @NotNull
            private Integer intValue;

            @Json(name = "long")
            @NotNull
            private Long longValue;

            @Json(name = "nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string MoshiJSpecifyOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @Json(name = "int")
            @NonNull
            private Integer intValue;

            @Json(name = "long")
            @NonNull
            private Long longValue;

            @Json(name = "nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string MoshiJetBrainsOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @Json(name = "int")
            @NotNull
            private Integer intValue;

            @Json(name = "long")
            @NotNull
            private Long longValue;

            @Json(name = "nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string MoshiLombokOutput = """
        import com.squareup.moshi.Json;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @Json(name = "int")
            @NonNull
            private Integer intValue;

            @Json(name = "long")
            @NonNull
            private Long longValue;

            @Json(name = "nullable_int")
            private Object nullableInt;
        }
        """;

    public const string MoshiFindBugsOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @Json(name = "int")
            @Nonnull
            private Integer intValue;

            @Json(name = "long")
            @Nonnull
            private Long longValue;

            @Json(name = "nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getIntValue() {
                return intValue;
            }

            public void setIntValue(Integer intValue) {
                this.intValue = intValue;
            }

            public Long getLongValue() {
                return longValue;
            }

            public void setLongValue(Long longValue) {
                this.longValue = longValue;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    // Record variations
    public const string NoAnnotationRecordOutput = """
        public record Root(
            Integer intValue,
            Long longValue,
            Object nullableInt
        ) {}
        """;

    public const string JacksonRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public record Root(
            @JsonProperty("int") Integer intValue,
            @JsonProperty("long") Long longValue,
            @JsonProperty("nullable_int") Object nullableInt
        ) {}
        """;

    public const string JacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @JsonProperty("int") @NotNull Integer intValue,
            @JsonProperty("long") @NotNull Long longValue,
            @JsonProperty("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string JacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @JsonProperty("int") @NonNull Integer intValue,
            @JsonProperty("long") @NonNull Long longValue,
            @JsonProperty("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string JacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @JsonProperty("int") @NotNull Integer intValue,
            @JsonProperty("long") @NotNull Long longValue,
            @JsonProperty("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string JacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.NonNull;

        public record Root(
            @JsonProperty("int") @NonNull Integer intValue,
            @JsonProperty("long") @NonNull Long longValue,
            @JsonProperty("nullable_int") Object nullableInt
        ) {}
        """;

    public const string JacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @JsonProperty("int") @Nonnull Integer intValue,
            @JsonProperty("long") @Nonnull Long longValue,
            @JsonProperty("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string GsonRecordOutput = """
        import com.google.gson.annotations.SerializedName;

        public record Root(
            @SerializedName("int") Integer intValue,
            @SerializedName("long") Long longValue,
            @SerializedName("nullable_int") Object nullableInt
        ) {}
        """;

    public const string GsonJakartaRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @SerializedName("int") @NotNull Integer intValue,
            @SerializedName("long") @NotNull Long longValue,
            @SerializedName("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string GsonJSpecifyRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @SerializedName("int") @NonNull Integer intValue,
            @SerializedName("long") @NonNull Long longValue,
            @SerializedName("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string GsonJetBrainsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @SerializedName("int") @NotNull Integer intValue,
            @SerializedName("long") @NotNull Long longValue,
            @SerializedName("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string GsonLombokRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.NonNull;

        public record Root(
            @SerializedName("int") @NonNull Integer intValue,
            @SerializedName("long") @NonNull Long longValue,
            @SerializedName("nullable_int") Object nullableInt
        ) {}
        """;

    public const string GsonFindBugsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @SerializedName("int") @Nonnull Integer intValue,
            @SerializedName("long") @Nonnull Long longValue,
            @SerializedName("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string MoshiRecordOutput = """
        import com.squareup.moshi.Json;

        public record Root(
            @Json(name = "int") Integer intValue,
            @Json(name = "long") Long longValue,
            @Json(name = "nullable_int") Object nullableInt
        ) {}
        """;

    public const string MoshiJakartaRecordOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @Json(name = "int") @NotNull Integer intValue,
            @Json(name = "long") @NotNull Long longValue,
            @Json(name = "nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string MoshiJSpecifyRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @Json(name = "int") @NonNull Integer intValue,
            @Json(name = "long") @NonNull Long longValue,
            @Json(name = "nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string MoshiJetBrainsRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @Json(name = "int") @NotNull Integer intValue,
            @Json(name = "long") @NotNull Long longValue,
            @Json(name = "nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string MoshiLombokRecordOutput = """
        import com.squareup.moshi.Json;
        import lombok.NonNull;

        public record Root(
            @Json(name = "int") @NonNull Integer intValue,
            @Json(name = "long") @NonNull Long longValue,
            @Json(name = "nullable_int") Object nullableInt
        ) {}
        """;

    public const string MoshiFindBugsRecordOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @Json(name = "int") @Nonnull Integer intValue,
            @Json(name = "long") @Nonnull Long longValue,
            @Json(name = "nullable_int") @Nullable Object nullableInt
        ) {}
        """;
}