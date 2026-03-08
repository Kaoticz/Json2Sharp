namespace Json2SharpTests.JavaTests.Models.Answers;

internal static class NullabilityImportTypes
{
    public const string NonNullableOnlyInput = "{\"HELLO_WORLD\": \"blep\"}";

    public const string NullableOnlyInput = "{\"HELLO_WORLD\": null}";

    // Jackson + Jakarta
    public const string NonNullableOnlyJacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;

        public record Root(
            @JsonProperty("HELLO_WORLD") @NotNull String helloWorld
        ) {}
        """;

    public const string NullableOnlyJacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @JsonProperty("HELLO_WORLD") @Nullable Object helloWorld
        ) {}
        """;

    public const string NonNullableOnlyJacksonJakartaOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;

        public class Root {
            @JsonProperty("HELLO_WORLD")
            @NotNull
            private String helloWorld;

            public String getHelloWorld() {
                return helloWorld;
            }

            public void setHelloWorld(String helloWorld) {
                this.helloWorld = helloWorld;
            }
        }
        """;

    public const string NullableOnlyJacksonJakartaOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @JsonProperty("HELLO_WORLD")
            @Nullable
            private Object helloWorld;

            public Object getHelloWorld() {
                return helloWorld;
            }

            public void setHelloWorld(Object helloWorld) {
                this.helloWorld = helloWorld;
            }
        }
        """;

    // Jackson + JSpecify
    public const string NonNullableOnlyJacksonJSpecifyOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;

        public class Root {
            @JsonProperty("HELLO_WORLD")
            @NonNull
            private String helloWorld;

            public String getHelloWorld() {
                return helloWorld;
            }

            public void setHelloWorld(String helloWorld) {
                this.helloWorld = helloWorld;
            }
        }
        """;

    public const string NullableOnlyJacksonJSpecifyOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @JsonProperty("HELLO_WORLD")
            @Nullable
            private Object helloWorld;

            public Object getHelloWorld() {
                return helloWorld;
            }

            public void setHelloWorld(Object helloWorld) {
                this.helloWorld = helloWorld;
            }
        }
        """;

    public const string NonNullableOnlyJacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;

        public record Root(
            @JsonProperty("HELLO_WORLD") @NonNull String helloWorld
        ) {}
        """;

    public const string NullableOnlyJacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @JsonProperty("HELLO_WORLD") @Nullable Object helloWorld
        ) {}
        """;

    // Jackson + JetBrains
    public const string NonNullableOnlyJacksonJetBrainsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;

        public class Root {
            @JsonProperty("HELLO_WORLD")
            @NotNull
            private String helloWorld;

            public String getHelloWorld() {
                return helloWorld;
            }

            public void setHelloWorld(String helloWorld) {
                this.helloWorld = helloWorld;
            }
        }
        """;

    public const string NullableOnlyJacksonJetBrainsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @JsonProperty("HELLO_WORLD")
            @Nullable
            private Object helloWorld;

            public Object getHelloWorld() {
                return helloWorld;
            }

            public void setHelloWorld(Object helloWorld) {
                this.helloWorld = helloWorld;
            }
        }
        """;

    public const string NonNullableOnlyJacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;

        public record Root(
            @JsonProperty("HELLO_WORLD") @NotNull String helloWorld
        ) {}
        """;

    public const string NullableOnlyJacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @JsonProperty("HELLO_WORLD") @Nullable Object helloWorld
        ) {}
        """;

    // Jackson + Lombok
    public const string NonNullableOnlyJacksonLombokOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.Data;
        import lombok.NonNull;

        @Data
        public class Root {
            @JsonProperty("HELLO_WORLD")
            @NonNull
            private String helloWorld;
        }
        """;

    public const string NullableOnlyJacksonLombokOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.Data;

        @Data
        public class Root {
            @JsonProperty("HELLO_WORLD")
            private Object helloWorld;
        }
        """;

    public const string NonNullableOnlyJacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.NonNull;

        public record Root(
            @JsonProperty("HELLO_WORLD") @NonNull String helloWorld
        ) {}
        """;

    public const string NullableOnlyJacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public record Root(
            @JsonProperty("HELLO_WORLD") Object helloWorld
        ) {}
        """;

    // Jackson + FindBugs
    public const string NonNullableOnlyJacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;

        public class Root {
            @JsonProperty("HELLO_WORLD")
            @Nonnull
            private String helloWorld;

            public String getHelloWorld() {
                return helloWorld;
            }

            public void setHelloWorld(String helloWorld) {
                this.helloWorld = helloWorld;
            }
        }
        """;

    public const string NullableOnlyJacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nullable;

        public class Root {
            @JsonProperty("HELLO_WORLD")
            @Nullable
            private Object helloWorld;

            public Object getHelloWorld() {
                return helloWorld;
            }

            public void setHelloWorld(Object helloWorld) {
                this.helloWorld = helloWorld;
            }
        }
        """;

    public const string NonNullableOnlyJacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;

        public record Root(
            @JsonProperty("HELLO_WORLD") @Nonnull String helloWorld
        ) {}
        """;

    public const string NullableOnlyJacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nullable;

        public record Root(
            @JsonProperty("HELLO_WORLD") @Nullable Object helloWorld
        ) {}
        """;
}
