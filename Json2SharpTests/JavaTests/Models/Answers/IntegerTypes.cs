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
            private Integer json2sharpInt;

            private Long json2sharpLong;

            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            private Integer json2sharpInt;

            @JsonProperty("long")
            private Long json2sharpLong;

            @JsonProperty("nullable_int")
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            private Integer json2sharpInt;

            @JsonProperty("long")
            @NotNull
            private Long json2sharpLong;

            @JsonProperty("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            private Integer json2sharpInt;

            @JsonProperty("long")
            @NonNull
            private Long json2sharpLong;

            @JsonProperty("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            private Integer json2sharpInt;

            @JsonProperty("long")
            @NotNull
            private Long json2sharpLong;

            @JsonProperty("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
        import lombok.NonNull;

        public class Root {
            @JsonProperty("int")
            @NonNull
            private Integer json2sharpInt;

            @JsonProperty("long")
            @NonNull
            private Long json2sharpLong;

            @JsonProperty("nullable_int")
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string JacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @JsonProperty("int")
            @Nonnull
            private Integer json2sharpInt;

            @JsonProperty("long")
            @Nonnull
            private Long json2sharpLong;

            @JsonProperty("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            private Integer json2sharpInt;

            @SerializedName("long")
            private Long json2sharpLong;

            @SerializedName("nullable_int")
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            private Integer json2sharpInt;

            @SerializedName("long")
            @NotNull
            private Long json2sharpLong;

            @SerializedName("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            private Integer json2sharpInt;

            @SerializedName("long")
            @NonNull
            private Long json2sharpLong;

            @SerializedName("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            private Integer json2sharpInt;

            @SerializedName("long")
            @NotNull
            private Long json2sharpLong;

            @SerializedName("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
        import lombok.NonNull;

        public class Root {
            @SerializedName("int")
            @NonNull
            private Integer json2sharpInt;

            @SerializedName("long")
            @NonNull
            private Long json2sharpLong;

            @SerializedName("nullable_int")
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string GsonFindBugsOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @SerializedName("int")
            @Nonnull
            private Integer json2sharpInt;

            @SerializedName("long")
            @Nonnull
            private Long json2sharpLong;

            @SerializedName("nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            private Integer json2sharpInt;

            @Json(name = "long")
            private Long json2sharpLong;

            @Json(name = "nullable_int")
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            private Integer json2sharpInt;

            @Json(name = "long")
            @NotNull
            private Long json2sharpLong;

            @Json(name = "nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            private Integer json2sharpInt;

            @Json(name = "long")
            @NonNull
            private Long json2sharpLong;

            @Json(name = "nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            private Integer json2sharpInt;

            @Json(name = "long")
            @NotNull
            private Long json2sharpLong;

            @Json(name = "nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
        import lombok.NonNull;

        public class Root {
            @Json(name = "int")
            @NonNull
            private Integer json2sharpInt;

            @Json(name = "long")
            @NonNull
            private Long json2sharpLong;

            @Json(name = "nullable_int")
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
            }

            public Object getNullableInt() {
                return nullableInt;
            }

            public void setNullableInt(Object nullableInt) {
                this.nullableInt = nullableInt;
            }
        }
        """;

    public const string MoshiFindBugsOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @Json(name = "int")
            @Nonnull
            private Integer json2sharpInt;

            @Json(name = "long")
            @Nonnull
            private Long json2sharpLong;

            @Json(name = "nullable_int")
            @Nullable
            private Object nullableInt;

            public Integer getJson2sharpInt() {
                return json2sharpInt;
            }

            public void setJson2sharpInt(Integer json2sharpInt) {
                this.json2sharpInt = json2sharpInt;
            }

            public Long getJson2sharpLong() {
                return json2sharpLong;
            }

            public void setJson2sharpLong(Long json2sharpLong) {
                this.json2sharpLong = json2sharpLong;
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
            Integer json2sharpInt,
            Long json2sharpLong,
            Object nullableInt
        ) {}
        """;

    public const string JacksonRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public record Root(
            @JsonProperty("int") Integer json2sharpInt,
            @JsonProperty("long") Long json2sharpLong,
            @JsonProperty("nullable_int") Object nullableInt
        ) {}
        """;

    public const string JacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @JsonProperty("int") @NotNull Integer json2sharpInt,
            @JsonProperty("long") @NotNull Long json2sharpLong,
            @JsonProperty("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string JacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @JsonProperty("int") @NonNull Integer json2sharpInt,
            @JsonProperty("long") @NonNull Long json2sharpLong,
            @JsonProperty("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string JacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @JsonProperty("int") @NotNull Integer json2sharpInt,
            @JsonProperty("long") @NotNull Long json2sharpLong,
            @JsonProperty("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string JacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.NonNull;

        public record Root(
            @JsonProperty("int") @NonNull Integer json2sharpInt,
            @JsonProperty("long") @NonNull Long json2sharpLong,
            @JsonProperty("nullable_int") Object nullableInt
        ) {}
        """;

    public const string JacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @JsonProperty("int") @Nonnull Integer json2sharpInt,
            @JsonProperty("long") @Nonnull Long json2sharpLong,
            @JsonProperty("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string GsonRecordOutput = """
        import com.google.gson.annotations.SerializedName;

        public record Root(
            @SerializedName("int") Integer json2sharpInt,
            @SerializedName("long") Long json2sharpLong,
            @SerializedName("nullable_int") Object nullableInt
        ) {}
        """;

    public const string GsonJakartaRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @SerializedName("int") @NotNull Integer json2sharpInt,
            @SerializedName("long") @NotNull Long json2sharpLong,
            @SerializedName("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string GsonJSpecifyRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @SerializedName("int") @NonNull Integer json2sharpInt,
            @SerializedName("long") @NonNull Long json2sharpLong,
            @SerializedName("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string GsonJetBrainsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @SerializedName("int") @NotNull Integer json2sharpInt,
            @SerializedName("long") @NotNull Long json2sharpLong,
            @SerializedName("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string GsonLombokRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.NonNull;

        public record Root(
            @SerializedName("int") @NonNull Integer json2sharpInt,
            @SerializedName("long") @NonNull Long json2sharpLong,
            @SerializedName("nullable_int") Object nullableInt
        ) {}
        """;

    public const string GsonFindBugsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @SerializedName("int") @Nonnull Integer json2sharpInt,
            @SerializedName("long") @Nonnull Long json2sharpLong,
            @SerializedName("nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string MoshiRecordOutput = """
        import com.squareup.moshi.Json;

        public record Root(
            @Json(name = "int") Integer json2sharpInt,
            @Json(name = "long") Long json2sharpLong,
            @Json(name = "nullable_int") Object nullableInt
        ) {}
        """;

    public const string MoshiJakartaRecordOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @Json(name = "int") @NotNull Integer json2sharpInt,
            @Json(name = "long") @NotNull Long json2sharpLong,
            @Json(name = "nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string MoshiJSpecifyRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @Json(name = "int") @NonNull Integer json2sharpInt,
            @Json(name = "long") @NonNull Long json2sharpLong,
            @Json(name = "nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string MoshiJetBrainsRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @Json(name = "int") @NotNull Integer json2sharpInt,
            @Json(name = "long") @NotNull Long json2sharpLong,
            @Json(name = "nullable_int") @Nullable Object nullableInt
        ) {}
        """;

    public const string MoshiLombokRecordOutput = """
        import com.squareup.moshi.Json;
        import lombok.NonNull;

        public record Root(
            @Json(name = "int") @NonNull Integer json2sharpInt,
            @Json(name = "long") @NonNull Long json2sharpLong,
            @Json(name = "nullable_int") Object nullableInt
        ) {}
        """;

    public const string MoshiFindBugsRecordOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @Json(name = "int") @Nonnull Integer json2sharpInt,
            @Json(name = "long") @Nonnull Long json2sharpLong,
            @Json(name = "nullable_int") @Nullable Object nullableInt
        ) {}
        """;
}