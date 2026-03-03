namespace Json2SharpTests.JavaTests.Models.Answers;

internal static class ObjectTypes
{
    public const string Input = """
        {
            "empty_object": {},
            "simple_object": { "text": "hello" },
            "nested_object": { "id": 1, "data": { "text": "nested" } },
            "nullable_object": null
        }
        """;

    public const string NoAnnotationOutput = """
        public class Root {
            private Object emptyObject;

            private SimpleObject simpleObject;

            private NestedObject nestedObject;

            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            private Integer id;

            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    // Class variations
    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public class Root {
            @JsonProperty("empty_object")
            private Object emptyObject;

            @JsonProperty("simple_object")
            private SimpleObject simpleObject;

            @JsonProperty("nested_object")
            private NestedObject nestedObject;

            @JsonProperty("nullable_object")
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @JsonProperty("text")
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @JsonProperty("id")
            private Integer id;

            @JsonProperty("data")
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @JsonProperty("text")
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string JacksonJakartaOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @JsonProperty("empty_object")
            @NotNull
            private Object emptyObject;

            @JsonProperty("simple_object")
            @NotNull
            private SimpleObject simpleObject;

            @JsonProperty("nested_object")
            @NotNull
            private NestedObject nestedObject;

            @JsonProperty("nullable_object")
            @Nullable
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @JsonProperty("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @JsonProperty("id")
            @NotNull
            private Integer id;

            @JsonProperty("data")
            @NotNull
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @JsonProperty("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string JacksonJSpecifyOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @JsonProperty("empty_object")
            @NonNull
            private Object emptyObject;

            @JsonProperty("simple_object")
            @NonNull
            private SimpleObject simpleObject;

            @JsonProperty("nested_object")
            @NonNull
            private NestedObject nestedObject;

            @JsonProperty("nullable_object")
            @Nullable
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @JsonProperty("text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @JsonProperty("id")
            @NonNull
            private Integer id;

            @JsonProperty("data")
            @NonNull
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @JsonProperty("text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string JacksonJetBrainsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @JsonProperty("empty_object")
            @NotNull
            private Object emptyObject;

            @JsonProperty("simple_object")
            @NotNull
            private SimpleObject simpleObject;

            @JsonProperty("nested_object")
            @NotNull
            private NestedObject nestedObject;

            @JsonProperty("nullable_object")
            @Nullable
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @JsonProperty("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @JsonProperty("id")
            @NotNull
            private Integer id;

            @JsonProperty("data")
            @NotNull
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @JsonProperty("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string JacksonLombokOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.NonNull;

        @lombok.Data
        public class Root {
            @JsonProperty("empty_object")
            @NonNull
            private Object emptyObject;

            @JsonProperty("simple_object")
            @NonNull
            private SimpleObject simpleObject;

            @JsonProperty("nested_object")
            @NonNull
            private NestedObject nestedObject;

            @JsonProperty("nullable_object")
            private Object nullableObject;
        }

        @lombok.Data
        public class SimpleObject {
            @JsonProperty("text")
            @NonNull
            private String text;
        }

        @lombok.Data
        public class NestedObject {
            @JsonProperty("id")
            @NonNull
            private Integer id;

            @JsonProperty("data")
            @NonNull
            private Data data;
        }

        @lombok.Data
        public class Data {
            @JsonProperty("text")
            @NonNull
            private String text;
        }
        """;

    public const string JacksonFindBugsOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @JsonProperty("empty_object")
            @Nonnull
            private Object emptyObject;

            @JsonProperty("simple_object")
            @Nonnull
            private SimpleObject simpleObject;

            @JsonProperty("nested_object")
            @Nonnull
            private NestedObject nestedObject;

            @JsonProperty("nullable_object")
            @Nullable
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @JsonProperty("text")
            @Nonnull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @JsonProperty("id")
            @Nonnull
            private Integer id;

            @JsonProperty("data")
            @Nonnull
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @JsonProperty("text")
            @Nonnull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName;

        public class Root {
            @SerializedName("empty_object")
            private Object emptyObject;

            @SerializedName("simple_object")
            private SimpleObject simpleObject;

            @SerializedName("nested_object")
            private NestedObject nestedObject;

