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
            private String _1WeirdName;

            private String classValue;

            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
            }
        }
        """;

    // Class variations
    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public class Root {
            @JsonProperty("1-weird-name")
            private String _1WeirdName;

            @JsonProperty("class")
            private String classValue;

            @JsonProperty("for")
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
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
            private String _1WeirdName;

            @JsonProperty("class")
            @NotNull
            private String classValue;

            @JsonProperty("for")
            @NotNull
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
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
            private String _1WeirdName;

            @JsonProperty("class")
            @NonNull
            private String classValue;

            @JsonProperty("for")
            @NonNull
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
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
            private String _1WeirdName;

            @JsonProperty("class")
            @NotNull
            private String classValue;

            @JsonProperty("for")
            @NotNull
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
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
            private String _1WeirdName;

            @JsonProperty("class")
            @NonNull
            private String classValue;

            @JsonProperty("for")
            @NonNull
            private String forValue;
        }
        """;

    public const string JacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @JsonProperty("1-weird-name")
            @Nonnull
            private String _1WeirdName;

            @JsonProperty("class")
            @Nonnull
            private String classValue;

            @JsonProperty("for")
            @Nonnull
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
            }
        }
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName;

        public class Root {
            @SerializedName("1-weird-name")
            private String _1WeirdName;

            @SerializedName("class")
            private String classValue;

            @SerializedName("for")
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
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
            private String _1WeirdName;

            @SerializedName("class")
            @NotNull
            private String classValue;

            @SerializedName("for")
            @NotNull
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
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
            private String _1WeirdName;

            @SerializedName("class")
            @NonNull
            private String classValue;

            @SerializedName("for")
            @NonNull
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
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
            private String _1WeirdName;

            @SerializedName("class")
            @NotNull
            private String classValue;

            @SerializedName("for")
            @NotNull
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
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
            private String _1WeirdName;

            @SerializedName("class")
            @NonNull
            private String classValue;

            @SerializedName("for")
            @NonNull
            private String forValue;
        }
        """;

    public const string GsonFindBugsOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @SerializedName("1-weird-name")
            @Nonnull
            private String _1WeirdName;

            @SerializedName("class")
            @Nonnull
            private String classValue;

            @SerializedName("for")
            @Nonnull
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
            }
        }
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json;

        public class Root {
            @Json(name = "1-weird-name")
            private String _1WeirdName;

            @Json(name = "class")
            private String classValue;

            @Json(name = "for")
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
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
            private String _1WeirdName;

            @Json(name = "class")
            @NotNull
            private String classValue;

            @Json(name = "for")
            @NotNull
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
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
            private String _1WeirdName;

            @Json(name = "class")
            @NonNull
            private String classValue;

            @Json(name = "for")
            @NonNull
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
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
            private String _1WeirdName;

            @Json(name = "class")
            @NotNull
            private String classValue;

            @Json(name = "for")
            @NotNull
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
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
            private String _1WeirdName;

            @Json(name = "class")
            @NonNull
            private String classValue;

            @Json(name = "for")
            @NonNull
            private String forValue;
        }
        """;

    public const string MoshiFindBugsOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @Json(name = "1-weird-name")
            @Nonnull
            private String _1WeirdName;

            @Json(name = "class")
            @Nonnull
            private String classValue;

            @Json(name = "for")
            @Nonnull
            private String forValue;

            public String get_1WeirdName() {
                return _1WeirdName;
            }

            public void set_1WeirdName(String _1WeirdName) {
                this._1WeirdName = _1WeirdName;
            }

            public String getClassValue() {
                return classValue;
            }

            public void setClassValue(String classValue) {
                this.classValue = classValue;
            }

            public String getForValue() {
                return forValue;
            }

            public void setForValue(String forValue) {
                this.forValue = forValue;
            }
        }
        """;

    // Record variations
    public const string NoAnnotationRecordOutput = """
        public record Root(
            String _1WeirdName,
            String classValue,
            String forValue
        ) {}
        """;

    public const string JacksonRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public record Root(
            @JsonProperty("1-weird-name") String _1WeirdName,
            @JsonProperty("class") String classValue,
            @JsonProperty("for") String forValue
        ) {}
        """;

    public const string JacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @JsonProperty("1-weird-name") @NotNull String _1WeirdName,
            @JsonProperty("class") @NotNull String classValue,
            @JsonProperty("for") @NotNull String forValue
        ) {}
        """;

    public const string JacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @JsonProperty("1-weird-name") @NonNull String _1WeirdName,
            @JsonProperty("class") @NonNull String classValue,
            @JsonProperty("for") @NonNull String forValue
        ) {}
        """;

    public const string JacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @JsonProperty("1-weird-name") @NotNull String _1WeirdName,
            @JsonProperty("class") @NotNull String classValue,
            @JsonProperty("for") @NotNull String forValue
        ) {}
        """;

    public const string JacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.NonNull;

        public record Root(
            @JsonProperty("1-weird-name") @NonNull String _1WeirdName,
            @JsonProperty("class") @NonNull String classValue,
            @JsonProperty("for") @NonNull String forValue
        ) {}
        """;

    public const string JacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @JsonProperty("1-weird-name") @Nonnull String _1WeirdName,
            @JsonProperty("class") @Nonnull String classValue,
            @JsonProperty("for") @Nonnull String forValue
        ) {}
        """;

    public const string GsonRecordOutput = """
        import com.google.gson.annotations.SerializedName;

        public record Root(
            @SerializedName("1-weird-name") String _1WeirdName,
            @SerializedName("class") String classValue,
            @SerializedName("for") String forValue
        ) {}
        """;

    public const string GsonJakartaRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @SerializedName("1-weird-name") @NotNull String _1WeirdName,
            @SerializedName("class") @NotNull String classValue,
            @SerializedName("for") @NotNull String forValue
        ) {}
        """;

    public const string GsonJSpecifyRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @SerializedName("1-weird-name") @NonNull String _1WeirdName,
            @SerializedName("class") @NonNull String classValue,
            @SerializedName("for") @NonNull String forValue
        ) {}
        """;

    public const string GsonJetBrainsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @SerializedName("1-weird-name") @NotNull String _1WeirdName,
            @SerializedName("class") @NotNull String classValue,
            @SerializedName("for") @NotNull String forValue
        ) {}
        """;

    public const string GsonLombokRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.NonNull;

        public record Root(
            @SerializedName("1-weird-name") @NonNull String _1WeirdName,
            @SerializedName("class") @NonNull String classValue,
            @SerializedName("for") @NonNull String forValue
        ) {}
        """;

    public const string GsonFindBugsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @SerializedName("1-weird-name") @Nonnull String _1WeirdName,
            @SerializedName("class") @Nonnull String classValue,
            @SerializedName("for") @Nonnull String forValue
        ) {}
        """;

    public const string MoshiRecordOutput = """
        import com.squareup.moshi.Json;

        public record Root(
            @Json(name = "1-weird-name") String _1WeirdName,
            @Json(name = "class") String classValue,
            @Json(name = "for") String forValue
        ) {}
        """;

    public const string MoshiJakartaRecordOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @Json(name = "1-weird-name") @NotNull String _1WeirdName,
            @Json(name = "class") @NotNull String classValue,
            @Json(name = "for") @NotNull String forValue
        ) {}
        """;

    public const string MoshiJSpecifyRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @Json(name = "1-weird-name") @NonNull String _1WeirdName,
            @Json(name = "class") @NonNull String classValue,
            @Json(name = "for") @NonNull String forValue
        ) {}
        """;

    public const string MoshiJetBrainsRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @Json(name = "1-weird-name") @NotNull String _1WeirdName,
            @Json(name = "class") @NotNull String classValue,
            @Json(name = "for") @NotNull String forValue
        ) {}
        """;

    public const string MoshiLombokRecordOutput = """
        import com.squareup.moshi.Json;
        import lombok.NonNull;

        public record Root(
            @Json(name = "1-weird-name") @NonNull String _1WeirdName,
            @Json(name = "class") @NonNull String classValue,
            @Json(name = "for") @NonNull String forValue
        ) {}
        """;

    public const string MoshiFindBugsRecordOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @Json(name = "1-weird-name") @Nonnull String _1WeirdName,
            @Json(name = "class") @Nonnull String classValue,
            @Json(name = "for") @Nonnull String forValue
        ) {}
        """;
}