            @SerializedName("nullable_object")
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @SerializedName("text")
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @SerializedName("id")
            private Integer id;

            @SerializedName("data")
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @SerializedName("text")
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string GsonJakartaOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @SerializedName("empty_object")
            @NotNull
            private Object emptyObject;

            @SerializedName("simple_object")
            @NotNull
            private SimpleObject simpleObject;

            @SerializedName("nested_object")
            @NotNull
            private NestedObject nestedObject;

            @SerializedName("nullable_object")
            @Nullable
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @SerializedName("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @SerializedName("id")
            @NotNull
            private Integer id;

            @SerializedName("data")
            @NotNull
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @SerializedName("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string GsonJSpecifyOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @SerializedName("empty_object")
            @NonNull
            private Object emptyObject;

            @SerializedName("simple_object")
            @NonNull
            private SimpleObject simpleObject;

            @SerializedName("nested_object")
            @NonNull
            private NestedObject nestedObject;

            @SerializedName("nullable_object")
            @Nullable
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @SerializedName("text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @SerializedName("id")
            @NonNull
            private Integer id;

            @SerializedName("data")
            @NonNull
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @SerializedName("text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string GsonJetBrainsOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @SerializedName("empty_object")
            @NotNull
            private Object emptyObject;

            @SerializedName("simple_object")
            @NotNull
            private SimpleObject simpleObject;

            @SerializedName("nested_object")
            @NotNull
            private NestedObject nestedObject;

            @SerializedName("nullable_object")
            @Nullable
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @SerializedName("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @SerializedName("id")
            @NotNull
            private Integer id;

            @SerializedName("data")
            @NotNull
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @SerializedName("text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string GsonLombokOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.NonNull;

        @lombok.Data
        public class Root {
            @SerializedName("empty_object")
            @NonNull
            private Object emptyObject;

            @SerializedName("simple_object")
            @NonNull
            private SimpleObject simpleObject;

            @SerializedName("nested_object")
            @NonNull
            private NestedObject nestedObject;

            @SerializedName("nullable_object")
            private Object nullableObject;
        }

        @lombok.Data
        public class SimpleObject {
            @SerializedName("text")
            @NonNull
            private String text;
        }

        @lombok.Data
        public class NestedObject {
            @SerializedName("id")
            @NonNull
            private Integer id;

            @SerializedName("data")
            @NonNull
            private Data data;
        }

        @lombok.Data
        public class Data {
            @SerializedName("text")
            @NonNull
            private String text;
        }
        """;

    public const string GsonFindBugsOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @SerializedName("empty_object")
            @Nonnull
            private Object emptyObject;

            @SerializedName("simple_object")
            @Nonnull
            private SimpleObject simpleObject;

            @SerializedName("nested_object")
            @Nonnull
            private NestedObject nestedObject;

            @SerializedName("nullable_object")
            @Nullable
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @SerializedName("text")
            @Nonnull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @SerializedName("id")
            @Nonnull
            private Integer id;

            @SerializedName("data")
            @Nonnull
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @SerializedName("text")
            @Nonnull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json;

        public class Root {
            @Json(name = "empty_object")
            private Object emptyObject;

            @Json(name = "simple_object")
            private SimpleObject simpleObject;

            @Json(name = "nested_object")
            private NestedObject nestedObject;

            @Json(name = "nullable_object")
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @Json(name = "text")
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @Json(name = "id")
            private Integer id;

            @Json(name = "data")
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @Json(name = "text")
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string MoshiJakartaOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public class Root {
            @Json(name = "empty_object")
            @NotNull
            private Object emptyObject;

            @Json(name = "simple_object")
            @NotNull
            private SimpleObject simpleObject;

            @Json(name = "nested_object")
            @NotNull
            private NestedObject nestedObject;

            @Json(name = "nullable_object")
            @Nullable
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @Json(name = "text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @Json(name = "id")
            @NotNull
            private Integer id;

            @Json(name = "data")
            @NotNull
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @Json(name = "text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string MoshiJSpecifyOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public class Root {
            @Json(name = "empty_object")
            @NonNull
            private Object emptyObject;

            @Json(name = "simple_object")
            @NonNull
            private SimpleObject simpleObject;

            @Json(name = "nested_object")
            @NonNull
            private NestedObject nestedObject;

            @Json(name = "nullable_object")
            @Nullable
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @Json(name = "text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @Json(name = "id")
            @NonNull
            private Integer id;

            @Json(name = "data")
            @NonNull
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @Json(name = "text")
            @NonNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string MoshiJetBrainsOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public class Root {
            @Json(name = "empty_object")
            @NotNull
            private Object emptyObject;

            @Json(name = "simple_object")
            @NotNull
            private SimpleObject simpleObject;

            @Json(name = "nested_object")
            @NotNull
            private NestedObject nestedObject;

            @Json(name = "nullable_object")
            @Nullable
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @Json(name = "text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @Json(name = "id")
            @NotNull
            private Integer id;

            @Json(name = "data")
            @NotNull
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @Json(name = "text")
            @NotNull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    public const string MoshiLombokOutput = """
        import com.squareup.moshi.Json;
        import lombok.NonNull;

        @lombok.Data
        public class Root {
            @Json(name = "empty_object")
            @NonNull
            private Object emptyObject;

            @Json(name = "simple_object")
            @NonNull
            private SimpleObject simpleObject;

            @Json(name = "nested_object")
            @NonNull
            private NestedObject nestedObject;

            @Json(name = "nullable_object")
            private Object nullableObject;
        }

        @lombok.Data
        public class SimpleObject {
            @Json(name = "text")
            @NonNull
            private String text;
        }

        @lombok.Data
        public class NestedObject {
            @Json(name = "id")
            @NonNull
            private Integer id;

            @Json(name = "data")
            @NonNull
            private Data data;
        }

        @lombok.Data
        public class Data {
            @Json(name = "text")
            @NonNull
            private String text;
        }
        """;

    public const string MoshiFindBugsOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public class Root {
            @Json(name = "empty_object")
            @Nonnull
            private Object emptyObject;

            @Json(name = "simple_object")
            @Nonnull
            private SimpleObject simpleObject;

            @Json(name = "nested_object")
            @Nonnull
            private NestedObject nestedObject;

            @Json(name = "nullable_object")
            @Nullable
            private Object nullableObject;

            public Object getEmptyObject() {
                return emptyObject;
            }

            public void setEmptyObject(Object emptyObject) {
                this.emptyObject = emptyObject;
            }

            public SimpleObject getSimpleObject() {
                return simpleObject;
            }

            public void setSimpleObject(SimpleObject simpleObject) {
                this.simpleObject = simpleObject;
            }

            public NestedObject getNestedObject() {
                return nestedObject;
            }

            public void setNestedObject(NestedObject nestedObject) {
                this.nestedObject = nestedObject;
            }

            public Object getNullableObject() {
                return nullableObject;
            }

            public void setNullableObject(Object nullableObject) {
                this.nullableObject = nullableObject;
            }
        }

        public class SimpleObject {
            @Json(name = "text")
            @Nonnull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }

        public class NestedObject {
            @Json(name = "id")
            @Nonnull
            private Integer id;

            @Json(name = "data")
            @Nonnull
            private Data data;

            public Integer getId() {
                return id;
            }

            public void setId(Integer id) {
                this.id = id;
            }

            public Data getData() {
                return data;
            }

            public void setData(Data data) {
                this.data = data;
            }
        }

        public class Data {
            @Json(name = "text")
            @Nonnull
            private String text;

            public String getText() {
                return text;
            }

            public void setText(String text) {
                this.text = text;
            }
        }
        """;

    // Record variations
    public const string NoAnnotationRecordOutput = """
        public record Root(
            Object emptyObject,
            SimpleObject simpleObject,
            NestedObject nestedObject,
            Object nullableObject
        ) {}

        public record SimpleObject(
            String text
        ) {}

        public record NestedObject(
            Integer id,
            Data data
        ) {}

        public record Data(
            String text
        ) {}
        """;

    public const string JacksonRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;

        public record Root(
            @JsonProperty("empty_object") Object emptyObject,
            @JsonProperty("simple_object") SimpleObject simpleObject,
            @JsonProperty("nested_object") NestedObject nestedObject,
            @JsonProperty("nullable_object") Object nullableObject
        ) {}

        public record SimpleObject(
            @JsonProperty("text") String text
        ) {}

        public record NestedObject(
            @JsonProperty("id") Integer id,
            @JsonProperty("data") Data data
        ) {}

        public record Data(
            @JsonProperty("text") String text
        ) {}
        """;

    public const string JacksonJakartaRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @JsonProperty("empty_object") @NotNull Object emptyObject,
            @JsonProperty("simple_object") @NotNull SimpleObject simpleObject,
            @JsonProperty("nested_object") @NotNull NestedObject nestedObject,
            @JsonProperty("nullable_object") @Nullable Object nullableObject
        ) {}

        public record SimpleObject(
            @JsonProperty("text") @NotNull String text
        ) {}

        public record NestedObject(
            @JsonProperty("id") @NotNull Integer id,
            @JsonProperty("data") @NotNull Data data
        ) {}

        public record Data(
            @JsonProperty("text") @NotNull String text
        ) {}
        """;

    public const string JacksonJSpecifyRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @JsonProperty("empty_object") @NonNull Object emptyObject,
            @JsonProperty("simple_object") @NonNull SimpleObject simpleObject,
            @JsonProperty("nested_object") @NonNull NestedObject nestedObject,
            @JsonProperty("nullable_object") @Nullable Object nullableObject
        ) {}

        public record SimpleObject(
            @JsonProperty("text") @NonNull String text
        ) {}

        public record NestedObject(
            @JsonProperty("id") @NonNull Integer id,
            @JsonProperty("data") @NonNull Data data
        ) {}

        public record Data(
            @JsonProperty("text") @NonNull String text
        ) {}
        """;

    public const string JacksonJetBrainsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @JsonProperty("empty_object") @NotNull Object emptyObject,
            @JsonProperty("simple_object") @NotNull SimpleObject simpleObject,
            @JsonProperty("nested_object") @NotNull NestedObject nestedObject,
            @JsonProperty("nullable_object") @Nullable Object nullableObject
        ) {}

        public record SimpleObject(
            @JsonProperty("text") @NotNull String text
        ) {}

        public record NestedObject(
            @JsonProperty("id") @NotNull Integer id,
            @JsonProperty("data") @NotNull Data data
        ) {}

        public record Data(
            @JsonProperty("text") @NotNull String text
        ) {}
        """;

    public const string JacksonLombokRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import lombok.NonNull;

        public record Root(
            @JsonProperty("empty_object") @NonNull Object emptyObject,
            @JsonProperty("simple_object") @NonNull SimpleObject simpleObject,
            @JsonProperty("nested_object") @NonNull NestedObject nestedObject,
            @JsonProperty("nullable_object") Object nullableObject
        ) {}

        public record SimpleObject(
            @JsonProperty("text") @NonNull String text
        ) {}

        public record NestedObject(
            @JsonProperty("id") @NonNull Integer id,
            @JsonProperty("data") @NonNull Data data
        ) {}

        public record Data(
            @JsonProperty("text") @NonNull String text
        ) {}
        """;

    public const string JacksonFindBugsRecordOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @JsonProperty("empty_object") @Nonnull Object emptyObject,
            @JsonProperty("simple_object") @Nonnull SimpleObject simpleObject,
            @JsonProperty("nested_object") @Nonnull NestedObject nestedObject,
            @JsonProperty("nullable_object") @Nullable Object nullableObject
        ) {}

        public record SimpleObject(
            @JsonProperty("text") @Nonnull String text
        ) {}

        public record NestedObject(
            @JsonProperty("id") @Nonnull Integer id,
            @JsonProperty("data") @Nonnull Data data
        ) {}

        public record Data(
            @JsonProperty("text") @Nonnull String text
        ) {}
        """;

    public const string GsonRecordOutput = """
        import com.google.gson.annotations.SerializedName;

        public record Root(
            @SerializedName("empty_object") Object emptyObject,
            @SerializedName("simple_object") SimpleObject simpleObject,
            @SerializedName("nested_object") NestedObject nestedObject,
            @SerializedName("nullable_object") Object nullableObject
        ) {}

        public record SimpleObject(
            @SerializedName("text") String text
        ) {}

        public record NestedObject(
            @SerializedName("id") Integer id,
            @SerializedName("data") Data data
        ) {}

        public record Data(
            @SerializedName("text") String text
        ) {}
        """;

    public const string GsonJakartaRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @SerializedName("empty_object") @NotNull Object emptyObject,
            @SerializedName("simple_object") @NotNull SimpleObject simpleObject,
            @SerializedName("nested_object") @NotNull NestedObject nestedObject,
            @SerializedName("nullable_object") @Nullable Object nullableObject
        ) {}

        public record SimpleObject(
            @SerializedName("text") @NotNull String text
        ) {}

        public record NestedObject(
            @SerializedName("id") @NotNull Integer id,
            @SerializedName("data") @NotNull Data data
        ) {}

        public record Data(
            @SerializedName("text") @NotNull String text
        ) {}
        """;

    public const string GsonJSpecifyRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @SerializedName("empty_object") @NonNull Object emptyObject,
            @SerializedName("simple_object") @NonNull SimpleObject simpleObject,
            @SerializedName("nested_object") @NonNull NestedObject nestedObject,
            @SerializedName("nullable_object") @Nullable Object nullableObject
        ) {}

        public record SimpleObject(
            @SerializedName("text") @NonNull String text
        ) {}

        public record NestedObject(
            @SerializedName("id") @NonNull Integer id,
            @SerializedName("data") @NonNull Data data
        ) {}

        public record Data(
            @SerializedName("text") @NonNull String text
        ) {}
        """;

    public const string GsonJetBrainsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @SerializedName("empty_object") @NotNull Object emptyObject,
            @SerializedName("simple_object") @NotNull SimpleObject simpleObject,
            @SerializedName("nested_object") @NotNull NestedObject nestedObject,
            @SerializedName("nullable_object") @Nullable Object nullableObject
        ) {}

        public record SimpleObject(
            @SerializedName("text") @NotNull String text
        ) {}

        public record NestedObject(
            @SerializedName("id") @NotNull Integer id,
            @SerializedName("data") @NotNull Data data
        ) {}

        public record Data(
            @SerializedName("text") @NotNull String text
        ) {}
        """;

    public const string GsonLombokRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import lombok.NonNull;

        public record Root(
            @SerializedName("empty_object") @NonNull Object emptyObject,
            @SerializedName("simple_object") @NonNull SimpleObject simpleObject,
            @SerializedName("nested_object") @NonNull NestedObject nestedObject,
            @SerializedName("nullable_object") Object nullableObject
        ) {}

        public record SimpleObject(
            @SerializedName("text") @NonNull String text
        ) {}

        public record NestedObject(
            @SerializedName("id") @NonNull Integer id,
            @SerializedName("data") @NonNull Data data
        ) {}

        public record Data(
            @SerializedName("text") @NonNull String text
        ) {}
        """;

    public const string GsonFindBugsRecordOutput = """
        import com.google.gson.annotations.SerializedName;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @SerializedName("empty_object") @Nonnull Object emptyObject,
            @SerializedName("simple_object") @Nonnull SimpleObject simpleObject,
            @SerializedName("nested_object") @Nonnull NestedObject nestedObject,
            @SerializedName("nullable_object") @Nullable Object nullableObject
        ) {}

        public record SimpleObject(
            @SerializedName("text") @Nonnull String text
        ) {}

        public record NestedObject(
            @SerializedName("id") @Nonnull Integer id,
            @SerializedName("data") @Nonnull Data data
        ) {}

        public record Data(
            @SerializedName("text") @Nonnull String text
        ) {}
        """;

    public const string MoshiRecordOutput = """
        import com.squareup.moshi.Json;

        public record Root(
            @Json(name = "empty_object") Object emptyObject,
            @Json(name = "simple_object") SimpleObject simpleObject,
            @Json(name = "nested_object") NestedObject nestedObject,
            @Json(name = "nullable_object") Object nullableObject
        ) {}

        public record SimpleObject(
            @Json(name = "text") String text
        ) {}

        public record NestedObject(
            @Json(name = "id") Integer id,
            @Json(name = "data") Data data
        ) {}

        public record Data(
            @Json(name = "text") String text
        ) {}
        """;

    public const string MoshiJakartaRecordOutput = """
        import com.squareup.moshi.Json;
        import jakarta.validation.constraints.NotNull;
        import jakarta.validation.constraints.Nullable;

        public record Root(
            @Json(name = "empty_object") @NotNull Object emptyObject,
            @Json(name = "simple_object") @NotNull SimpleObject simpleObject,
            @Json(name = "nested_object") @NotNull NestedObject nestedObject,
            @Json(name = "nullable_object") @Nullable Object nullableObject
        ) {}

        public record SimpleObject(
            @Json(name = "text") @NotNull String text
        ) {}

        public record NestedObject(
            @Json(name = "id") @NotNull Integer id,
            @Json(name = "data") @NotNull Data data
        ) {}

        public record Data(
            @Json(name = "text") @NotNull String text
        ) {}
        """;

    public const string MoshiJSpecifyRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jspecify.annotations.NonNull;
        import org.jspecify.annotations.Nullable;

        public record Root(
            @Json(name = "empty_object") @NonNull Object emptyObject,
            @Json(name = "simple_object") @NonNull SimpleObject simpleObject,
            @Json(name = "nested_object") @NonNull NestedObject nestedObject,
            @Json(name = "nullable_object") @Nullable Object nullableObject
        ) {}

        public record SimpleObject(
            @Json(name = "text") @NonNull String text
        ) {}

        public record NestedObject(
            @Json(name = "id") @NonNull Integer id,
            @Json(name = "data") @NonNull Data data
        ) {}

        public record Data(
            @Json(name = "text") @NonNull String text
        ) {}
        """;

    public const string MoshiJetBrainsRecordOutput = """
        import com.squareup.moshi.Json;
        import org.jetbrains.annotations.NotNull;
        import org.jetbrains.annotations.Nullable;

        public record Root(
            @Json(name = "empty_object") @NotNull Object emptyObject,
            @Json(name = "simple_object") @NotNull SimpleObject simpleObject,
            @Json(name = "nested_object") @NotNull NestedObject nestedObject,
            @Json(name = "nullable_object") @Nullable Object nullableObject
        ) {}

        public record SimpleObject(
            @Json(name = "text") @NotNull String text
        ) {}

        public record NestedObject(
            @Json(name = "id") @NotNull Integer id,
            @Json(name = "data") @NotNull Data data
        ) {}

        public record Data(
            @Json(name = "text") @NotNull String text
        ) {}
        """;

    public const string MoshiLombokRecordOutput = """
        import com.squareup.moshi.Json;
        import lombok.NonNull;

        public record Root(
            @Json(name = "empty_object") @NonNull Object emptyObject,
            @Json(name = "simple_object") @NonNull SimpleObject simpleObject,
            @Json(name = "nested_object") @NonNull NestedObject nestedObject,
            @Json(name = "nullable_object") Object nullableObject
        ) {}

        public record SimpleObject(
            @Json(name = "text") @NonNull String text
        ) {}

        public record NestedObject(
            @Json(name = "id") @NonNull Integer id,
            @Json(name = "data") @NonNull Data data
        ) {}

        public record Data(
            @Json(name = "text") @NonNull String text
        ) {}
        """;

    public const string MoshiFindBugsRecordOutput = """
        import com.squareup.moshi.Json;
        import javax.annotation.Nonnull;
        import javax.annotation.Nullable;

        public record Root(
            @Json(name = "empty_object") @Nonnull Object emptyObject,
            @Json(name = "simple_object") @Nonnull SimpleObject simpleObject,
            @Json(name = "nested_object") @Nonnull NestedObject nestedObject,
            @Json(name = "nullable_object") @Nullable Object nullableObject
        ) {}

        public record SimpleObject(
            @Json(name = "text") @Nonnull String text
        ) {}

        public record NestedObject(
            @Json(name = "id") @Nonnull Integer id,
            @Json(name = "data") @Nonnull Data data
        ) {}

        public record Data(
            @Json(name = "text") @Nonnull String text
        ) {}
        """;
}